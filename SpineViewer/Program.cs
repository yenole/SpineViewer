using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using SFML.Graphics;
using SpineViewer.Spine.Implementations;


namespace SpineViewer
{

    public class Spine2Freme
    {
        [DllExport]
        public static IntPtr SpineToFrames(int width,int height,float fps,int size,IntPtr buffer,IntPtr out_size)
        {
            var offset = 0;
            var list = new Queue<byte[]>();
            for (int i = 0; i < size; i++)
            {
                var bytes = new byte[4];
                Marshal.Copy(buffer+offset, bytes, 0, 4);
                offset += 4;
                var fileSize = bytes2int(bytes);
                bytes = new byte[fileSize];
                Marshal.Copy(buffer+offset,bytes, 0, fileSize);
                list.Enqueue(bytes);
                offset += fileSize;
            }
            var atlas = list.Dequeue();
            var skel =  list.Dequeue();
            var textures = new List<byte[]>();
            size = list.Count;
            for (int i = 0; i < size; i++)
            {
                textures.Add(list.Dequeue());
            }
            var frames = Spine2Freme.Spine2Frame(skel, atlas, textures, "animation", width,height,fps);
            var buffers2 = new MemoryStream();
            var outSizeBytes = int2bytes(frames.Count);
            Marshal.Copy(outSizeBytes, 0, out_size, 4);
            for (int i = 0; i < frames.Count;i++)
            {
                var frame = frames[i];
                buffers2.Write(int2bytes(frames[i].Length), 0, 4);
                buffers2.Write(frame, 0, frame.Length);
            }
            var rstBytes = buffers2.ToArray();
            IntPtr ptr = Marshal.AllocHGlobal(rstBytes.Length);
            Marshal.Copy(rstBytes, 0, ptr, rstBytes.Length);
            return ptr;
        }

        private static int bytes2int(byte[] bytes)
        {
            var value = 0;
            value |= bytes[0] << 0;
            value |= bytes[1] << 8;
            value |= bytes[2] << 16;
            value |= bytes[3] << 24;
            return value;
        }

        private static byte[] int2bytes(int value)
        {
            byte[] bytes = new byte[4];
            bytes[0] = (byte)(value & 0xFF);        
            bytes[1] = (byte)((value >> 8) & 0xFF);     
            bytes[2] = (byte)((value >> 16) & 0xFF);    
            bytes[3] = (byte)((value >> 24) & 0xFF);    
            return bytes;
        }

        public static List<byte[]> Spine2Frame(byte[] skel, byte[] atlas, List<byte[]> textures,string animation,int width,int height,float fps = 1f)
        {
            TextReader skeReader = new StreamReader(new MemoryStream(skel));
            TextReader atlasReader = new StreamReader(new MemoryStream(atlas));
            ByteTextureLoader loader = new ByteTextureLoader();
            textures.ForEach(t => loader.push(t));

            var spine = Spine.Spine.New(skeReader, atlasReader, loader);
            spine.FlipY = true;
            spine.Position = new System.Drawing.PointF(0,height/4);
            spine.CurrentAnimation = animation;

            var tex = new RenderTexture((uint)width,(uint)height);

            View view = new View();
            view.Size = new SFML.System.Vector2f(width, height);
            view.Center = new SFML.System.Vector2f(width/2,height/2);
            tex.SetView(view);

            var delta = 1f / fps;
            var frameCount = 1 + (int)(spine.GetAnimationDuration(animation) / delta); // ��֡��ʼ����
            var timestamp = System.DateTime.Now.ToString("yyMMddHHmmss");

            var list = new List<byte[]>();
            lock (spine)
            {
                for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                {

                    tex.Clear(SFML.Graphics.Color.Transparent);
                    tex.Draw(spine);
                    spine.Update(delta);

                    tex.Display();
                    using (var img = tex.Texture.CopyToImage())
                    {
                        // SaveMemeory报错
                        var file = Path.GetTempPath()+ "\\" + timestamp + "_" + frameIndex + ".png";
                         if (img.SaveToFile(file))
                        {
                            list.Add(File.ReadAllBytes(file));
                            File.Delete(file);
                        }
                      
                    }
                }
            }
            return list;
        }
    }
}