using System.Collections.Generic;

namespace Engine;

public class Entity {
  public int Id;
  public List<Component> Components;

  public Entity(int id) {
    Id = id;
    Components = new List<Component>();
  }

  public Entity AddComponent(Component component) {
    Components.Add(component);
    return this;
  }

  public T GetComponent<T>() where T : Component {
    foreach (var component in Components) {
      if (component is T tComponent)
        return tComponent;
    }

    return null;
  }
}