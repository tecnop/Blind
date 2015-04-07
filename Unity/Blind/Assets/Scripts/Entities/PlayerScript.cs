using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	IInputInterpretor _inputInterpretor;

	[SerializeField]
	EntityManager _entityManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public EntityManager entityManager {
		get {
			return _entityManager;
		}
	}
}
