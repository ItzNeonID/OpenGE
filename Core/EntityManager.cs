using System.Collections.Generic;

namespace OpenGE.Core
{
    public class EntityManager
    {
        private List<Entity> entities = new List<Entity>();

        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
        }

        public IEnumerable<Entity> GetEntities()
        {
            return entities;
        }
    }
}