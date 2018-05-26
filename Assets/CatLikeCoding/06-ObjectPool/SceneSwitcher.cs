using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	public void SwitchScene() {
		Scene scene = SceneManager.GetActiveScene();
		int nextLevel = (scene.buildIndex+1) % SceneManager.sceneCountInBuildSettings;
		Debug.Log("SceneManager.sceneCount");
		Debug.Log(SceneManager.sceneCount);
		SceneManager.LoadScene(nextLevel);
	}
}
