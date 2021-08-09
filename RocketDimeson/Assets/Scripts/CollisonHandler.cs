/* copyright(c) by LeviStudios;
 * RocketDimeson CollisonHandler copyright(c) by LeviStudios;
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
	[SerializeField] private float loadLevelDelay = .3f;
	private Movement movementScript;

	private void Awake()
	{
		movementScript = GetComponent<Movement>();
	}

	private void OnCollisionEnter(Collision other)
	{
		switch (other.gameObject.tag)
		{
			case "Friendly":
				break;
			
			case "Finish":
				StartLoadLevel();
				break;
			
			default:
				StartCrash();
				break;
		}
	}

	private void StartCrash()
	{
		// todo add SFX on Crash
		// todo add partials on Crash
		movementScript.enabled = false;
		Invoke(nameof(ReloadLevel), loadLevelDelay);
	}
	
	private void ReloadLevel()
	{
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}

	private void StartLoadLevel()
	{
		// todo add SFX on Success
		// todo add partials on Success
		movementScript.enabled = false;
		Invoke(nameof(LoadNextLevel), loadLevelDelay);
	}
	
	private void LoadNextLevel()
	{
		var nextSceneIndex = 
			SceneManager.GetActiveScene().buildIndex+1 >= SceneManager.sceneCountInBuildSettings
			? 1
			: SceneManager.GetActiveScene().buildIndex+1;

		RandomColor.NewRGColors();
		SceneManager.LoadScene(nextSceneIndex);
	}
}