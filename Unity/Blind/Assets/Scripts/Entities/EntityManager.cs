using UnityEngine;
using System.Collections;

public class EntityManager : MonoBehaviour {

	[SerializeField]
	Transform _transform;

	[SerializeField]
	Stats _stats;



	// Static


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

	}

	public void moveTo(Vector3 dest){
		_transform.position = dest;
	}

	public void rotateTo(Quaternion rot){

		//_transform.rotation = rot;
	}

	// GET / SET

	public Transform objectTransform {
		get {
			return _transform;
		}
	}

	public Stats stats {
		get {
			return _stats;
		}
	}
}
