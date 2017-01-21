using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBehaviour : MonoBehaviour
{
	public bool activated = false;
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
			ammoLabel.enabled = false;
		else
			gameObject.GetComponent<Launcher> ().enabled = true;
    }

	public void activate()
	{
		if (activated)
			return;

		activated = true;
		ammoLabel.enabled = true;

		gameObject.GetComponent<Launcher> ().enabled = true;
	}

    // Update is called once per frame
    void Update()
    {

    }
}
