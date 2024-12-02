using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRNetworkManager : MonoBehaviour {
  private static NetworkManager m_NetworkManager;
  void Awake() { m_NetworkManager = GetComponent<NetworkManager>(); }

  public static void ChangeScene() {
    var prevScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene("Piano", LoadSceneMode.Single);
    SceneManager.UnloadSceneAsync(prevScene);
    m_NetworkManager.StartClient();
  }
}
