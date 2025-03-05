using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Collections;
using System.Collections.ObjectModel;
using SFML.System;
using SFML.Window;
using System.ComponentModel;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using SpineViewer.Spine.Implementations;

namespace SpineViewer.Spine
{

    public abstract class Spine : SFML.Graphics.Drawable, IDisposable
    {
       

        /// <summary>
        /// 用于解决 PMA 和渐变动画问题的片段着色器
        /// </summary>
        private const string FRAGMENT_SHADER = (
            "uniform sampler2D t;" +
            "void main() { vec4 p = texture2D(t, gl_TexCoord[0].xy);" +
            "if (p.a > 0) p.rgb /= max(max(max(p.r, p.g), p.b), p.a);" +
            "gl_FragColor = gl_Color * p; }"
        );

        /// <summary>
        /// 用于解决 PMA 和渐变动画问题的片段着色器
        /// </summary>
        protected static readonly SFML.Graphics.Shader FragmentShader = null;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static Spine()
        {
       
           
            // 加载 FragmentShader
            try
            {
                FragmentShader = SFML.Graphics.Shader.FromString(null, null, FRAGMENT_SHADER);
            }
            catch (Exception ex)
            {
              
                FragmentShader = null;
            }
        }

        public static Spine New( string skelPath, string atlasPath = null)
        {
            return new Spine36(skelPath, atlasPath);
        }

        public static Spine New(TextReader skelReader,TextReader atlasReader,SpineRuntime36.TextureLoader textureLoader)
        {
            return new Spine36(skelReader, atlasReader,textureLoader);
        }


        ~Spine() { Dispose(false); }
        public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }
        protected virtual void Dispose(bool disposing) { }

       
        public const float SCALE_MIN = 0.001f;

        public abstract System.Drawing.PointF Position { get; set; }

        public abstract bool FlipX { get; set; }

        public abstract bool FlipY { get; set; }

        public abstract string CurrentAnimation { get; set; }


        public abstract RectangleF Bounds { get; }

        public abstract float GetAnimationDuration(string name);

        public abstract void Update(float delta);

        protected float[] worldVerticesBuffer = new float[1024];

        protected SFML.Graphics.VertexArray vertexArray = new SFML.Graphics.VertexArray (SFML.Graphics.PrimitiveType.Triangles);

        public abstract void Draw(SFML.Graphics.RenderTarget target, SFML.Graphics.RenderStates states);
    }
}
