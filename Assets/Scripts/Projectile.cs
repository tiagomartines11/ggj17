using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	float pRange;
	float pAngle;
	float pSpeed = 0.2f;
	AudioController audioController;

	Vector3 dir;

	// Use this for initialization
	void Start () {
		
		audioController = GameObject.FindObjectOfType<AudioController> ();
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
			//Debug.Log (this.transform.localPosition.magnitude);
			GameObject.Destroy (gameObject);
            GameObject.FindObjectOfType<GameStateManager>().UpdateGameState();

        }
	}

	void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Eletron") && collision.transform.parent.gameObject != transform.parent.gameObject)
        {
            GameObject.Destroy(gameObject);
            collision.transform.parent.gameObject.GetComponent<PointBehaviour>().activate();
            GameObject.FindObjectOfType<GameStateManager>().UpdateGameState();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shield"))
        {
			audioController.playShieldDestroy ();
            GameObject.Destroy(gameObject);
            GameObject.FindObjectOfType<GameStateManager>().UpdateGameState();
        }
    }
}
