using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	float pRange;
	float pAngle;

	float pSpeed = 0.1f;
	Vector3 dir;

	// Use this for initialization
	void Start () {
		

	}

	public void SetupProjectile(float range, float angle)
	{
		this.pAngle = angle;
		this.pRange = range;

		Quaternion rot = new Quaternion ();
		rot.eulerAngles = new Vector3 (0, 0, pAngle);
		this.transform.rotation = rot;

		dir = new Vector3 (Mathf.Cos (angle / 180.0f * Mathf.PI), Mathf.Sin (angle / 180.0f * Mathf.PI), 0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position + pSpeed * dir;
	}
}
