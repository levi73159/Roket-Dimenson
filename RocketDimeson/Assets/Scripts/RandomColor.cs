/* copyright(c) by LeviStudios;  
 * #PROJECTNAME# RandomColor copyright(c) by LeviStudios;
 */

using UnityEngine;

public class RandomColor : MonoBehaviour
{
	public static void NewRGColors()
	{
		var randomColors = FindObjectsOfType<RandomColor>();
		GameAssets.I.camera_.backgroundColor = Random.ColorHSV();

		foreach (var item in randomColors)
		{
			var render = item.GetComponent<Renderer>();
			var randomColor = Random.ColorHSV();
			render.sharedMaterial.color = randomColor;
		}
	}
}
