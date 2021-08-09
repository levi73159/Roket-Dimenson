/* copyright(c) by LeviStudios;
 * RocketDimeson CollisonHandler copyright(c) by LeviStudios;
 */
using UnityEngine;

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
				Debug.Log("You Crash");
				break;
		}
	}
}