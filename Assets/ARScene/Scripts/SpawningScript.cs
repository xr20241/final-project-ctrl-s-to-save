using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class SpawningScript : NetworkBehaviour {
  // Start is called before the first frame update

  void Start() {}

  // Update is called once per frame
  void Update() {}

  public void Spawn(GameObject spawnObject, Vector3 spawnPosition,
                    Quaternion spawnRotation, Transform transform) {
    if (IsServer) {
      var instance =
          Instantiate(spawnObject, spawnPosition, spawnRotation, transform);
      instance.GetComponent<NetworkObject>().Spawn();
    }
  }
}
