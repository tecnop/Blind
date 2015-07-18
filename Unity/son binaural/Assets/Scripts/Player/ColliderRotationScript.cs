using UnityEngine;
using System.Collections;
using System;

public class ColliderRotationScript : MonoBehaviour {

	[SerializeField]
	GameObject _object;

	private bool _active;
	private Action<GameObject> _stayAction;
	private Action<GameObject> _enterAction;
	private Action<GameObject> _exitAction;

	public void activate (Action<GameObject> onStay,Action<GameObject> onEnter,Action<GameObject> onExit){
		_stayAction = onStay;
		_enterAction = onEnter;
		_exitAction = onStay;

		_active = true;
		//_object.SetActive(true);

	}

	// Use this for initialization
	void Awake () {
		_active = false;
		//_object.SetActive(false);
	}
	void OnTriggerEnter (Collider col){
		if (!_active)
			return;

		_enterAction (col.gameObject);
	}

	void OnTriggerExit (Collider col){
		if (!_active)
			return;
		
		_exitAction (col.gameObject);
	}

	void OnTriggerStay (Collider col){
		if(!_active)
			return;


		_stayAction(col.gameObject);
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
