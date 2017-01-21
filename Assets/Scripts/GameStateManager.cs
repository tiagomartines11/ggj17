﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameStateManager : MonoBehaviour
{

    private List<PointBehaviour> goals, subgoals, points;

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

    }

    public void Update()
    {
        bool allGoals = true;
        bool hasAmmo = false;

        foreach (var goal in goals)
        {
            Debug.Log("G" + goal.activated);
            if (!goal.activated) { allGoals = false; break; }
        }

        foreach (var point in points)
        {
            Debug.Log("P"+ point.Ammo);
            if (point.Ammo > 0 && point.activated) { hasAmmo = true; break; }
        }

        if (allGoals)
        {
            Debug.Log("WON");
            return;
        }

        if (!hasAmmo)
        {
            Debug.Log("LOST");
            return;
        }
    }
}