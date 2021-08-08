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
    private Rigidbody rb;
    private AudioSource audioSource;

    // this function will setup are script
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    /// Move are player the relative up
    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            rb.AddRelativeForce(Vector3.up * (mainThrustSpeed * Time.deltaTime));
    }

    /// Rotate are player left or right when a d or left right is press
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            ApplyRotation(rotateSpeed);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            ApplyRotation(-rotateSpeed);
    }

    private void ApplyRotation(float rotation)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * (rotation * Time.deltaTime));
        rb.freezeRotation = false; // unfreezing rotation so physics can take over
    }
}