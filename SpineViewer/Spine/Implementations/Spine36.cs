using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SFML.Graphics;
using SpineRuntime36;

namespace SpineViewer.Spine.Implementations
{
    public class ByteTextureLoader : SpineRuntime36.TextureLoader
    {
        private Queue<byte[]> dataList = new Queue<byte[]>();

        public void push(byte[] data)
        {
            dataList.Enqueue(data);
        }

        public void Load(AtlasPage page, string path)
        {
            var texture = new SFML.Graphics.Texture(dataList.Dequeue());
            if (page.magFilter == TextureFilter.Linear)
                texture.Smooth = true;
            if (page.uWrap == TextureWrap.Repeat && page.vWrap == TextureWrap.Repeat)
                texture.Repeated = true;

            page.rendererObject = texture;
            page.width = (int)texture.Size.X;
            page.height = (int)texture.Size.Y;
        }

        public void Unload(object texture)
        {
            ((SFML.Graphics.Texture)texture).Dispose();
           
        }
    }

    class Spine36 : Spine
    {
        private class TextureLoader : SpineRuntime36.TextureLoader
        {
            public void Load(AtlasPage page, string path)
            {
                var texture = new SFML.Graphics.Texture(path);
                if (page.magFilter == TextureFilter.Linear)
                    texture.Smooth = true;
                if (page.uWrap == TextureWrap.Repeat && page.vWrap == TextureWrap.Repeat)
                    texture.Repeated = true;

                page.rendererObject = texture;
                page.width = (int)texture.Size.X;
                page.height = (int)texture.Size.Y;
            }

            public void Unload(object texture)
            {
                ((SFML.Graphics.Texture)texture).Dispose();
            }
        }
        private static TextureLoader textureLoader = new TextureLoader();

        private Atlas atlas;
        private SkeletonBinary skeletonBinary;
        private SkeletonJson skeletonJson;
        private SkeletonData skeletonData;
        private AnimationStateData animationStateData;

        private Skeleton skeleton;
        private AnimationState animationState;

        private SkeletonClipping clipping = new SkeletonClipping();

        public Spine36(string skelPath, string atlasPath) 
        {
            atlas = new Atlas(atlasPath, textureLoader);
            if (Path.GetExtension(skelPath) == ".skel")
            {
                skeletonJson = null;
                skeletonBinary = new SkeletonBinary(atlas);
                skeletonData = skeletonBinary.ReadSkeletonData(skelPath);
            }
            else if (Path.GetExtension(skelPath) == ".json")
            {
                skeletonBinary = null;
                skeletonJson = new SkeletonJson(atlas);
                skeletonData = skeletonJson.ReadSkeletonData(skelPath);
            }
            else
            {
                throw new ArgumentException($"Unknown skeleton file format {skelPath}");
            }
            animationStateData = new AnimationStateData(skeletonData);
            skeleton = new Skeleton(skeletonData);
            animationState = new AnimationState(animationStateData);

        }

        public Spine36(TextReader skelReader, TextReader atlasReader,SpineRuntime36.TextureLoader textureLoader)
        {
            atlas = new Atlas(atlasReader,"",textureLoader);
            skeletonBinary = null;
            skeletonJson = new SkeletonJson(atlas);
            skeletonData = skeletonJson.ReadSkeletonData(skelReader);
            animationStateData = new AnimationStateData(skeletonData);
            skeleton = new Skeleton(skeletonData);
            animationState = new AnimationState(animationStateData);
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            atlas.Dispose();
        }


        public override  System.Drawing. PointF Position 
        { 
            get => new System.Drawing.PointF(skeleton.X, skeleton.Y); 
            set 
            { 
                skeleton.X = value.X; 
                skeleton.Y = value.Y; 
            } 
        }

        public override bool FlipX
        {
            get => skeleton.FlipX;
            set => skeleton.FlipX = value;
        }

        public override bool FlipY
        {
            get => skeleton.FlipY;
            set => skeleton.FlipY = value;
        }

        public override System.Drawing. RectangleF Bounds
        {
            get
            {
                float[] _ =  new float[0];
                skeleton.GetBounds(out var x, out var y, out var w, out var h, ref _);
                return new System.Drawing. RectangleF(x, y, w, h);
            }
        }
        public override string CurrentAnimation
        {
            get => animationState.GetCurrent(0)?.Animation.Name ?? "";
            set {  animationState.SetAnimation(0, value, true); Update(0);  }
        }

        public override float GetAnimationDuration(string name) { return skeletonData.FindAnimation(name)?.Duration ?? 0f; }

        public override void Update(float delta)
        {
            skeleton.Update(delta);
            animationState.Update(delta);
            animationState.Apply(skeleton);
            skeleton.UpdateWorldTransform();
        }

        private SFML.Graphics.BlendMode GetSFMLBlendMode(SpineRuntime36.BlendMode spineBlendMode)
        {
            if(spineBlendMode == SpineRuntime36.BlendMode.Normal)
            {
                return BlendMode.Normal;
            }
            else if (spineBlendMode == SpineRuntime36.BlendMode.Additive)
            {
                return BlendMode.Additive;
            }
            else if (spineBlendMode == SpineRuntime36.BlendMode.Multiply)
            {
                return BlendMode.Multiply;
            }
            else if (spineBlendMode == SpineRuntime36.BlendMode.Screen)
            {
                return BlendMode.Screen;
            }
            else
            {
                throw new NotImplementedException($"{spineBlendMode}");
            }
          
        }

        public override void Draw(SFML.Graphics.RenderTarget target, SFML.Graphics.RenderStates states)
        {
            vertexArray.Clear();
            states.Texture = null;

            // 要用 DrawOrder 而不是 Slots
            foreach (var slot in skeleton.DrawOrder)
            {
                var attachment = slot.Attachment;

                SFML.Graphics.Texture texture;

                float[] worldVertices = worldVerticesBuffer;    // 顶点世界坐标, 连续的 [x0, y0, x1, y1, ...] 坐标值
                int worldVerticesCount;                         // 等于顶点数组的长度除以 2
                int[] worldTriangleIndices;                     // 三角形索引, 从顶点坐标数组取的时候要乘以 2, 最大值是 worldVerticesCount - 1
                int worldTriangleIndicesLength;                 // 三角形索引数组长度
                float[] uvs;                                    // 纹理坐标
                float tintR = skeleton.R * slot.R;
                float tintG = skeleton.G * slot.G;
                float tintB = skeleton.B * slot.B;
                float tintA = skeleton.A * slot.A;

                if (attachment is RegionAttachment regionAttachment)
                {
                    texture = (SFML.Graphics.Texture)((AtlasRegion)regionAttachment.RendererObject).page.rendererObject;

                    regionAttachment.ComputeWorldVertices(slot.Bone, worldVertices, 0);
                    worldVerticesCount = 4;
                    worldTriangleIndices = new int[] { 0, 1, 2, 2, 3, 0 };
                    worldTriangleIndicesLength = 6;
                    uvs = regionAttachment.UVs;
                    tintR *= regionAttachment.R;
                    tintG *= regionAttachment.G;
                    tintB *= regionAttachment.B;
                    tintA *= regionAttachment.A;
                }
                else if (attachment is MeshAttachment meshAttachment)
                {
                    texture = (SFML.Graphics.Texture)((AtlasRegion)meshAttachment.RendererObject).page.rendererObject;

                    if (meshAttachment.WorldVerticesLength > worldVertices.Length)
                        worldVertices = worldVerticesBuffer = new float[meshAttachment.WorldVerticesLength * 2];
                    meshAttachment.ComputeWorldVertices(slot, worldVertices);
                    worldVerticesCount = meshAttachment.WorldVerticesLength / 2;
                    worldTriangleIndices = meshAttachment.Triangles;
                    worldTriangleIndicesLength = meshAttachment.Triangles.Length;
                    uvs = meshAttachment.UVs;
                    tintR *= meshAttachment.R;
                    tintG *= meshAttachment.G;
                    tintB *= meshAttachment.B;
                    tintA *= meshAttachment.A;
                }
                else if (attachment is ClippingAttachment clippingAttachment)
                {
                    clipping.ClipStart(slot, clippingAttachment);
                    continue;
                }
                else
                {
                    clipping.ClipEnd(slot);
                    continue;
                }

                SFML.Graphics.BlendMode blendMode = GetSFMLBlendMode(slot.Data.BlendMode);

                //states.Texture ??= texture;
                states.Texture = states.Texture ?? texture;
                if (states.BlendMode != blendMode || states.Texture != texture)
                {
                    if (vertexArray.VertexCount > 0)
                    {
                        if (true && (states.BlendMode == BlendMode.Normal || states.BlendMode == BlendMode.Additive))
                            states.Shader = FragmentShader;
                        else
                            states.Shader = null;
                        target.Draw(vertexArray, states);
                        vertexArray.Clear();
                    }
                    states.BlendMode = blendMode;
                    states.Texture = texture;
                }

                if (clipping.IsClipping)
                {
                    // 这里必须单独记录 Count, 和 Items 的 Length 是不一致的
                    clipping.ClipTriangles(worldVertices, worldVerticesCount * 2, worldTriangleIndices, worldTriangleIndicesLength, uvs);
                    worldVertices = clipping.ClippedVertices.Items;
                    worldVerticesCount = clipping.ClippedVertices.Count / 2;
                    worldTriangleIndices = clipping.ClippedTriangles.Items;
                    worldTriangleIndicesLength = clipping.ClippedTriangles.Count;
                    uvs = clipping.ClippedUVs.Items;
                }

                var textureSizeX = texture.Size.X;
                var textureSizeY = texture.Size.Y;

                SFML.Graphics.Vertex vertex = new SFML.Graphics.Vertex();
                vertex.Color.R = (byte)(tintR * 255);
                vertex.Color.G = (byte)(tintG * 255);
                vertex.Color.B = (byte)(tintB * 255);
                vertex.Color.A = (byte)(tintA * 255);

                // 必须用 worldTriangleIndicesLength 不能直接 foreach
                for (int i = 0; i < worldTriangleIndicesLength; i++)
                {
                    var index = worldTriangleIndices[i] * 2;
                    vertex.Position.X = worldVertices[index];
                    vertex.Position.Y = worldVertices[index + 1];
                    vertex.TexCoords.X = uvs[index] * textureSizeX;
                    vertex.TexCoords.Y = uvs[index + 1] * textureSizeY;
                    vertexArray.Append(vertex);
                }

                clipping.ClipEnd(slot);
            }

            if (true && (states.BlendMode == BlendMode.Normal || states.BlendMode == BlendMode.Additive))
                states.Shader = FragmentShader;
            else
                states.Shader = null;
            target.Draw(vertexArray, states);
            clipping.ClipEnd();
        }
    }
}
