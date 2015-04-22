using UnityEngine;
using System.Collections;
using System;

public class ColliderRotationScript : MonoBehaviour {

	[SerializeField]
	GameObject _object;

	private bool _active;
	private Action<GameObject> _action;

	public void activate (Action<GameObject> ac){
		_action = ac;
		_active = true;
		//_object.SetActive(true);

	}

	// Use this for initialization
	void Awake () {
		_active = false;
		//_object.SetActive(false);
	}
	
	void OnTriggerStay (Collider col){
		if(!_active)
			return;


		_action(col.gameObject);
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
