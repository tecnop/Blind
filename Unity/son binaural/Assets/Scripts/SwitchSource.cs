using UnityEngine;
using System.Collections;
using TBE_3DCore;


public class SwitchSource : MonoBehaviour {
	
	public AudioClip[] myAudioClip;
    [SerializeField]
    TBE_Source tbeSource;
    [SerializeField]
    TBE_Source tbeSource2;
	private int currentClip = 0;
 

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            tbeSource.Play();
            if (tbeSource2)
            {
                StartCoroutine("LoopClips");
            }
        }
    }

	IEnumerator LoopClips () {
        while (true) {

            yield return new WaitForSeconds(tbeSource.clip.length + 2);
            tbeSource2.clip = myAudioClip[currentClip];
            tbeSource2.Play();
            yield return new WaitForSeconds(tbeSource2.clip.length + 2);

            currentClip++;

            if (currentClip >= myAudioClip.Length)
                currentClip = 0;
        }
    }
}
