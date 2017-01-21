using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBehaviour : MonoBehaviour
{
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
            ammoLabel.text = Ammo.ToString();
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
