/* copyright(c) by LeviStudios;  
 * RocketDimeson Debuger and HotKey copyright(c) by LeviStudios;
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuger
{
	public static readonly Debuger Current = new Debuger();
	private List<HotKey> hotKeys = new List<HotKey>();
	
	public void Add(HotKey hotKey)
	{
		hotKeys.Add(hotKey);
	}

	public void ProcessInput()
	{
		foreach (var key in hotKeys)
		{
			key.ProcessKeyPress();
		}
	}
}

public readonly struct HotKey
{
	private readonly Action _action;
	private readonly KeyCode _keyCode;
	private readonly bool _needCltrlHeld;
	private readonly bool _canHold;

	public HotKey(Action action, KeyCode keyCode, bool needCltrlHeld = true, bool canHold = false)
	{
		_action = action;
		_keyCode = keyCode;
		_needCltrlHeld = needCltrlHeld;
		_canHold = canHold;
	}

	public void ProcessKeyPress()
	{
		if (Input.GetKeyDown(_keyCode) && !_canHold)
		{
			if (Input.GetKey(KeyCode.LeftControl) && _needCltrlHeld)
				_action();
			else if (!_needCltrlHeld)
				_action();
		}
		else if (Input.GetKey(_keyCode) && _canHold)
		{
			if (Input.GetKey(KeyCode.LeftControl) && _needCltrlHeld)
				_action();
			else if (!_needCltrlHeld)
				_action();
		}
	}
}