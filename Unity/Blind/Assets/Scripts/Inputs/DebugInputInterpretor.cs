using UnityEngine;
using System.Collections;

public class DebugInputInterpretor : MonoBehaviour {

	[SerializeField]
	PlayerScript _playerScript;

	private bool _active;

	// Use this for initialization
	void Start () {
		_active = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!_active)
			return;

		// Forward
		if(Input.GetKey(KeyCode.Z)){
			Vector3 nextPos = Vector3.Lerp(this._playerScript.entityManager.objectTransform.position,
			                               (this._playerScript.entityManager.objectTransform.position + Vector3.forward),
			                               Time.deltaTime* (this._playerScript.entityManager.stats.currentMoveSpeed * 3f) );

			this._playerScript.entityManager.moveTo(nextPos);
		}

		// Backward
		if(Input.GetKey(KeyCode.S)){
			Vector3 nextPos = Vector3.Lerp(this._playerScript.entityManager.objectTransform.position,
			                               (this._playerScript.entityManager.objectTransform.position + (-Vector3.forward)),
			                               Time.deltaTime* (this._playerScript.entityManager.stats.currentMoveSpeed * 3f) );

			this._playerScript.entityManager.moveTo(nextPos);
		}
		if(Input.GetKey(KeyCode.Q)){
			Vector3 nextPos = Vector3.Lerp(this._playerScript.entityManager.objectTransform.position,
			                               (this._playerScript.entityManager.objectTransform.position + Vector3.left),
			                               Time.deltaTime* (this._playerScript.entityManager.stats.currentMoveSpeed * 3f) );

			this._playerScript.entityManager.moveTo(nextPos);
		}
		if(Input.GetKey(KeyCode.D)){
			
			Vector3 nextPos = Vector3.Lerp(this._playerScript.entityManager.objectTransform.position,
			                               (this._playerScript.entityManager.objectTransform.position + Vector3.right),
			                               Time.deltaTime* (this._playerScript.entityManager.stats.currentMoveSpeed * 3f) );

			this._playerScript.entityManager.moveTo(nextPos);
		}
		
	}


	// GET / SET

	public bool active {
		get {
			return this._active;
		}
		set {
			this._active = value;
		}
	}
}
// Memo
/*
 * if (_isDead) {
			return;
		}

		if (!_isRolling && _target != null) {
			Vector3 lookPos = _target.golemTransform.position - _transform.position;
			lookPos.y = 0;
			_transform.rotation = Quaternion.Lerp(_transform.rotation,  Quaternion.LookRotation(lookPos), Time.deltaTime*  _stats.moveSpeed);
		}

		if(_isRolling) {
			if (_distanceToDestination <= 2f){
				_isRolling = false;
				_animator.SetBool("isRolling", false);

			}else {
				_distanceToDestination = Vector3.Distance(_transform.position,_setDestination);
				_transform.position = Vector3.Lerp(_transform.position,_setDestination, Time.deltaTime* ((_stats.moveSpeed * 3f)/_distanceToDestination)); 
				
			}

		}
		else if (_isMoving) {

			if (_distanceToDestination <= 0.5f){
				_isMoving = false;
				_animator.SetBool (_WALKING, false);

				if(!_isUnderControl)
					_ai.golemAI.onMoveDestinationReach();
			}
			else {
				// Vector will do a linear interpolation between our current position and our destination
				_distanceToDestination = Vector3.Distance(_transform.position,_setDestination);
				_transform.position = Vector3.Lerp(_transform.position,_setDestination, Time.deltaTime* (_stats.moveSpeed/_distanceToDestination)); 

			}
		}
*/
