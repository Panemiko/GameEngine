using System.Collections.Generic;

namespace Engine;

public class EntityManager {
  private static readonly EntityManager _instance = new EntityManager();
  public static EntityManager Instance {
    get {
      return _instance;
    }
  }

  private List<Entity> Entities;
  private int CurrentEntityId;

  private EntityManager() {
    Entities = new List<Entity>();
    CurrentEntityId = 0;
  }

  public Entity CreateEntity(params Component[] components) {
    var entity = new Entity(CurrentEntityId);

    foreach (var component in components) {
      entity.AddComponent(component);
      component.Entity = entity;
    }

    Entities.Add(entity);
    CurrentEntityId++;

    return entity;
  }

  public void RemoveEntity(Entity entity) {
    Entities.Remove(entity);
  }

  public List<Entity> GetEntitiesWithComponents<T1>()
    where T1 : Component {
    return Entities.FindAll(e => e.GetComponent<T1>() != null);
  }

  public List<Entity> GetEntitiesWithComponents<T1, T2>()
    where T1 : Component
    where T2 : Component {
    return Entities.FindAll(e =>
      e.GetComponent<T1>() != null
      && e.GetComponent<T2>() != null
    );
  }

  public List<Entity> GetEntitiesWithComponents<T1, T2, T3>()
    where T1 : Component
    where T2 : Component
    where T3 : Component {
    return Entities.FindAll(e =>
      e.GetComponent<T1>() != null
      && e.GetComponent<T2>() != null
      && e.GetComponent<T3>() != null
    );
  }
}
