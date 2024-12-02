using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class ARNetworkManager : MonoBehaviour {
  private static NetworkManager m_NetworkManager;
  void Awake() { m_NetworkManager = GetComponent<NetworkManager>(); }
  public static void ChangeScene() {
    var prevScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene("ARScene", LoadSceneMode.Additive);
    // SceneManager.UnloadSceneAsync(prevScene);
    m_NetworkManager.StartHost();
  }
}
