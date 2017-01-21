using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void SetupScreen(bool isWin, int goalScore, int subGoalScore)
	{
		gameObject.transform.Find("goalScore").GetComponent<Text>().text = goalScore.ToString();
		gameObject.transform.Find("subGoalScore").GetComponent<Text>().text = subGoalScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
