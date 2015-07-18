using UnityEngine;
using System.Collections;

public class TakeWeapon : MonoBehaviour {

    [SerializeField]
    public GameObject weapon;
    public Transform fpsHand;
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.S))
        {
            weapon.transform.parent = fpsHand;
            weapon.transform.position = fpsHand.position;
            weapon.transform.eulerAngles = new Vector3(0, 90, 0);
        }
	}
}
