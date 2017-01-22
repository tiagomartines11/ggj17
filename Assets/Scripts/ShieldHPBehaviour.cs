using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHPBehaviour : MonoBehaviour {

	public int numShields;
	public int activeShields;
	float scaleValue = 0.2f;

	ArrayList shields;

	// Use this for initialization
	void Start () {
		shields = new ArrayList ();

		for (float i = 0; i < numShields; i++) 
		{
			GameObject instance = Instantiate(Resources.Load("ShieldHP", typeof(GameObject))) as GameObject;

			instance.transform.parent = this.transform;
			instance.transform.localPosition = Vector3.zero;
			instance.transform.localScale = new Vector3(1 + scaleValue * i,1+ scaleValue * i,0);

			activeShields++;

			shields.Add (instance);

			Debug.Log ("create shield");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void disableShield()
	{
		Debug.Log (activeShields);
		GameObject obj = (shields [activeShields-1]) as GameObject;
		shields.RemoveAt (activeShields-1);
		GameObject.Destroy(obj);
		activeShields--;
	}
}
