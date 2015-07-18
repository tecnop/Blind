using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	Transform _displacementTransform;

	[SerializeField]
	Transform _headTransform;

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

	[SerializeField]
	Stats _stats;

	/* Colliders */
	// Rotation
	[SerializeField]
	ColliderRotationScript _rightRotationCollider;

	[SerializeField]
	ColliderRotationScript _leftRotationCollider;

	/* Modules */
	[SerializeField]
	PlayerMoveScript _playerMoveScript;

	private int _handRorationCpt;

	void Awake () {
		_handRorationCpt = 0;

		_rightRotationCollider.activate(rotateRight,rotationColliderEnter,rotationColliderExit);
		_leftRotationCollider.activate(rotateLeft,rotationColliderEnter,rotationColliderExit);

	}

	private void rotationColliderEnter(GameObject go){
		_handRorationCpt = _handRorationCpt < 2 ? ++_handRorationCpt : 2;
	}
	private void rotationColliderExit(GameObject go){
		_handRorationCpt = _handRorationCpt > 0 ? --_handRorationCpt : 0;
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

	public Transform headTransform {
		get {
			return _headTransform;
		}
	}

	public Stats stats {
		get {
			return _stats;
		}
	}
}
