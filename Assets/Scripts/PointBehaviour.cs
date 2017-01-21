using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBehaviour : MonoBehaviour
{
	public bool activated = false;
	public enum GoalType {Goal, SubGoal};
	public GoalType GoalTypes;

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

		if (!activated & ammoLabel)
            ammoLabel.enabled = false;
        else
            activate();
    }
		

	public void activate()
	{
		activated = true;
		ammoLabel.enabled = true;

        gameObject.GetComponent<Launcher>().enabled = true;
        gameObject.GetComponent<RangeBehaviour>().enabled = true;
        gameObject.GetComponent<ShieldBehaviour>().enabled = false;
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
