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
        Transform which = gameObject.transform.Find(isWin ? "Win" : "Lose");
        which.Find("goalScore").GetComponent<Text>().text = goalScore.ToString();
        which.Find("subGoalScore").GetComponent<Text>().text = subGoalScore.ToString();
        which.gameObject.SetActive(true);
        gameObject.transform.Find("HUD").gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
