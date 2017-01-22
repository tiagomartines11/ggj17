﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBehaviour : MonoBehaviour
{
	public bool activated = false;
	public enum PointTypes {Point, Goal, SubGoal};
	public PointTypes Type;

    [SerializeField]
    private int _Ammo = 3;
    [SerializeField]
    private int _Range = 3;

    public int Ammo
    {
        get { return _Ammo; }
        set
        {
            _Ammo = value;
            if(ammoLabel) ammoLabel.text = Ammo.ToString();
            if (_Ammo == 0) deactivate();
        }
    }

    public int Range
    {
        get { return _Range; }
        set { _Range = value; }
    }

    private Text ammoLabel;

    // Use this for initialization
    void Start()
    {
        ammoLabel = GetComponentInChildren<Text>();
        Ammo = _Ammo;

        if (!activated)
        {
            if (ammoLabel) ammoLabel.enabled = false;
        }
        else {
            activate();
        }
    }



    public void activate()
    {
		///check if shields
		ShieldHPBehaviour shields = gameObject.GetComponent<ShieldHPBehaviour> ();

		if (shields.activeShields > 0) 
		{
			Debug.Log ("i have shields!");
			shields.disableShield ();

			if(shields.activeShields > 0)
				return;
		}

		activated = true;

		ammoLabel.enabled = true;

        gameObject.GetComponent<Launcher>().enabled = true;
        gameObject.GetComponent<RangeBehaviour>().enabled = true;
        gameObject.GetComponent<ShieldBehaviour>().enabled = false;
		gameObject.GetComponent<ShieldHPBehaviour>().enabled = false;
        gameObject.transform.Find("Base").GetComponent<Collider2D>().enabled = false;
    }

    public void deactivate()
    {
        activated = false;
        
        gameObject.GetComponent<Launcher>().enabled = false;
        gameObject.GetComponent<RangeBehaviour>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
