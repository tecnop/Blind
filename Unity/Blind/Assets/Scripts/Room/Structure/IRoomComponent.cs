using UnityEngine;
using System.Collections;

public interface IRoomComponent  {

	Transform getObjectTransform();

	void activate(bool state);
}
