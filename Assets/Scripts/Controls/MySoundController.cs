using UnityEngine;
using System.Collections;

public class MySoundController : MonoBehaviour {

	public AudioClip    GameOver,BulbBrokenSound,ElecricalShocksound;

	public static MySoundController Static ;
	public AudioSource[]  audioSources;
	public AudioSource bgAudio;

	//public AudioSource scoreCount,bgSound ;

	void Start () {

		Static = this;
	}



	public void PlayGameOver()
	{
		bgAudio.volume=0;
		swithAudioSources (GameOver);

	}
	public void PlayBulbBrokenSound()
	{

		swithAudioSources (BulbBrokenSound);

	}

	public void PlayElecricalShocksound()
	{

		swithAudioSources (ElecricalShocksound);

	}
	//public void StopSounds ()
	//{
	//	audio.Stop ();
	//}

	void swithAudioSources( AudioClip clip)
	{
		if(audioSources[0].isPlaying) 
		{
			audioSources[1].PlayOneShot(clip);
		}
		else audioSources[0].PlayOneShot(clip);

	}
}
