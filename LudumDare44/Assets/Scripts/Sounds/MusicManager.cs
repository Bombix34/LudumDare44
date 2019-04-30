using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public AudioSource musicSource;
    public AudioSource ambiantSource;

	public float musicInitVolume=0.5f;
	void Start () {
		musicSource.loop=true;
        ambiantSource.loop = true;
	}


	public IEnumerator FadeInEffect(AudioSource piste, float volume, float timeModif){
		while (piste.volume < volume){
			piste.volume += Time.deltaTime/timeModif;
			yield return new WaitForSeconds(0.05f);
		}
	}

	public IEnumerator FadeOutEffect(AudioSource piste, float volumeToGo,float timeModif){
		while (piste.volume > volumeToGo){
			piste.volume -= Time.deltaTime/timeModif;
			yield return new WaitForSeconds(0.05f);
		}
	}

	private static MusicManager s_Instance = null;

	// This defines a static instance property that attempts to find the manager object in the scene and
	// returns it to the caller.
	public static MusicManager instance
	{
		get
		{
			if (s_Instance == null)
			{
				// This is where the magic happens.
				//  FindObjectOfType(...) returns the first AManager object in the scene.
				s_Instance = FindObjectOfType(typeof(MusicManager)) as MusicManager;
			}

			// If it is still null, create a new instance
			if (s_Instance == null)
			{
				GameObject obj = Instantiate(Resources.Load("MusicManager") as GameObject);
				s_Instance = obj.GetComponent<MusicManager>();
			}
			return s_Instance;
		}
	}
}
