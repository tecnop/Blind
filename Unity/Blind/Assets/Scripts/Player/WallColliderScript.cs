using UnityEngine;
using System.Collections;
using System;

public class WallColliderScript : MonoBehaviour {

	[SerializeField]
	GameObject _object;

	private bool _active;
	private Action<GameObject> _enterAction;
	private Action<GameObject> _exitAction;

	public void activate (Action<GameObject> enter,Action<GameObject> exit){
		_active = true;
		_enterAction = enter;
		_exitAction = exit;
		
	}

	void Awake () {
		_active = false;
	}
	
	void OnTriggerEnter (Collider col){
		if(!_active)
			return;

		_enterAction (col.gameObject);
	}

	void OnTriggerExit (Collider col){
		if(!_active)
			return;
		
		_exitAction (col.gameObject);
	}
	
	public bool active {
		get {
			return _active;
		}
		set {
			_active = value;
		}
	}

}
