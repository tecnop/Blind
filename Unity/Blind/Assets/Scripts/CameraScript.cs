using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	[SerializeField]
	Camera _camera;

	[SerializeField]
	Transform _cameraTransform;

	[SerializeField]
	Transform _toFollowTransform;

	[SerializeField]
	float _scrollSpeed = 10f;

	[SerializeField]
	float _mSpeed = 10f;

	[SerializeField]
	GameObject _kinectImageObject;
	

	private bool _active;
	private bool _followMode;
	private bool _kinectImageActive;

	// Use this for initialization
	void Start () {
		_active = true;
		_followMode = true;
		_kinectImageActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_active)
			return;

		if (_followMode) {
			_cameraTransform.position = new Vector3(_toFollowTransform.position.x, _cameraTransform.position.y, _toFollowTransform.position.z);
		}

		float speed = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) ? _mSpeed *10 : _mSpeed;

		// Camera Follow Mode
		if(Input.GetKeyDown(KeyCode.F)){
			_followMode = !_followMode;
		}
		// Toggle Kinect Image
		if(Input.GetKeyDown(KeyCode.I)){
			_kinectImageActive = !_kinectImageActive;
			_kinectImageObject.SetActive(_kinectImageActive);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			_cameraTransform.transform.position += Vector3.right * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			_cameraTransform.transform.position += Vector3.left * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			_cameraTransform.transform.position += Vector3.forward * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			_cameraTransform.transform.position -= Vector3.forward * Time.deltaTime * speed;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			_cameraTransform.transform.position += Vector3.down * Time.deltaTime * (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ?_scrollSpeed * 10 : _scrollSpeed);
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			_cameraTransform.transform.position += Vector3.up * Time.deltaTime * (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ?_scrollSpeed * 10 : _scrollSpeed);
		}
	}

	// GET /SET
	public bool active {
		get {
			return _active;
		}
		set {
			_active = value;
		}
	}
}
