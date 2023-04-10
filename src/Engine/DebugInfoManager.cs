using System.Collections.Generic;

namespace Engine;

public class DebugInfoManager {
  private static readonly DebugInfoManager _instance = new DebugInfoManager();
  public static DebugInfoManager Instance {
    get {
      return _instance;
    }
  }

  public List<DebugInfo> DebugInfos;
  private int CurrentDebugInfoId;

  private DebugInfoManager() {
    DebugInfos = new List<DebugInfo>();
    CurrentDebugInfoId = 0;
  }

  public DebugInfo CreateDebugInfo(string name, string value) {
    var debugInfo = new DebugInfo(CurrentDebugInfoId, name, value);

    DebugInfos.Add(debugInfo);
    CurrentDebugInfoId++;

    return debugInfo;
  }

  public DebugInfo UpdateDebugInfo(int id, string value) {
    var debugInfoToUpdate = DebugInfos.Find(
      (debugInfo) => { return (debugInfo.Id == id); }
    );

    DebugInfos.Remove(debugInfoToUpdate);

    var updatedDebugInfo = new DebugInfo(id, debugInfoToUpdate.Name, value);

    DebugInfos.Add(updatedDebugInfo);

    return updatedDebugInfo;
  }

  public void RemoveDebugInfo(DebugInfo debugInfo) {
    DebugInfos.Remove(debugInfo);
  }
}