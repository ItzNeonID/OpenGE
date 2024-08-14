using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace OpenGE.Core
{
    public abstract class SceneObject
    {
        public string Name { get; set; }
        public Point3D Position { get; set; }
        public abstract Geometry3D CreateGeometry();
    }

    public class CubeObject : SceneObject
    {
        public double Size { get; set; }

        public override Geometry3D CreateGeometry()
        {
            var mesh = new MeshGeometry3D();
            var size = Size / 2;

            // Define the 8 corners of the cube
            var corners = new Point3DCollection
            {
                new Point3D(-size, -size, -size),
                new Point3D(size, -size, -size),
                new Point3D(size, size, -size),
                new Point3D(-size, size, -size),
                new Point3D(-size, -size, size),
                new Point3D(size, -size, size),
                new Point3D(size, size, size),
                new Point3D(-size, size, size),
            };

            mesh.Positions = corners;

            // Define the 12 triangles of the cube
            mesh.TriangleIndices = new Int32Collection
            {
                0, 1, 2, 0, 2, 3, // Front
                4, 5, 6, 4, 6, 7, // Back
                0, 1, 5, 0, 5, 4, // Bottom
                2, 3, 7, 2, 7, 6, // Top
                0, 3, 7, 0, 7, 4, // Left
                1, 2, 6, 1, 6, 5  // Right
            };

            return mesh;
        }
    }
}