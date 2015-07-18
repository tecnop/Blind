using UnityEngine;
using System.Collections;
using TBE_3DCore;

public class playDialogues : MonoBehaviour {
    [SerializeField]
    TBE_Source tbeSource;
    bool played = false;

     void OnTriggerEnter(Collider collider)
    {
         if(collider.tag == "Player" && !played)
         {
             tbeSource.Play();
             played = true;
         }
    }
}
