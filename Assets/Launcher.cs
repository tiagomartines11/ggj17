using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	public int numProjectiles = 3;
	int activeAngle = 0;
	// Use this for initialization
	void Start () {
		activeAngle = 0;

		int cumulativeAngle = 0;
		for (int i = 0; i < numProjectiles; i++) {
			GameObject container = new GameObject ();

			GameObject instance = Instantiate (Resources.Load ("aimprefab", typeof(GameObject))) as GameObject;

			instance.transform.parent = container.transform;
			container.transform.parent = this.transform;

			container.transform.localPosition = new Vector3 (0, 0, 0);

			int angle = 360 / numProjectiles;
			cumulativeAngle += angle;

			Quaternion rot = new Quaternion ();
			rot.eulerAngles = new Vector3 (0, 0, cumulativeAngle);
			container.transform.rotation = rot;

			instance.transform.localPosition = new Vector3 (1.0f, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (activeAngle < 360)
			activeAngle += 5;
		else
			activeAngle = 0;
		
		Quaternion rot = new Quaternion ();
		rot.eulerAngles = new Vector3 (0, 0, activeAngle);
		this.transform.rotation = rot;


	}

	void launch()
	{

	}
}
