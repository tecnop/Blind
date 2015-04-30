using UnityEngine;
using System.Collections;

public class WallPart : MonoBehaviour, IRoomComponent {

	[SerializeField]
	Transform _transform;

	private Wall _parentWall;

	private bool _active;

	void Awake(){
		_active = false;
		_parentWall = null;
	}

	public void triggerPlayerEnter(PlayerScript p){
		if (null == _parentWall)
			return;

		_parentWall.onPlayerEnter (p);
	}

	public void triggerPlayerExit(PlayerScript p){
		if (null == _parentWall)
			return;
		
		_parentWall.onPlayerExit (p);
	}

	//Override
	public void activate(bool s){
		_active = s;
	}

	//Override
	public Transform getObjectTransform(){
		return _transform;
	}
	
	public void setParentWall(Wall value) {
		_parentWall = value;

	}
}
