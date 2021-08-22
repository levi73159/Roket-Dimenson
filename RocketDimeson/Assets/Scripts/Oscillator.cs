/* copyright(c) by LeviStudios;  
 * RocketDimeson Oscillator copyright(c) by LeviStudios;
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
	private Vector3 startingPos; 
	[SerializeField] private Vector3 movementVector;
	private float movementFactor;
	[SerializeField] private float period = 2f;
	
	
	private void Start()
	{
		startingPos = transform.position;
	}

	private void Update()
	{
		if (period <= Mathf.Epsilon) return; // dont divide by 0
	
		var cycles = Time.time / period; // continually growing over time
		const float tau = Mathf.PI * 2f; // const value of 6.283
		var rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

		movementFactor = (rawSinWave + 1f) / 2f; // recalucated to go from 0 to 1 so its cleaner

		var offset = movementVector * movementFactor;
		transform.position = startingPos + offset;
	}
}
