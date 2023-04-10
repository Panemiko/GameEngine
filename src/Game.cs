using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine;

namespace Platformer;

public class Game1 : EngineGame {
  protected Texture2D Tilemap;
  protected SpriteFont Font;

  public Game1() {
    DefaultBackgroundColor = Color.RoyalBlue;
  }

  protected override void LoadContent() {
    base.LoadContent();

    Tilemap = Content.Load<Texture2D>("tilemap");
    Font = Content.Load<SpriteFont>("font");

    var player = new Player(Tilemap);

    player.CreateEntity();
  }
}
