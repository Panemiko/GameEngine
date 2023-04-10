using System;
using System.Collections.Generic;

namespace Engine.Components;

public class DebugComponentUpdater {
  private Func<Entity, string> Updater;
  private DebugInfo DebugInfo;

  public DebugComponentUpdater(string name, Func<Entity, string> updater) {
    Updater = updater;
    DebugInfo = DebugInfoManager.Instance.CreateDebugInfo(name, "");
  }

  public void Handle(Entity entity) {
    DebugInfoManager.Instance.UpdateDebugInfo(
      DebugInfo.Id,
      Updater(entity)
    );
  }
}

public class DebugComponent : Component {
  public List<DebugComponentUpdater> DebugUpdaters;

  public DebugComponent(params DebugComponentUpdater[] debugUpdaters) {
    DebugUpdaters = new List<DebugComponentUpdater>();

    foreach (var debugUpdater in debugUpdaters) {
      DebugUpdaters.Add(debugUpdater);
    }
  }
}