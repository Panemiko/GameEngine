using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Engine.Components;

namespace Engine;

public class Debug {
  private static readonly Debug _instance = new Debug();
  public static Debug Instance {
    get {
      return _instance;
    }
  }

  private DebugInfoManager DebugInfoManager;

  private Entity Entity;
  private string Text;

  private Debug() {
    DebugInfoManager = DebugInfoManager.Instance;
    Text = "";
  }

  private void ClearDebug() {
    Text = "";
  }

  public void UpdateDebug() {
    ClearDebug();

    foreach (var debugInfo in DebugInfoManager.DebugInfos) {
      Text += $"{debugInfo.Name}: {debugInfo.Value}\n";
    }

    Entity.GetComponent<TextComponent>().Text = Text;
  }

  public void CreateDebugEntity(SpriteFont font) {
    Entity = EntityManager.Instance.CreateEntity(
      new GeometryComponent(),
      new TextComponent(Text, font, Color.DarkGray)
    );
  }
}