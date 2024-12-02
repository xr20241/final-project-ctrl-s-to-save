using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class PlayerSpawning : MonoBehaviour {
  public GameObject ARPlayerPrefab;
  public GameObject VRPlayerPrefab;
  public string VRSceneName;
  public string ARSceneName;
  private NetworkManager m_NetworkManager;

  void Awake() { m_NetworkManager = GetComponent<NetworkManager>(); }

  public void StartServer() {
    m_NetworkManager.StartServer();
    SceneManager.LoadScene(VRSceneName, LoadSceneMode.Additive);
    SceneManager.LoadScene(ARSceneName, LoadSceneMode.Additive);
    // GetIDs();
  }

  public void StartVR() {
    m_NetworkManager.StartClient();
    // VRClientID = NetworkManager.Singleton.LocalClientId;
    //  Get the current scene name
    SceneManager.LoadScene(VRSceneName, LoadSceneMode.Additive);
    SceneManager.sceneLoaded += SetActiveVR;

    // SceneManager.UnloadSceneAsync(currentSceneName);
  }

  public async void StartAR() {
    m_NetworkManager.StartClient();
    // ARClientID = NetworkManager.Singleton.LocalClientId;
    //  Get the current scene name
    SceneManager.LoadScene(ARSceneName, LoadSceneMode.Single);
    // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    SceneManager.sceneLoaded += SetActiveAR;

    // SceneManager.UnloadSceneAsync(currentSceneName);
  }

  void SetActiveAR(Scene scene, LoadSceneMode mode) {
    SceneManager.SetActiveScene(scene);
    SpawnPlayerObject(ARPlayerPrefab);
  }

  void SetActiveVR(Scene scene, LoadSceneMode mode) {
    SceneManager.SetActiveScene(scene);
    SpawnPlayerObject(VRPlayerPrefab);
  }

  void SpawnPlayerObject(GameObject playerPrefab) {
    var objInstance = Instantiate(playerPrefab);
    objInstance.GetComponent<NetworkObject>().SpawnAsPlayerObject(
        NetworkManager.Singleton.LocalClientId);
  }
}
