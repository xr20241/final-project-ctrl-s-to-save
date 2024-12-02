using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAR : MonoBehaviour {
  // Start is called before the first frame update
  public void OnButtonClick() {
    var prevScene = SceneManager.GetActiveScene();
    // Load the new scene additively to preserve network connection
    SceneManager.LoadScene("ARScene", LoadSceneMode.Single);

    // Unload the current scene
    // SceneManager.UnloadSceneAsync(prevScene);
  }
  // Update is called once per frame
}
