/* copyright(c) by LeviStudios;  
 * #PROJECTNAME# LoadScene copyright(c) by LeviStudios;
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	private void Start()
	{
		RandomColor.NewRGColors();
		SceneManager.LoadScene(1);
	}
}
