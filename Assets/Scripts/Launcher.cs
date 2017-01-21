using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	public int[] projectileAngles;
	public float aimDistance = 3;
	float activeAngle = 0.0f;
	private PointBehaviour point;
	public float angularSpeed = 2.0f;

	GameObject aimContainer;

	// Use this for initialization
	void Start () {

		///save references
		point = gameObject.GetComponent<PointBehaviour>();

		///code
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
        if (point.activated && point.Ammo > 0) {
            launch();
            point.Ammo -= 1;
		}
	}

	// Update is called once per frame
	void Update () {

		if (activeAngle < 360)
			activeAngle += angularSpeed;
		else
			activeAngle = 0;
		
		Quaternion rot = new Quaternion ();
		rot.eulerAngles = new Vector3 (0, 0, activeAngle);
		aimContainer.transform.rotation = rot;
	}

    void OnDisable()
    {
        GameObject.Destroy(aimContainer);
        enabled = false;
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
			projectile.GetComponent<Projectile> ().SetupProjectile (aimDistance, activeAngle + angle);
			projectile.transform.parent = this.transform;
            projectile.transform.localPosition = Vector3.zero;

		}

	}
}
