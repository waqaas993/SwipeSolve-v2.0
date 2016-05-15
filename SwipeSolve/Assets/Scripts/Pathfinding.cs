using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class Pathfinding : MonoBehaviour
{

    int BoardSize;
    private int[,] map;
    private JsonSchema JsonObject;
    private int row;
    private int col;

    // Use this for initialization
    public void StartSearch()
    {

        BoardSize = PlayerPrefs.GetInt("CurrentLevelEditor");
        JsonObject = JsonUtility.FromJson<JsonSchema>(CreateLevel.JsonString);

        if (BoardSize == 5)
        {
            map = new int[5, 5]{
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0},
            {0,0,0,0,0}
            };
        }

        else if (BoardSize == 6)
        {
            map = new int[6, 6]{
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
            };
        }

        //Mapping 1D index into 2D Indexes for Obstacles
        foreach (int index in JsonObject.Obstacles)
        {
            col = index % BoardSize;
            row = index / BoardSize;
            map[row, col] = 1;
        }

        var graph = new Graph(map);
        var blueSearch = new Search(graph);
        var redSearch = new Search(graph);

        try
        {
            blueSearch.Start(graph.nodes[JsonObject.BlueBall], graph.nodes[JsonObject.BlueHole]);
            while (!blueSearch.finished)
                blueSearch.Step();

            redSearch.Start(graph.nodes[JsonObject.RedBall], graph.nodes[JsonObject.RedHole]);
            while (!redSearch.finished)
                redSearch.Step();

            if (redSearch.path.Count != 0 && blueSearch.path.Count != 0)
                Debug.Log("Level Solvable!");
            else
                Debug.Log("Level NOT Solvable!");
        }


        catch (Exception)
        {
            Debug.Log("Please place complete set of ingredients necessary for a Level");
        }
    }
}