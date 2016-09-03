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
    public bool IsRotatable { get; set; }

    public List<Point> Points = new List<Point>();

    public List<Point> PointsAfterRotate
    {
        get
        {
            List<Point> points = new List<Point>();

            points.Add(Points[0]);

            for (int i = 1; i < Points.Count; ++i)
            {
                Point v_r = new Point(Points[i].X - Points[0].X, Points[i].Y - Points[0].Y);
                Point v_t = new Point( -1 * v_r.Y, 1 * v_r.X );
                Point v_new = new Point( Points[0].X + v_t.X, Points[0].Y + v_t.Y );
                points.Add(v_new);
            }

            return points;
        }
    }

    private Color _color = Color.white;
    public Color Color
    {
        get { return _color; }
        set { _color = value; }
    }

	// Use this for initialization
	void Start () 
    {
        GenerateRandom();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public bool IsContainsTile(Tile tile)
    {
        foreach (Point p in Points)
        {
            if (p.X == tile.PosX && p.Y == tile.PosY)
                return true;
        }
        return false;
    }

    private void generateRandomColor()
    {
        int rand = Random.Range(0, 4);
        if (rand == 0)
            Color = Color.blue;
        else if (rand == 1)
            Color = Color.red;
        else if (rand == 2)
            Color = Color.yellow;
        else if (rand == 3)
            Color = Color.green;
    }

    public void GenerateRandom()
    {
        generateRandomColor();
        Points.Clear();

        int rand = Random.Range(0, 7);

        // ##
        // ##
        if (rand == 0)
        {
            IsRotatable = false;
            Points.Add(new Point(4, 18));
            Points.Add(new Point(5, 18));
            Points.Add(new Point(4, 19));
            Points.Add(new Point(5, 19));
        }
        // ###
        // #
        if (rand == 1)
        {
            IsRotatable = true;
            Points.Add(new Point(5, 19));
            Points.Add(new Point(4, 19));
            Points.Add(new Point(4, 18));
            Points.Add(new Point(6, 19));
        }
        // ###
        //   #
        if (rand == 2)
        {
            IsRotatable = true;
            Points.Add(new Point(5, 19));
            Points.Add(new Point(6, 19));
            Points.Add(new Point(6, 18));
            Points.Add(new Point(4, 19));
        }
        // ###
        //  #
        if (rand == 3)
        {
            IsRotatable = true;
            Points.Add(new Point(5, 19));
            Points.Add(new Point(5, 18));
            Points.Add(new Point(6, 19));
            Points.Add(new Point(4, 19));
        }
        // ####
        // 
        if (rand == 4)
        {
            IsRotatable = true;
            Points.Add(new Point(4, 19));
            Points.Add(new Point(3, 19));
            Points.Add(new Point(6, 19));
            Points.Add(new Point(5, 19));
        }
        // ##
        //  ##
        if (rand == 5)
        {
            IsRotatable = true;
            Points.Add(new Point(5, 19));
            Points.Add(new Point(5, 18));
            Points.Add(new Point(6, 18));
            Points.Add(new Point(4, 19));
        }
        //  ##
        // ##
        if (rand == 6)
        {
            IsRotatable = true;
            Points.Add(new Point(5, 19));
            Points.Add(new Point(6, 19));
            Points.Add(new Point(4, 18));
            Points.Add(new Point(5, 18));
        }
    }
}
