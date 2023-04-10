using Engine;
using Engine.Components;
using Engine.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

public class Player : EntityTemplate {
  public DebugComponent DebugComponent;
  public GeometryComponent GeometryComponent;
  public InputComponent InputComponent;
  public PhysicsComponent PhysicsComponent;
  public SpriteComponent SpriteComponent;

  public float PlayerVelocity;

  public override Entity CreateEntity() {
    Entity = EntityManager.Instance.CreateEntity(
      DebugComponent,
      GeometryComponent,
      InputComponent,
      PhysicsComponent,
      SpriteComponent
    );

    return Entity;
  }

  public Player(Texture2D tilemap) {
    PlayerVelocity = 5;

    DebugComponent = new DebugComponent(
      new DebugComponentUpdater("playerPos",
      (e) => {
        var position = e.GetComponent<GeometryComponent>().Position;
        return $"{position.X} {position.Y}";
      }),

      new DebugComponentUpdater("playerVel",
      (e) => {
        var velocity = e.GetComponent<PhysicsComponent>().Velocity;
        return $"{velocity.X} {velocity.Y}";
      })
    );

    GeometryComponent = new GeometryComponent();

    InputComponent = new InputComponent(
      new InputEvent(Keys.W,
        (e) => {
          e.GetComponent<PhysicsComponent>().Velocity.Y += -PlayerVelocity;
        }
      ),

      new InputEvent(Keys.A,
        (e) => {
          e.GetComponent<PhysicsComponent>().Velocity.X += -PlayerVelocity;
        }
      ),

      new InputEvent(Keys.S,
        (e) => {
          e.GetComponent<PhysicsComponent>().Velocity.Y += PlayerVelocity;
        }
      ),

      new InputEvent(Keys.D,
        (e) => {
          e.GetComponent<PhysicsComponent>().Velocity.X += PlayerVelocity;
        }
      )
    );

    PhysicsComponent = new PhysicsComponent();

    SpriteComponent = new SpriteComponent(tilemap, new Rectangle(0, 0, 32, 32));
  }
}