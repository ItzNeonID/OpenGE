using System.Windows.Media.Media3D;

namespace OpenGE.Core
{
    public class Entity
    {
        public string Name { get; set; }
        public Point3D Position { get; set; }
        public double Size { get; set; }
        public Geometry3D Geometry { get; set; }

        public Entity()
        {
        }

        public Entity(string name, Point3D position, double size)
        {
            Name = name;
            Position = position;
            Size = size;
        }
    }
}