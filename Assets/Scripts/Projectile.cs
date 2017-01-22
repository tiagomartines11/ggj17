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
		this.transform.localPosition = this.transform.localPosition + pSpeed * dir;


		if (this.transform.localPosition.magnitude >= pRange) {
			Debug.Log (this.transform.localPosition.magnitude);
			GameObject.Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Eletron") && collision.transform.parent.gameObject.layer != transform.parent.gameObject.layer)
        {
            GameObject.Destroy(gameObject);
            collision.gameObject.GetComponent<PointBehaviour>().activate();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shield"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
