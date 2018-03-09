using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;

public class Addwiiplus : MonoBehaviour {

	private Quaternion initial_rotation;

	private Wiimote wiimote;

	private Vector2 scrollPosition;

	private Vector3 wmpOffset = Vector3.zero;

	void Start() {
		wiimote.SendPlayerLED (true, true, false, false);
	}

	void Update () {
		if (!WiimoteManager.HasWiimote()) { return; }

		wiimote = WiimoteManager.Wiimotes[0];

		int ret;
		do
		{
			ret = wiimote.ReadWiimoteData();

			if (ret > 0 && wiimote.current_ext == ExtensionController.MOTIONPLUS) {
				Vector3 offset = new Vector3(  -wiimote.MotionPlus.PitchSpeed,
					wiimote.MotionPlus.YawSpeed,
					wiimote.MotionPlus.RollSpeed) / 95f; // Divide by 95Hz (average updates per second from wiimote)
				wmpOffset += offset;	
				Debug.Log("connected wii plus");
			}
		} while (ret > 0);
			
	}
}
