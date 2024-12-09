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
    NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
    var allPrefabs = NetworkManager.Singleton.NetworkConfig.Prefabs.Prefabs;

    // Getting only the prefabs to spawn for their respective scene
    // (Not the player objects)
    foreach (var prefab in allPrefabs) {
      if (prefab.Prefab.name.StartsWith("AR_")) {
        ARPrefabs.Add(prefab.Prefab);
      } else if (prefab.Prefab.name.StartsWith("VR_")) {
        VRPrefabs.Add(prefab.Prefab);
      }
    }

    // And spawn them
    SceneManager.SetActiveScene(SceneManager.GetSceneByName(VRSceneName));
    foreach (var prefab in VRPrefabs) {
      var objInstance = Instantiate(prefab);
      objInstance.GetComponent<NetworkObject>().Spawn();
    }
    SceneManager.SetActiveScene(SceneManager.GetSceneByName(ARSceneName));
    foreach (var prefab in ARPrefabs) {
      var objInstance = Instantiate(prefab);
      objInstance.GetComponent<NetworkObject>().Spawn();
    }
  }

  public void StartVR() {
    m_NetworkManager.StartClient();
    // Load the scene in Single mode to, hopefully, unload the other scene's
    // objects locally
    SceneManager.LoadScene(VRSceneName, LoadSceneMode.Single);
  }

  public void StartAR() {
    m_NetworkManager.StartClient();
    // Load the scene in Single mode to, hopefully, unload the other scene's
    // objects locally
    SceneManager.LoadScene(ARSceneName, LoadSceneMode.Single);
  }

  void SpawnPlayerObject(string scene, GameObject playerPrefab,
                         ulong clientId) {
    SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
    var objInstance = Instantiate(playerPrefab);
    objInstance.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
  }

  void HandleClientConnected(ulong clientId) {
    if (!NetworkManager.Singleton.IsServer)
      return;

    connectedClientsCount++;

    // Spawn different players based on connection order
    switch (connectedClientsCount) {
    case 2:
      SpawnPlayerObject(ARSceneName, ARPlayerPrefab, clientId);
      break;
    case 1:
      SpawnPlayerObject(VRSceneName, VRPlayerPrefab, clientId);
      break;
    default:
      Debug.Log("Maximum player limit reached or exceeded.");
      return;
    }
  }
}
