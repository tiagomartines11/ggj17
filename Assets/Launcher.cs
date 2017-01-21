using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	public int[] projectileAngles;
	public float range = 0.5f;
	float activeAngle = 0.0f;

	GameObject aimContainer;

	// Use this for initialization
	void Start () {
		activeAngle = 0;

		aimContainer = new GameObject ();

		foreach (int angle in projectileAngles) {
			GameObject container = new GameObject ();

			GameObject instance = Instantiate (Resources.Load ("aimprefab", typeof(GameObject))) as GameObject;

			instance.transform.parent = container.transform;
			container.transform.parent = aimContainer.transform;

			container.transform.localPosition = new Vector3 (0, 0, 0);

			Quaternion rot = new Quaternion ();
			rot.eulerAngles = new Vector3 (0, 0, angle);
			container.transform.rotation = rot;

			instance.transform.localPosition = new Vector3 (1.0f, 0, 0);
		}

		aimContainer.transform.parent = this.transform;
		aimContainer.transform.localPosition = new Vector3 (0, 0, 0);

	}

	void OnMouseDown(){
		launch ();
	}

	// Update is called once per frame
	void Update () {

		if (activeAngle < 360)
			activeAngle += 0.5f;
		else
			activeAngle = 0;
		
		Quaternion rot = new Quaternion ();
		rot.eulerAngles = new Vector3 (0, 0, activeAngle);
		aimContainer.transform.rotation = rot;


	}

	void launch()
	{
        //		Collider2D [] colliders = Physics2D.OverlapCircleAll(this.transform.position, 1f);
        //		if(colliders.Length > 0)
        //		{
        //			// enemies within 1m of the player
        //			Debug.Log(colliders.Length);
        //
        //			Mathf.Sin(
        //		};


        foreach (int angle in projectileAngles)
        {
            GameObject projectile = Instantiate (Resources.Load ("Projectile", typeof(GameObject))) as GameObject;
			projectile.GetComponent<Projectile> ().SetupProjectile (range, activeAngle + angle);
			projectile.transform.parent = this.transform;
            projectile.transform.localPosition = Vector3.zero;

		}

	}
}
