namespace OpenGE.Core
{
    public class RenderComponent : Component
    {
        public string Texture { get; set; }

        public RenderComponent(string texture)
        {
            Texture = texture;
        }
    }
}