using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	Transform _displacementTransform;

	/* Skeletonz */
	// RIGHT
	[SerializeField]
	GameObject _rightHandObject;

	[SerializeField]
	Transform _rightHandTransform;

	// LEFT 
	[SerializeField]
	GameObject _leftHandObject;
	
	[SerializeField]
	Transform _leftHandTransform;


	/* Rotation Collider */
	[SerializeField]
	ColliderRotationScript _rightRotationCollider;

	[SerializeField]
	ColliderRotationScript _leftRotationCollider;

	/* Modules */
	[SerializeField]
	PlayerMoveScript _playerMoveScript;

	[SerializeField]
	Stats _stats;

	void Awake () {
		_rightRotationCollider.activate(rotateRight);
		_leftRotationCollider.activate(rotateLeft);
	}

	private void rotateRight(GameObject go){
		_playerMoveScript.rotateRight();
	}

	private void rotateLeft(GameObject go){
		_playerMoveScript.rotateLeft();
	}

	// GET / SET
	public Transform displacementTransform {
		get {
			return _displacementTransform;
		}
		set {
			_displacementTransform = value;
		}
	}

	public Transform rightHandTransform {
		get {
			return _rightHandTransform;
		}
	}

	public Transform leftHandTransform {
		get {
			return _leftHandTransform;
		}
	}

	public PlayerMoveScript playerMoveScript {
		get {
			return _playerMoveScript;
		}
	}
}
