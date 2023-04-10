using System.Collections.Generic;
using Engine.Events;

namespace Engine.Components;

public class InputComponent : Component {
  public List<InputEvent> InputEvents;

  public InputComponent(params InputEvent[] inputEvents) {
    InputEvents = new List<InputEvent>();

    foreach (var inputEvent in inputEvents) {
      InputEvents.Add(inputEvent);
    }
  }
}
