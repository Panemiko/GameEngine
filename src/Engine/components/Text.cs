using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Engine.Components;

public class TextComponent : Component {
  public string Text;
  public SpriteFont Font;
  public Color Color;

  public TextComponent(string text, SpriteFont font, Color color) {
    Text = text;
    Font = font;
    Color = color;
  }

  public TextComponent(string text, SpriteFont font) {
    Text = text;
    Font = font;
    Color = Color.Black;
  }
}
