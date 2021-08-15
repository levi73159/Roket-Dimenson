using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
	private static GameAssets _i;

	public static GameAssets I
	{
		get
		{
			if (_i == null) _i = Instantiate(Resources.Load("GameAseets") as GameObject).GetComponent<GameAssets>();
			return _i;
		}
	}

	public Camera camera_;
}
