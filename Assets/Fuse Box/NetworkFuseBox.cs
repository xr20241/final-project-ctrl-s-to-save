using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class NetworkFuseBox : NetworkBehaviour {
  public string VRSceneName;
  public string ARSceneName;

  void OnNetworkSpawn() {}

  public enum BoxSwitch { Blue, Red, Green }

  [Rpc(SendTo.Server)]
  public void SwitchSwitchedRpc(BoxSwitch boxSwitch) {
    if (IsServer) {
      SceneManager.SetActiveScene(SceneManager.GetSceneByName(VRSceneName));
      var targetObject = GameObject.Find("Cube_B");
      targetObject.transform.localScale = Vector3.one * 2f;
    }
  }
}
