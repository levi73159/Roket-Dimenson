/* copyright(c) by LeviStudios;  
 * #PROJECTNAME# RandomColor copyright(c) by LeviStudios;
 */

using UnityEngine;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviour
{
	public static void NewRGColors()
	{
		var randomColors = FindObjectsOfType<RandomColor>();

		foreach (var item in randomColors)
		{
			var render = item.GetComponent<Renderer>();
			var randomColor = Random.ColorHSV();
			render.sharedMaterial.color = randomColor;
		}
	}
}
