using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	// Max + Init
	[SerializeField]
	int _life = 100;

	[SerializeField]
	int _ap = 10;

	[SerializeField]
	int _strength = 10;

	[SerializeField]
	int _magic = 10;

	[SerializeField]
	float _moveSpeed = 2f;

	[SerializeField]
	float _attackSpeed = 2f;

	// Current
	private int _currentLife;

	private int _currentAp;

	private int _currentStrength;

	private int _currentMagic;

	private float _currentMoveSpeed;

	private float _currentAttackSpeed;

	// Use this for initialization
	void Awake () {
		_currentLife = this._life;
		_currentAp = this._ap;

		_currentStrength = this._strength;
		_currentMagic = this._magic;

		_currentAttackSpeed = this._attackSpeed;
		_currentMoveSpeed = this._moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	 *  GET / SET
	 */
	public int currentLife {
		get {
			return _currentLife;
		}
		set {
			_currentLife = value;
		}
	}

	public int currentAp {
		get {
			return _currentAp;
		}
		set {
			_currentAp = value;
		}
	}

	public int currentStrength {
		get {
			return _currentStrength;
		}
		set {
			_currentStrength = value;
		}
	}

	public int currentMagic {
		get {
			return _currentMagic;
		}
		set {
			_currentMagic = value;
		}
	}

	public float currentMoveSpeed {
		get {
			return _currentMoveSpeed;
		}
		set {
			_currentMoveSpeed = value;
		}
	}

	public float currentAttackSpeed {
		get {
			return _currentAttackSpeed;
		}
		set {
			_currentAttackSpeed = value;
		}
	}
}
