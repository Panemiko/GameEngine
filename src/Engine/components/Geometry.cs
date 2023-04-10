using Microsoft.Xna.Framework;

namespace Engine.Components;

public class GeometryComponent : Component {
  public Vector2 Position;
  public Vector2 Scale;
  public float Rotation;

  public GeometryComponent(Vector2 position, Vector2 scale, float rotation) {
    Position = position;
    Scale = scale;
    Rotation = rotation;
  }

  public GeometryComponent(Vector2 position) {
    Position = position;
    Scale = Vector2.One;
    Rotation = 0;
  }

  public GeometryComponent() {
    Position = Vector2.Zero;
    Scale = Vector2.One;
    Rotation = 0;
  }
}