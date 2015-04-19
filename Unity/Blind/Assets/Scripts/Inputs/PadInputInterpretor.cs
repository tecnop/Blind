using UnityEngine;
using System.Collections;

public class PadInputInterpretor : MonoBehaviour {

	[SerializeField]
	PlayerScript _playerScript;
	
	private bool _active;

	// Use this for initialization
	void Start () {
	}

	// TL : 1
	// T : ?
	// TR : 0
	// R :
	// BR : 2
	// B
	// BF
	// L

	// S
	// B
	// Update is called once per frame
	void FixedUpdate () {

		// Forward
		if(Input.GetButton("Pad_TopLeft")){
			Vector3 nextPos = Vector3.Lerp(this._playerScript.entityManager.objectTransform.position,
			                               (this._playerScript.entityManager.objectTransform.position + Vector3.forward),
			                               Time.deltaTime* (this._playerScript.entityManager.stats.currentMoveSpeed * 3f) );
			
			this._playerScript.entityManager.moveTo(nextPos);
		}
		
		// Backward
		if(Input.GetButton("Pad_BottomRight")){
			Vector3 nextPos = Vector3.Lerp(this._playerScript.entityManager.objectTransform.position,
			                               (this._playerScript.entityManager.objectTransform.position + (-Vector3.forward)),
			                               Time.deltaTime* (this._playerScript.entityManager.stats.currentMoveSpeed * 3f) );
			
			this._playerScript.entityManager.moveTo(nextPos);
		}
		//Left
		if(Input.GetButton("Pad_BottomLeft")){
			Vector3 nextPos = Vector3.Lerp(this._playerScript.entityManager.objectTransform.position,
			                               (this._playerScript.entityManager.objectTransform.position + Vector3.left),
			                               Time.deltaTime* (this._playerScript.entityManager.stats.currentMoveSpeed * 3f) );
			
			this._playerScript.entityManager.moveTo(nextPos);
		}
		// Right
		if(Input.GetButton("Pad_TopRight")){
			
			Vector3 nextPos = Vector3.Lerp(this._playerScript.entityManager.objectTransform.position,
			                               (this._playerScript.entityManager.objectTransform.position + Vector3.right),
			                               Time.deltaTime* (this._playerScript.entityManager.stats.currentMoveSpeed * 3f) );
			
			this._playerScript.entityManager.moveTo(nextPos);
		}

	}
}
