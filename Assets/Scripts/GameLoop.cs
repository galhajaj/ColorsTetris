using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour 
{
    public Piece Piece;
    public Board Board;

    public float StepTime = 0.5F;
    private float _timePassed = 0.0F;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        _timePassed -= Time.deltaTime;
        if (_timePassed <= 0.0F)
        {
            _timePassed = StepTime;

            // DO THINGS!

            // delete piece
            foreach (Point p in Piece.Points)
                Board.GetTile(p.X, p.Y).Color = Color.white;

            // check if can move down
            if (IsPieceCanMoveDown())
            {
                // move one step down
                foreach (Point p in Piece.Points)
                    p.Y--;
                // draw piece
                foreach (Point p in Piece.Points)
                    Board.GetTile(p.X, p.Y).Color = Color.blue;
            }
            else
            {
                // draw piece
                foreach (Point p in Piece.Points)
                    Board.GetTile(p.X, p.Y).Color = Color.blue;

                Piece.GenerateRandom();
            }
        }
	}

    private bool IsPieceCanMoveDown()
    {
        bool isCan = true;

        foreach (Point p in Piece.Points)
        {
            if (p.Y == 0)
                return false;

            Tile downTile = Board.GetTile(p.X, p.Y - 1);
            if (Piece.Points.Contains(new Point(downTile.PosX, downTile.PosY)))
                continue;
            if (downTile.IsFull)
                return false;
        }

        return isCan;
    }
}
