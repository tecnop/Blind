using UnityEngine;
using System.Collections;

public class fingerCollision : MonoBehaviour {

	[SerializeField]
	vhtIOConn glove;

	[SerializeField]
	int finger;
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag != "Player")
			glove.vibrate (finger, 0.9);
	}
	
	void OnTriggerExit(Collider other) 
	{
		if(other.tag != "Player")
			glove.vibrate (finger, 0);
	}
}
