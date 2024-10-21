using System;
using System.Drawing;
using System.Security.Policy;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK
{
    class ImmediateMode : GameWindow
    {
        private Color cubeColor = Color.White;

        public ImmediateMode() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            Console.WriteLine("OpenGL versiunea: " + GL.GetString(StringName.Version));
            Title = "OpenGL versiunea: " + GL.GetString(StringName.Version) + " (mod imediat)";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 100);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard[Key.Left] || keyboard[Key.Right])
                ChangeColor();

            MouseState mouse = Mouse.GetState();
            if (mouse.IsButtonDown(MouseButton.Left))
            {
                ChangeColor();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0, 0, -5); // Muta cubul în față

            DrawCube();

            SwapBuffers();
        }

        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(cubeColor);
            GL.Vertex3(-1, -1, -1);
            GL.Vertex3(1, -1, -1);
            GL.Vertex3(1, 1, -1);
            GL.Vertex3(-1, 1, -1);
            GL.Vertex3(-1, -1, 1);
            GL.Vertex3(1, -1, 1);
            GL.Vertex3(1, 1, 1);
            GL.Vertex3(-1, 1, 1);
            GL.End();
        }

        private void ChangeColor()
        {
            Random rand = new Random();
            cubeColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (ImmediateMode example = new ImmediateMode())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
