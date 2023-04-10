using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Components;

public class SpriteComponent : Component {
  public Texture2D Tilemap;
  public Rectangle TilemapCut;

  public SpriteComponent(Texture2D tilemap, Rectangle tilemapCut) {
    Tilemap = tilemap;
    TilemapCut = tilemapCut;
  }
}