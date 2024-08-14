using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Media3D;

namespace OpenGE.Core
{
    public class Scene
    {
        public string Name { get; set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();

        public Scene(string name)
        {
            Name = name;
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        public void Load(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var sceneData = JsonConvert.DeserializeObject<Scene>(json);
                Name = sceneData.Name;
                Entities = sceneData.Entities;
            }
        }

        public void Save(string filePath)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}