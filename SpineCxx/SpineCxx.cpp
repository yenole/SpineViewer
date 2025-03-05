// SpineCxx.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <windows.h>
#include <fstream>
#include <string>


unsigned char* readFileToUnsignedCharArray(const std::string& filename, size_t& fileSize) {
    std::ifstream file(filename, std::ios::binary | std::ios::ate); // 以二进制模式打开文件，并将文件指针移动到末尾

    if (!file.is_open()) {
        std::cerr << "无法打开文件: " << filename << std::endl;
        return nullptr;
    }

    fileSize = file.tellg(); // 获取文件大小
    file.seekg(0, std::ios::beg); // 将文件指针移动到开头

    unsigned char* fileBuffer = new unsigned char[fileSize]; // 分配缓冲区
    if (!file.read(reinterpret_cast<char*>(fileBuffer), fileSize)) { // 读取文件内容
        std::cerr << "读取文件出错: " << filename << std::endl;
        delete[] fileBuffer;
        file.close();
        return nullptr;
    }
	unsigned char* buffer = new unsigned char[4+fileSize];
    buffer[0] = (fileSize >> 0) & 0xFF;
    buffer[1] = (fileSize >> 8) & 0xFF;
    buffer[2] = (fileSize >> 16) & 0xFF;
    buffer[3] = (fileSize >> 24) & 0xFF;
	memcpy(buffer + 4, fileBuffer, fileSize);
    fileSize +=  4;
    file.close(); // 关闭文件
    return buffer;
}

void writeFileUnsignedCharArr(const std::string& filename, unsigned char* buffer, size_t size) {
    std::ofstream file(filename, std::ios::binary); // 以二进制模式打开文件，并将文件指针移动到末尾

    if (!file.is_open()) {
        std::cerr << "无法打开文件: " << filename << std::endl;
        return;
    }
    file.write(reinterpret_cast<const char*>(buffer), size);
    file.close();
    return;
}

int littleEndianBytesToInt(const unsigned char* buffer) {
    if (buffer == nullptr) {
        return 0; // 或者抛出异常，根据你的需求
    }

    int result = 0;
    result |= (buffer[0] << 0);
    result |= (buffer[1] << 8);
    result |= (buffer[2] << 16);
    result |= (buffer[3] << 24);

    return result;
}

// 声明导入的函数
typedef unsigned char* (*Spine2Frames)(int width, int height, float fps,int size, unsigned char* buffer, int* out_size);

int main()
{

    // 加载DLL
    HMODULE hDll = LoadLibrary(L"SpineCSharp.dll");

    if (hDll == NULL) {
        std::cout << "Failed to load DLL" << std::endl;
        return 1;
    }

    // 获取函数指针
    Spine2Frames spine2Frames = (Spine2Frames)GetProcAddress(hDll, "SpineToFrames");

    if (spine2Frames == NULL) {
        std::cout << "Failed to get function address" << std::endl;
        FreeLibrary(hDll);
        return 1;
    }

	size_t atlasSize,skeSize,tex1Size,tex2Size,tex3Size,tex4Size,tex5Size,tex6Size,tex7Size,tex8Size,tex9Size;
    unsigned char* atlasBuffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton.atlas",atlasSize);
	unsigned char* skeBuffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton.json", skeSize);
    unsigned char* tex1Buffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton.png", tex1Size);
    unsigned char* tex2Buffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton2.png", tex2Size);
    unsigned char* tex3Buffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton3.png", tex3Size);
    unsigned char* tex4Buffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton4.png", tex4Size);
    unsigned char* tex5Buffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton5.png", tex5Size);
    unsigned char* tex6Buffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton6.png", tex6Size);
    unsigned char* tex7Buffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton7.png", tex7Size);
    //unsigned char* tex8Buffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton8.png", tex8Size);
    //unsigned char* tex9Buffer = readFileToUnsignedCharArray("D:\\developer\\system\\Downloads\\Spine\\skeleton9.png", tex9Size);
	unsigned char* buffer = new unsigned char[atlasSize + skeSize +tex1Size + tex2Size + tex3Size + tex4Size + tex5Size+tex6Size+tex7Size];
	
    size_t offset = 0;
    memcpy(buffer, atlasBuffer, atlasSize);offset += atlasSize;
    memcpy(buffer + offset, skeBuffer, skeSize);offset += skeSize;
    memcpy(buffer + offset, tex1Buffer, tex1Size);offset += tex1Size;
    memcpy(buffer + offset, tex2Buffer, tex2Size);offset += tex2Size;
    memcpy(buffer + offset, tex3Buffer, tex3Size);offset += tex3Size;
    memcpy(buffer + offset, tex4Buffer, tex4Size);offset += tex4Size;
    memcpy(buffer + offset, tex5Buffer, tex5Size);offset += tex5Size;
    memcpy(buffer + offset, tex6Buffer, tex6Size);offset += tex6Size;
    memcpy(buffer + offset, tex7Buffer, tex7Size);offset += tex7Size;
    //memcpy(buffer + offset, tex8Buffer, tex8Size);offset += tex8Size;
    //memcpy(buffer + offset, tex9Buffer, tex9Size);offset += tex9Size;
    //offset += tex5Size;
    int out_size;
    unsigned char* result =  spine2Frames(1024*2,1024*2,30,9,buffer,&out_size);

    
    for (size_t i = 0; i < out_size; i++)
    {
       auto size = littleEndianBytesToInt(result);
       std::cout << "file_size:" << size << std::endl;
       result += 4;
       std::string filename = "D:\\222\\frame_";
       filename.append(std::to_string(i));
       filename.append(".png");
       writeFileUnsignedCharArr(filename, result, size);
       result += size;
    }

    // 释放资源
    FreeLibrary(hDll);
    return 0;
}
