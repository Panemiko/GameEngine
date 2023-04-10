using Microsoft.Xna.Framework.Input;
using System;

namespace Engine.Events;

public class InputEvent {
  public Keys Key;
  public Action<Entity> Handler;

  public InputEvent(Keys key, Action<Entity> handler) {
    Key = key;
    Handler = handler;
  }
}