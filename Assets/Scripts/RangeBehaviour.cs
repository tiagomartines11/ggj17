using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointBehaviour))]
public class RangeBehaviour : MonoBehaviour {

    private PointBehaviour pointBehaviour;
    private GameObject rangeSprite;

	// Use this for initialization
	void Start () {
        pointBehaviour = gameObject.GetComponent<PointBehaviour>();
        rangeSprite = gameObject.transform.Find("Range").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        rangeSprite.transform.localScale = new Vector3(pointBehaviour.Range * 2, pointBehaviour.Range * 2, 0);
    }

    void OnMouseExit()
    {
        rangeSprite.transform.localScale = new Vector3(0, 0, 0);
    }
}
