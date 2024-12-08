using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class PlayerSpawning : MonoBehaviour {
  public GameObject ARPlayerPrefab;
  public GameObject VRPlayerPrefab;
  public string VRSceneName;
  public string ARSceneName;
  private NetworkManager m_NetworkManager;
  private int connectedClientsCount = 0;
  private List<GameObject> ARPrefabs = new List<GameObject>();
  private List<GameObject> VRPrefabs = new List<GameObject>();

  void Awake() {
    m_NetworkManager = GetComponent<NetworkManager>();
    SceneManager.LoadScene(VRSceneName, LoadSceneMode.Additive);
    SceneManager.LoadScene(ARSceneName, LoadSceneMode.Additive);
  }

  public void StartServer() {
    m_NetworkManager.StartServer();
    // SceneManager.LoadScene(VRSceneName, LoadSceneMode.Additive);
    // SceneManager.LoadScene(ARSceneName, LoadSceneMode.Additive);
    NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
    var allPrefabs = NetworkManager.Singleton.NetworkConfig.Prefabs.Prefabs;
    Debug.Log(allPrefabs);

    foreach (var prefab in allPrefabs) {
      if (prefab.Prefab.name.StartsWith("AR_")) {
        ARPrefabs.Add(prefab.Prefab);
      } else if (prefab.Prefab.name.StartsWith("VR_")) {
        VRPrefabs.Add(prefab.Prefab);
      }
    }
    SceneManager.SetActiveScene(SceneManager.GetSceneByName(VRSceneName));
    foreach (var prefab in VRPrefabs) {

      var objInstance = Instantiate(prefab);
      objInstance.GetComponent<NetworkObject>().Spawn();
      Debug.Log($"Found AR Prefab: {prefab.name}");
    }
    SceneManager.SetActiveScene(SceneManager.GetSceneByName(ARSceneName));
    foreach (var prefab in ARPrefabs) {

      var objInstance = Instantiate(prefab);
      objInstance.GetComponent<NetworkObject>().Spawn();
      Debug.Log($"Found AR Prefab: {prefab.name}");
    }

    // SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainMenu"));
    //  GetIDs();
  }

  void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    if (scene.name == VRSceneName) {
      SceneManager.SetActiveScene(SceneManager.GetSceneByName(VRSceneName));
      foreach (var prefab in VRPrefabs) {

        var objInstance = Instantiate(prefab);
        objInstance.GetComponent<NetworkObject>().Spawn(false);
        Debug.Log($"Found AR Prefab: {prefab.name}");
      }

    } else if (scene.name == ARSceneName) {
      SceneManager.SetActiveScene(SceneManager.GetSceneByName(ARSceneName));
      foreach (var prefab in ARPrefabs) {

        var objInstance = Instantiate(prefab);
        objInstance.GetComponent<NetworkObject>().Spawn(false);
        Debug.Log($"Found AR Prefab: {prefab.name}");
      }
    }
  }

  public void StartVR() {
    m_NetworkManager.StartClient();
    // VRClientID = NetworkManager.Singleton.LocalClientId;
    //  Get the current scene name
    SceneManager.LoadScene(VRSceneName, LoadSceneMode.Single);

    // SceneManager.UnloadSceneAsync(currentSceneName);
  }

  public void StartAR() {
    m_NetworkManager.StartClient();
    // ARClientID = NetworkManager.Singleton.LocalClientId;
    //  Get the current scene name
    SceneManager.LoadScene(ARSceneName, LoadSceneMode.Single);
    // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    // SceneManager.sceneLoaded += SetActiveAR;

    // SceneManager.UnloadSceneAsync(currentSceneName);
  }

  void SpawnPlayerObject(string scene, GameObject playerPrefab,
                         ulong clientId) {
    SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
    Debug.Log("Server spawning");
    Debug.Log(SceneManager.GetActiveScene().name);
    Debug.Log(clientId);
    var objInstance = Instantiate(playerPrefab);
    objInstance.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
  }

  void HandleClientConnected(ulong clientId) {
    // Only the server should spawn players
    if (!NetworkManager.Singleton.IsServer)
      return;

    // Increment connected clients count
    connectedClientsCount++;

    GameObject playerPrefab = null;
    string targetSceneName = "";

    // Spawn different players based on connection order
    switch (connectedClientsCount) {
    case 2:
      playerPrefab = ARPlayerPrefab;
      targetSceneName = ARSceneName;
      break;
    case 1:
      playerPrefab = VRPlayerPrefab;
      targetSceneName = VRSceneName;
      break;
    default:
      Debug.Log("Maximum player limit reached or exceeded.");
      return;
    }

    SpawnPlayerObject(targetSceneName, playerPrefab, clientId);
  }
}
