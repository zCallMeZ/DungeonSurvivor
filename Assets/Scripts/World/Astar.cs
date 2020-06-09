 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar
{
    [SerializeField] Spot[,] spots;
}

public class Spot
{
    public int f = 0;
    public int g = 0;
    public int h = 0;

}
