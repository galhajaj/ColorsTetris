using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X;
    public int Y;
}

public class Piece : MonoBehaviour 
{
    public List<Point> Points = new List<Point>();

	// Use this for initialization
	void Start () 
    {
        GenerateRandom();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void GenerateRandom()
    {
        Points.Clear();

        int rand = Random.Range(0, 7);

        // ##
        // ##
        if (rand == 0)
        {
            Points.Add(new Point(5, 18));
            Points.Add(new Point(6, 18));
            Points.Add(new Point(5, 19));
            Points.Add(new Point(6, 19));
        }
        // ###
        // #
        if (rand == 1)
        {
            Points.Add(new Point(5, 18));
            Points.Add(new Point(7, 19));
            Points.Add(new Point(5, 19));
            Points.Add(new Point(6, 19));
        }
        // ###
        //   #
        if (rand == 2)
        {
            Points.Add(new Point(7, 18));
            Points.Add(new Point(7, 19));
            Points.Add(new Point(5, 19));
            Points.Add(new Point(6, 19));
        }
        // ###
        //  #
        if (rand == 3)
        {
            Points.Add(new Point(6, 18));
            Points.Add(new Point(7, 19));
            Points.Add(new Point(5, 19));
            Points.Add(new Point(6, 19));
        }
        // ####
        // 
        if (rand == 4)
        {
            Points.Add(new Point(4, 19));
            Points.Add(new Point(7, 19));
            Points.Add(new Point(5, 19));
            Points.Add(new Point(6, 19));
        }
        // ##
        //  ##
        if (rand == 5)
        {
            Points.Add(new Point(6, 18));
            Points.Add(new Point(7, 18));
            Points.Add(new Point(5, 19));
            Points.Add(new Point(6, 19));
        }
        //  ##
        // ##
        if (rand == 6)
        {
            Points.Add(new Point(6, 19));
            Points.Add(new Point(7, 19));
            Points.Add(new Point(5, 18));
            Points.Add(new Point(6, 18));
        }
    }
}
