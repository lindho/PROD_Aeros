using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour {

	public float CamSpeed = 1;
	public int GUISize = 25;

	void Update ()
	{
		var recdown = new Rect (0, 0, Screen.width, GUISize);

		var recup = new Rect (0, Screen.height - GUISize, Screen.width, GUISize);

		var recleft = new Rect (0, 0, GUISize, Screen.height);

		var recright = new Rect (Screen.width - GUISize, 0, GUISize, Screen.height);

		if (recdown.Contains (Input.mousePosition))
		{
			transform.Translate(0, 0, - CamSpeed, Space.World);
		}

		if (recup.Contains (Input.mousePosition))
		{
			transform.Translate(0, 0, CamSpeed, Space.World);
		}

		if (recleft.Contains (Input.mousePosition))
		{
			transform.Translate( - CamSpeed,0, 0, Space.World);
		}

		if (recright.Contains (Input.mousePosition))
		{
			transform.Translate(CamSpeed,0, 0, Space.World);
		}
	}
}
