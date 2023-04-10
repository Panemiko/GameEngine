namespace Engine;

public class EntityTemplate {
  public Entity Entity;

  public virtual Entity CreateEntity() {
    return EntityManager.Instance.CreateEntity();
  }
}