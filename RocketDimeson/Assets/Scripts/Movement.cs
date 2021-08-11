/* copyright(c) by LeviStudios;
 * RocketDimeson Movement copyright(c) by LeviStudios;
 */

using UnityEngine;

public class Movement : MonoBehaviour
{
	#region vars

	[SerializeField] private float mainThrustSpeed = 10;
	[SerializeField] private float rotateSpeed = 10;
	[SerializeField] private AudioClip thrustSFX;
	[SerializeField] private ParticleSystem mainThrusterEffect;

	private AudioSource audioSource;
	private Rigidbody rb;

	#endregion

	// this function will setup are script
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	private void OnDisable() => StopThrusting();

	private void Update()
	{
		ProcessThrust();
		ProcessRotation();
	}

	/// Move are player the relative up
	private void ProcessThrust()
	{
		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			StartTrusting();
		}
		else
		{
			StopThrusting();
		}
	}
	
	/// Rotate are player left or right when a d or left right is press
	private void ProcessRotation()
	{
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			ApplyRotation(rotateSpeed);
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			ApplyRotation(-rotateSpeed);
		}
	}

	#region extraMethods

	private void StartTrusting()
	{
		if (!audioSource.isPlaying)
			audioSource.PlayOneShot(thrustSFX);
		
		if (!mainThrusterEffect.isPlaying)
			mainThrusterEffect.Play();

		rb.AddRelativeForce(Vector3.up * (mainThrustSpeed * Time.deltaTime));
	}
	
	private void StopThrusting()
	{
		audioSource.Stop();
		mainThrusterEffect.Stop();
	}

	private void ApplyRotation(float rotation)
	{
		rb.freezeRotation = true; // freezing rotation so we can manually rotate
		transform.Rotate(Vector3.forward * (rotation * Time.deltaTime));
		rb.freezeRotation = false; // unfreezing rotation so physics can take over
	}

	#endregion
}