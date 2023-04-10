using Microsoft.Xna.Framework;

namespace Engine.Components;

public class PhysicsComponent : Component {
  public Vector2 Velocity;
  public Vector2 Gravity;

  public PhysicsComponent(Vector2 velocity, Vector2 gravity) {
    Velocity = velocity;
    Gravity = gravity;
  }

  public PhysicsComponent() {
    Velocity = Vector2.Zero;
    Gravity = Vector2.Zero;
  }
}