/* copyright(c) by LeviStudios;
 * RocketDimeson CollisonHandler copyright(c) by LeviStudios;
 */

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CollisonHandler : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		switch (other.gameObject.tag)
		{
			case "Friendly":
				break;
			
			case "Finish":
				Debug.Log("You Won");
				break;
			
			default:
				LoadLevel();
				break;
		}
	}

	private void LoadLevel()
	{
		var CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(CurrentSceneIndex);
	}
}