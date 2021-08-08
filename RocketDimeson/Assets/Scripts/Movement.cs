/* copyright(c) by LeviStudios;
 * RocketDimeson Movement copyright(c) by LeviStudios;
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private float mainThrustSpeed = 10;
    [SerializeField] private float rotateSpeed = 10;
    //the Rigidbody attach to are player
    private Rigidbody _rb;

    // this function will setup are script
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    /// <summary>
    /// Move are player the relative up
    /// </summary>
    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            _rb.AddRelativeForce(Vector3.up * (mainThrustSpeed * Time.deltaTime));
    }

    /// <summary>
    /// Rotate are player left or right
    /// </summary>
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            ApplyRotation(rotateSpeed);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            ApplyRotation(-rotateSpeed);
    }

    private void ApplyRotation(float rotation)
    {
        _rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * (rotation * Time.deltaTime));
        _rb.freezeRotation = false; // unfreezing rotation so physics can take over
    }
}