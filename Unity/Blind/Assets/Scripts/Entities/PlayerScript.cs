using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	GameObject _rightHandObject;

	[SerializeField]
	Transform _rightHandTransform;

	[SerializeField]
	EntityManager _entityManager;

	// Use this for initialization
	void Awake () {
		/*
		foreach(IInputInterpretor iii in _inputInterpretor){
			iii.activate(this);
		}
*/
	}
	
	// Update is called once per frame
	void Update () {
		//_entityManager.objectTransform.LookAt (_entityManager.objectTransform.position - _rightHandTransform.position);
	}

	public EntityManager entityManager {
		get {
			return _entityManager;
		}
	}
}
