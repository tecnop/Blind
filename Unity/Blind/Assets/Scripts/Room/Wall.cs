using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour, IRoomComponent {

	[SerializeField]
	Transform _transform;

	[SerializeField]
	WallPart[] _walls;
	
	[SerializeField]
	MovingAudioSource _audioSource;

	[SerializeField]
	bool _horizontal;


	private bool _active;

	private PlayerScript _player;

	void FixedUpdate(){
		if (null == _player)
			return;

		if (_horizontal) {
			_audioSource.getObjectTransform ().position = new Vector3 (_player.playerMoveScript.objectTransform.position.x, _player.headTransform.position.y, _transform.position.z);
		} else {

			_audioSource.getObjectTransform ().position = new Vector3 ( _transform.position.x, _player.headTransform.position.y,_player.playerMoveScript.objectTransform.position.z);
		}
			                                                       
	}

	// Use this for initialization
	void Awake () {

		_player = null;

		foreach (WallPart w in _walls) {
			w.setParentWall(this);
		} 
	}
	
	public void onPlayerEnter (PlayerScript p){
		_player = p;
		Debug.Log ("onPlayerEnter");
	}
		
	public void onPlayerExit (PlayerScript p){

		_player = null;
		_audioSource.getObjectTransform ().position = _transform.position;
	
	}

	//Override
	public void activate(bool s){
		_active = s;
	}

	//Override
	public Transform getObjectTransform(){
		return _transform;
	}
}
