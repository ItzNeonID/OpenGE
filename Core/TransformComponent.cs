namespace OpenGE.Core
{
    public class TransformComponent : Component
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; } = 1.0f;

        public TransformComponent(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}