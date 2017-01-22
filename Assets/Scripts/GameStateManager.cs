using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameStateManager : MonoBehaviour
{

    private List<PointBehaviour> goals, subgoals, points;
    private UIController uiController;

    public Sprite HudGoalTexture;
    public Sprite HudSubGoalTexture;

    private Transform goalsPanel;
    private Transform subGoalsPanel;

    // Use this for initialization
    void Start()
    {
        goals = new List<PointBehaviour>();
        subgoals = new List<PointBehaviour>();
        points = new List<PointBehaviour>();

        var allPoints = Object.FindObjectsOfType<PointBehaviour>();
        for (int i = allPoints.Length - 1; i >= 0; i--)
        {
            if (allPoints[i].Type == PointBehaviour.PointTypes.Goal) goals.Add(allPoints[i]);
            if (allPoints[i].Type == PointBehaviour.PointTypes.SubGoal) subgoals.Add(allPoints[i]);
            if (allPoints[i].Type == PointBehaviour.PointTypes.Point) points.Add(allPoints[i]);
        }

        goalsPanel = transform.Find("HUD").Find("PanelGoals");
        subGoalsPanel = transform.Find("HUD").Find("PanelSubGoals");
        for (int i = 0; i < goals.Count; i++) goalsPanel.GetChild(i).gameObject.SetActive(true);
        for (int i = 0; i < subgoals.Count; i++) subGoalsPanel.GetChild(i).gameObject.SetActive(true);
        uiController = GetComponent<UIController>();
    }

    public void UpdateGameState()
    {
        int goalsC = 0;
        int subgoalsC = 0;
        bool hasAmmo = false;

        foreach (var goal in goals)
        {
            if (goal.activated) goalsC++;
        }

        foreach (var goal in subgoals)
        {
            if (goal.activated) subgoalsC++;
        }

        foreach (var point in points)
        {
            if (point.Ammo > 0 && point.activated) { hasAmmo = true; break; }
        }

        for (int i = 0; i < goalsC; i++) goalsPanel.GetChild(i).gameObject.GetComponent<Image>().sprite = HudGoalTexture;
        for (int i = 0; i < subgoalsC; i++) subGoalsPanel.GetChild(i).gameObject.GetComponent<Image>().sprite = HudSubGoalTexture;

        if (goalsC >= goals.Count)
        {
            //Debug.Log("WON");
            uiController.SetupEndScreen(true, goalsC, goals.Count, subgoalsC, subgoals.Count);
            return;
        }

        if (!hasAmmo)
        {
            //Debug.Log("LOST");
            uiController.SetupEndScreen(false, goalsC, goals.Count, subgoalsC, subgoals.Count);
            return;
        }
    }
}
