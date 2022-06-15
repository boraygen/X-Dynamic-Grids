using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkManager : MonoBehaviour
{
    public static MarkManager Instance { get; private set; }
    GameObject[] marks;
    GridManager gridManager;

    void Awake() 
    {
        Instance = this;
        gridManager = FindObjectOfType<GridManager>();
        marks = new GameObject[0];
    }

    public void SetMarks()
    {
        // HandleAdjacentMarks();
        marks = GameObject.FindGameObjectsWithTag("Mark");
        HandleAdjacentMarks();
    }

    void HandleAdjacentMarks()
    {
        if (marks.Length >= 3)
        {
            for (var i = 0; i < marks.Length; i++)
            {
                for (var k = 0; k < marks.Length; k++)
                {
                    if (i != k && CheckIfAdjacent(marks[i], marks[k]))
                    {
                        marks[i].GetComponent<Mark>().AddAdjacent(marks[k]);
                        marks[k].GetComponent<Mark>().AddAdjacent(marks[i]);
                    }
                }
            }
        }
    }

    bool CheckIfAdjacent(GameObject obj0, GameObject obj1)
    {
        float diffTolerated = 0.005f;
        float distance = Vector3.Distance(obj0.transform.position, obj1.transform.position);
        float diff = Math.Abs(distance - gridManager.tileSize);

        if (diff <= diffTolerated)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    

}
