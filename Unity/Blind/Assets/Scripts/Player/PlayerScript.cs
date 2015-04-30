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


	/* Colliders */
	// Rotation
	[SerializeField]
	ColliderRotationScript _rightRotationCollider;

	[SerializeField]
	ColliderRotationScript _leftRotationCollider;
	// Wall
	[SerializeField]
	WallColliderScript _wallColliderScript;

	/* Modules */
	[SerializeField]
	PlayerMoveScript _playerMoveScript;

	[SerializeField]
	Stats _stats;

	private int _handRorationCpt;

	void Awake () {
		_handRorationCpt = 0;

		_rightRotationCollider.activate(rotateRight,rotationColliderEnter,rotationColliderExit);
		_leftRotationCollider.activate(rotateLeft,rotationColliderEnter,rotationColliderExit);
		
		_wallColliderScript.activate (wallPartEnter,wallPartExit);
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

	private void wallPartEnter(GameObject go){

		WallPart wp = go.GetComponent<WallPart> ();
		wp.triggerPlayerEnter (this);
	}

	private void wallPartExit(GameObject go){
		WallPart wp = go.GetComponent<WallPart> ();
		wp.triggerPlayerExit (this);
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
}
