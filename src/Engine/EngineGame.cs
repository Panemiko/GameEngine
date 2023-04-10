using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Components;

namespace Engine;

public class EngineGame : Game {
  protected GraphicsDeviceManager _graphics;
  protected SpriteBatch _spriteBatch;
  protected EntityManager EntityManager;
  protected Debug Debug;

  protected Color DefaultBackgroundColor;

  protected EngineGame() {
    _graphics = new GraphicsDeviceManager(this);
    EntityManager = EntityManager.Instance;
    Debug = Debug.Instance;

    Content.RootDirectory = "Content";
    DefaultBackgroundColor = Color.Black;

    IsMouseVisible = true;
  }

  protected override void LoadContent() {
    _spriteBatch = new SpriteBatch(GraphicsDevice);

    Debug.CreateDebugEntity(Content.Load<SpriteFont>("debug_font"));
  }

  protected override void Update(GameTime gameTime) {
    base.Update(gameTime);

    var inputEntities = EntityManager.GetEntitiesWithComponents<
      InputComponent
    >();

    foreach (var entity in inputEntities) {
      var input = entity.GetComponent<InputComponent>();

      var keyboardState = Keyboard.GetState();

      foreach (var inputEvent in input.InputEvents) {
        if (keyboardState.IsKeyDown(inputEvent.Key)) {
          inputEvent.Handler(entity);
        }
      }
    }

    var physicsEntities = EntityManager.GetEntitiesWithComponents<
      PhysicsComponent,
      GeometryComponent
    >();

    foreach (var entity in physicsEntities) {
      var geometry = entity.GetComponent<GeometryComponent>();
      var physics = entity.GetComponent<PhysicsComponent>();

      geometry.Position.X += physics.Velocity.X + physics.Gravity.X;
      geometry.Position.Y += physics.Velocity.Y + physics.Gravity.Y;
    }

    var debugEntities = EntityManager.GetEntitiesWithComponents<
      DebugComponent
    >();

    foreach (var entity in debugEntities) {
      var debug = entity.GetComponent<DebugComponent>();

      foreach (var debugUpdaters in debug.DebugUpdaters) {
        debugUpdaters.Handle(entity);
      }
    }

    // Resets the velocities
    foreach (var entity in physicsEntities) {
      var physics = entity.GetComponent<PhysicsComponent>();

      physics.Velocity = Vector2.Zero;
    }

    Debug.UpdateDebug();
  }

  protected override void Draw(GameTime gameTime) {
    GraphicsDevice.Clear(DefaultBackgroundColor);

    var spriteEntities = EntityManager.GetEntitiesWithComponents<
      SpriteComponent,
      GeometryComponent
    >();

    _spriteBatch.Begin();

    foreach (var entity in spriteEntities) {
      var sprite = entity.GetComponent<SpriteComponent>();
      var geometry = entity.GetComponent<GeometryComponent>();

      _spriteBatch.Draw(
        sprite.Tilemap,
        geometry.Position,
        sprite.TilemapCut,
        Color.White,
        geometry.Rotation,
        Vector2.Zero,
        geometry.Scale,
        SpriteEffects.None,
        0f
      );
    }

    _spriteBatch.End();

    var textEntities = EntityManager.GetEntitiesWithComponents<
      TextComponent,
      GeometryComponent
    >();

    _spriteBatch.Begin();

    foreach (var entity in textEntities) {
      var text = entity.GetComponent<TextComponent>();
      var geometry = entity.GetComponent<GeometryComponent>();

      _spriteBatch.DrawString(
        text.Font,
        text.Text,
        geometry.Position,
        text.Color,
        geometry.Rotation,
        Vector2.Zero,
        geometry.Scale,
        SpriteEffects.None,
        0f
      );
    }

    _spriteBatch.End();

    base.Draw(gameTime);
  }
}