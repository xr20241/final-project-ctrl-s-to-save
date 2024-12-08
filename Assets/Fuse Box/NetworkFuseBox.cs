using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class NetworkFuseBox : NetworkBehaviour {
  public string VRSceneName;
  public string ARSceneName;

  public enum BoxSwitch { Blue, Red, Green }

  public void Log() { Debug.Log("Pressed"); }

  [Rpc(SendTo.Server)]
  public void ASwitchSwitchedRpc() {
    if (IsServer) {
      Debug.Log("AH AH");
      SceneManager.SetActiveScene(SceneManager.GetSceneByName(VRSceneName));
      var targetObject = GameObject.Find("Cube_B");
      targetObject.transform.localScale = Vector3.one * 2f;
    }
  }
}
