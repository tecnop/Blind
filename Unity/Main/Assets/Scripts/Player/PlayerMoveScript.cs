using UnityEngine;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {

	[SerializeField]
	Transform _transform;
	
	[SerializeField]
	Stats _stats;

	[SerializeField]
	float _moveConst = 1f;

	public void moveLeft(){
		_transform.position = Vector3.Lerp(_transform.position,
		                                   (_transform.position + (-_transform.right)),
		                                   Time.deltaTime * (_stats.currentMoveSpeed * _moveConst) );
	}

	public void moveRight(){
		_transform.position = Vector3.Lerp(_transform.position,
		                                   (_transform.position + (_transform.right)),
		                                   Time.deltaTime * (_stats.currentMoveSpeed * _moveConst) );
	}

	public void moveForward(){
		_transform.position = Vector3.Lerp(_transform.position,
		                               (_transform.position + _transform.forward),
		                               Time.deltaTime * (_stats.currentMoveSpeed * _moveConst) );
		

	}

	public void moveBackward(){
		_transform.position = Vector3.Lerp(_transform.position,
		                                   (_transform.position + (-_transform.forward)),
		                                   Time.deltaTime * (_stats.currentMoveSpeed * _moveConst) );
	}

	// @ref : http://unity3d.com/learn/tutorials/modules/beginner/scripting/translate-and-rotate
	public void rotateLeft(){
		_transform.Rotate(Vector3.up, -_stats.rotationSpeed * Time.deltaTime);
		//_transform.rotation = Quaternion.Lerp(_transform.rotation,  Quaternion.LookRotation(-Vector3.right), Time.deltaTime*  10f);
	}

	public void rotateRight(){
		_transform.Rotate(Vector3.up, _stats.rotationSpeed * Time.deltaTime);
	}

	// GET / SET
	public Transform objectTransform {
		get {
			return _transform;
		}
	}
}
