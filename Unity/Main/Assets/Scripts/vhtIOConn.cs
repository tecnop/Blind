using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class vhtIOConn : MonoBehaviour {

	[SerializeField]
	Transform palm;

	[SerializeField]
	Transform thumb;
	[SerializeField]
	Transform thumb1;
	
	[SerializeField]
	Transform index;
	[SerializeField]
	Transform index1;
	
	[SerializeField]
	Transform major;
	[SerializeField]
	Transform major1;
	
	[SerializeField]
	Transform ring;
	[SerializeField]
	Transform ring1;
	
	[SerializeField]
	Transform pinky;
	[SerializeField]
	Transform pinky1;
	
	[DllImport("CyberGloveForUnity", EntryPoint="getCyberTouch", CallingConvention=CallingConvention.StdCall)]
	static public extern IntPtr getCyberTouch();

	[DllImport("CyberGloveForUnity", EntryPoint="setVibration", CallingConvention=CallingConvention.StdCall)]
	static public extern void setVibration (IntPtr touch, int finger, double value);

	[DllImport("CyberGloveForUnity", EntryPoint="getData", CallingConvention=CallingConvention.StdCall)]
	static public extern double getData (IntPtr touch, int finger, int joint);

	[DllImport("CyberGloveForUnity", EntryPoint="updateGloveData", CallingConvention=CallingConvention.StdCall)]
	static public extern void updateGloveData (IntPtr touch);
	// Use this for initialization

	IntPtr glove;

	int state = 0;

	double[,] gloveData;
	Transform [] firstPhallanx;

	void Start () {

		firstPhallanx = new Transform[4];

		firstPhallanx [0] = index;
		firstPhallanx [1] = major;
		firstPhallanx [2] = ring;
		firstPhallanx [3] = pinky;

		gloveData = new double[6,3];
		glove = getCyberTouch();
		setVibration (glove, 0, 0.0);

	}

	public void vibrate(int finger, double value)
	{
		setVibration (glove, finger, value);
	}

	public double [,] getGloveData()
	{
		return gloveData;
	}

	public void updateGlove()
	{
		for (int finger = 0; finger < 6; finger++)
			for (int joint = 0; joint < 3; joint++)
				gloveData [finger,joint] = getData (glove, finger, joint);
	}
	float toDegree = (float)(180 / Math.PI);
	// Update is called once per frame
	void Update () {

		checkState ((float)0.11,(float) 0.11,(float) 0.11,(float) 0.11, 1);

		Debug.Log (state);

		updateGloveData (glove);
		updateGlove ();
		//thumb.localRotation = Quaternion.Euler (0, 0, (float)(-(gloveData [0, 0]*180)/Math.PI));
		//thumb1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [0, 1]*180)/Math.PI));
		index.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [1, 0]*toDegree)));
		index1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [1, 1]*toDegree)));
		major.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [2, 0]*toDegree)));
		major1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [2, 1]*toDegree)));
		ring.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [3, 0]*toDegree)));
		ring1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [3, 1]*toDegree)));
		pinky.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [4, 0]*toDegree)));
		pinky1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [4, 1]*toDegree)));


	}

	public void checkState( float IndexVal, float majorVal, float ringVal, float pinkyVal, int stateIfOk)
	{
		int count = 0;
		if ((index.localRotation.z <= -IndexVal * 0.9 && index.localRotation.z >= -IndexVal *1.1) ||
		    (index.localRotation.z >= IndexVal * 0.9 && index.localRotation.z <= IndexVal * 0.9)) {
			count ++;
		
		}
		if ((major.localRotation.z <= -majorVal * 0.9 && major.localRotation.z >= -majorVal *1.1) ||
		    (major.localRotation.z >= majorVal * 0.9 && major.localRotation.z <= majorVal * 0.9)) {
			count ++;
			
		}
		if ((ring.localRotation.z <= -ringVal * 0.9 && ring.localRotation.z >= -ringVal *1.1) ||
		    (ring.localRotation.z >= ringVal * 0.9 && ring.localRotation.z <= ringVal * 0.9)) {
			count ++;
			
		}
		if ((pinky.localRotation.z <= -pinkyVal * 0.9 && pinky.localRotation.z >= -pinkyVal *1.1) ||
		    (pinky.localRotation.z >= pinkyVal * 0.9 && pinky.localRotation.z <= pinkyVal * 0.9)) {
			count ++;
			
		}
		Debug.Log (count);
		if (count >= 3)
			state = stateIfOk;

	}
}


