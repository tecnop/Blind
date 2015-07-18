using UnityEngine;
using System.Collections;

public class PadInputInterpretor : MonoBehaviour {

	[SerializeField]
	PlayerScript _playerScript;

	[SerializeField]
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
		if(!_active)
			return;
	
		// Forward
		if(Input.GetButton("Pad_TopLeft")){
			_playerScript.playerMoveScript.moveForward();
		}
		
		// Backward
		if(Input.GetButton("Pad_BottomRight")){
			_playerScript.playerMoveScript.moveBackward();
		}

		//Left
		if(Input.GetButton("Pad_BottomLeft")){
			_playerScript.playerMoveScript.moveLeft();
		}

		// Right
		if(Input.GetButton("Pad_TopRight")){
			_playerScript.playerMoveScript.moveRight();
		}

	}
}
