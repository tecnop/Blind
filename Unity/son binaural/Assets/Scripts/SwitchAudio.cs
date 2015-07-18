using UnityEngine;
using System.Collections;


public class SwitchAudio : MonoBehaviour {
	
	public AudioClip[] myAudioClip;
    [SerializeField]
    private AudioSource audio;
	private int currentClip = 0;
 
	void Start () {
	    //LoopClips();
        StartCoroutine("LoopClips");
	}
 
	IEnumerator LoopClips () {
        while (true) {
            audio.clip = myAudioClip[currentClip];
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);

            currentClip++;

            if (currentClip >= myAudioClip.Length)
                currentClip = 0;
        }
    }
}
