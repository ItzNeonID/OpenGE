using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGE.Engine
{
    public class Renderer
    {
        public void Initialize()
        {
            // Set up OpenGL settings, e.g., clear color
            GL.ClearColor(System.Drawing.Color.CornflowerBlue);
        }

        public void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Add rendering logic here
        }
    }
}