using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class JsonSchema {
    public int BoardSize;
    public int RedBall;
    public int BlueBall;
    public int RedHole;
    public int BlueHole;
    public List<int> Obstacles;

    public JsonSchema() {
        BoardSize = 0;
        RedBall = 100;
        BlueBall = 100;
        RedHole = 100;
        BlueHole = 100;
        Obstacles = new List<int>();
    }
}