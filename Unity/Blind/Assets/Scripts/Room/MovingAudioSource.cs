using UnityEngine;
using System.Collections;

public class MovingAudioSource : MonoBehaviour, IRoomComponent {

	[SerializeField]
	Transform _transform;

	private bool _active;



	//Override
	public void activate(bool s){
		_active = s;
	}
	
	//Override
	public Transform getObjectTransform(){
		return _transform;
	}
}
