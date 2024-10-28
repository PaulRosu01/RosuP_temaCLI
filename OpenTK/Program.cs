using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.IO;

namespace OpenTK
{
    class ImmediateMode : GameWindow
    {
        private Color[] triangleColors;
        private Vector3[] triangleVertices;
        private float cameraAngleX = 0.0f;
        private float cameraAngleY = 0.0f;

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
            LoadTriangleData("triangle.txt");
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
        private float previousMouseX;
        private float previousMouseY;

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard[Key.R])
                ChangeColor(0); // Modifica culoarea R
            if (keyboard[Key.G])
                ChangeColor(1); // Modifica culoarea G
            if (keyboard[Key.B])
                ChangeColor(2); // Modifica culoarea B

            MouseState mouse = Mouse.GetState();
            if (mouse.IsButtonDown(MouseButton.Left))
            {
                float deltaX = mouse.X - previousMouseX;
                float deltaY = mouse.Y - previousMouseY;

                cameraAngleX += deltaX * 0.1f;
                cameraAngleY += deltaY * 0.1f;
            }

            previousMouseX = mouse.X;
            previousMouseY = mouse.Y;
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Rotate(cameraAngleY, 1.0f, 0.0f, 0.0f);
            GL.Rotate(cameraAngleX, 0.0f, 1.0f, 0.0f);
            GL.Translate(0, 0, -5); // Muta triunghiul in fata

            DrawTriangle();

            SwapBuffers();
        }

        private void LoadTriangleData(string filePath)
        {
            triangleVertices = new Vector3[3];
            triangleColors = new Color[3];

            // Exemplu de incarcare a datelor dintr-un fisier text
            using (StreamReader reader = new StreamReader(filePath))
            {
                for (int i = 0; i < 3; i++)
                {
                    string[] line = reader.ReadLine().Split(',');
                    triangleVertices[i] = new Vector3(float.Parse(line[0]), float.Parse(line[1]), float.Parse(line[2]));
                    triangleColors[i] = Color.FromArgb(255, 255, 255); // Initial, alb
                }
            }
        }

        private void DrawTriangle()
        {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 3; i++)
            {
                GL.Color3(triangleColors[i]);
                GL.Vertex3(triangleVertices[i]);
                Console.WriteLine($"Vertex {i}: R={triangleColors[i].R}, G={triangleColors[i].G}, B={triangleColors[i].B}");
            }
            GL.End();
        }

        private void ChangeColor(int channel)
        {
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                int value = rand.Next(256);
                Color color = triangleColors[i];

                if (channel == 0) // Red
                    triangleColors[i] = Color.FromArgb(color.A, value, color.G, color.B);
                else if (channel == 1) // Green
                    triangleColors[i] = Color.FromArgb(color.A, color.R, value, color.B);
                else if (channel == 2) // Blue
                    triangleColors[i] = Color.FromArgb(color.A, color.R, color.G, value);
            }
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
