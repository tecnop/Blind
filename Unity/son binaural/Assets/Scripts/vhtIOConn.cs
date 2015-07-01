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

	double[,] gloveData;

	void Start () {

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

	// Update is called once per frame
	void Update () {
		updateGloveData (glove);
		updateGlove ();
		//thumb.localRotation = Quaternion.Euler (0, 0, (float)(-(gloveData [0, 0]*180)/Math.PI));
		//thumb1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [0, 1]*180)/Math.PI));
		index.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [1, 0]*180)/Math.PI));
		index1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [1, 1]*180)/Math.PI));
		major.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [2, 0]*180)/Math.PI));
		major1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [2, 1]*180)/Math.PI));
		ring.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [3, 0]*180)/Math.PI));
		ring1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [3, 1]*180)/Math.PI));
		pinky.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [4, 0]*180)/Math.PI));
		pinky1.localRotation = Quaternion.Euler (0, 0, (float)((gloveData [4, 1]*180)/Math.PI));
	}
}
