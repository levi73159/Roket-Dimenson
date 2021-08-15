/* copyright(c) by LeviStudios;
 * RocketDimeson CollisonHandler copyright(c) by LeviStudios;
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CollisonHandler : MonoBehaviour
{
	
	#region vars

	/*
	 * public:
	 *	values (float, float[], int, int[], double, double[])
	 *	cs (CLASSNAME, CLASSNAME[], StructName, StructName[])
	 *	cache (cs)
	 *	states (bool, bool[], Enum, Enum[])
	 *
	 * pricate:
     *	values (float, float[], int, int[], double, double[])
     *	cs (CLASSNAME, CLASSNAME[], StructName, StructName[])
     *	cache (cs)
     *	states (bool, bool[], Enum, Enum[])
	 */
	
	[SerializeField] private float loadLevelDelay = 1;
	[SerializeField] private float restartLevelDelay = 2;
	[SerializeField] private AudioClip crashSFX;
	[SerializeField] private AudioClip successSFX;
	[SerializeField] private ParticleSystem[] crashEffects;
	[SerializeField] private ParticleSystem successEffect;

	private AudioSource audioSource; // the audio source on this gameObject
	private Movement movementScript; // the movement script on this gameObject
	
	
	private bool isTransiting = false; // so we dont play multi audio
	private bool collisonEnable = true; // for debuger

	#endregion
	
	private void Awake()
	{
		movementScript = GetComponent<Movement>();
		audioSource = GetComponent<AudioSource>();
		Debuger.Current.Add(new HotKey(StartCrash, KeyCode.End));
		Debuger.Current.Add(new HotKey(LoadNextLevel, KeyCode.L));
		Debuger.Current.Add(new HotKey(delegate { audioSource.PlayOneShot(crashSFX); }, KeyCode.Y, false));
		Debuger.Current.Add(new HotKey(delegate { audioSource.PlayOneShot(successSFX); }, KeyCode.U, false));
		Debuger.Current.Add(new HotKey(
			delegate { GetComponent<BoxCollider>().enabled = !GetComponent<BoxCollider>().enabled; }, KeyCode.C));
		Debuger.Current.Add(new HotKey(delegate { collisonEnable = !collisonEnable; }, KeyCode.X));

	}

	private void OnCollisionEnter(Collision other)
	{
		if (isTransiting) return;
		if (!collisonEnable) return;
		
		switch (other.gameObject.tag)
		{
			case "Friendly":
				break;
			
			case "Finish":
				StartLoadLevel();
				break;
			
			default:
				StartCrash();
				break;
		}
	}

	private void StartCrash()
	{
		isTransiting = true;

		StartCrashEffectsAndAudio();
		Invoke(nameof(ReloadLevel), restartLevelDelay);
	}

	private void StartLoadLevel()
	{
		isTransiting = true;
		
		StartSuccessesEffectsAndAudio();
		Invoke(nameof(LoadNextLevel), loadLevelDelay);
	}

	#region extraMethods

	private void StartSuccessesEffectsAndAudio()
	{
		successEffect.Play();
		movementScript.enabled = false;
		audioSource.PlayOneShot(successSFX);
	}
	
	private void StartCrashEffectsAndAudio()
	{
		foreach (var crashEffect in crashEffects)
			crashEffect.Play();

		movementScript.enabled = false;
		audioSource.PlayOneShot(crashSFX);
	}
	
	private void LoadNextLevel()
	{
		var nextSceneIndex = 
			SceneManager.GetActiveScene().buildIndex+1 >= SceneManager.sceneCountInBuildSettings
				? 1
				: SceneManager.GetActiveScene().buildIndex+1;

		RandomColor.NewRGColors();
		SceneManager.LoadScene(nextSceneIndex);
	}
	
	private void ReloadLevel()
	{
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}

	#endregion
}