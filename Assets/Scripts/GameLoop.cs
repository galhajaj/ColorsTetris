using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum PieceDirection
{
    RIGHT,
    LEFT,
    DOWN
}

public class GameLoop : MonoBehaviour 
{
    public Piece Piece;
    public Board Board;

    public Text ScoreText;
    public Text MultiplyerText;

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
            if (IsPieceCanMove(PieceDirection.DOWN))
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

                removeFullLines();
                Piece.GenerateRandom();
            }
        }
	}

    private bool IsPieceCanMove(PieceDirection dir)
    {
        int dy = 0;
        int dx = 0;
        if (dir == PieceDirection.DOWN)
            dy = -1;
        if (dir == PieceDirection.RIGHT)
            dx = 1;
        else if (dir == PieceDirection.LEFT)
            dx = -1;

        bool isCan = true;

        foreach (Point p in Piece.Points)
        {
            if (dir == PieceDirection.DOWN)
            {
                if (p.Y <= 0)
                    return false;
            }
            else if (dir == PieceDirection.RIGHT)
            {
                if (p.X >= Board.BoardSizeX - 1)
                    return false;
            }
            else if (dir == PieceDirection.LEFT)
            {
                if (p.X <= 0)
                    return false;
            }

            Tile tileInDirection = Board.GetTile(p.X + dx, p.Y +dy);

            if (Piece.IsContainsTile(tileInDirection))
                continue;
            if (tileInDirection.IsFull)
            {
                return false;
            }
        }

        return isCan;
    }

    public void MovePieceRight()
    {
        movePiece(PieceDirection.RIGHT);
    }

    public void MovePieceLeft()
    {
        movePiece(PieceDirection.LEFT);
    }

    public void MovePieceDown()
    {
        movePiece(PieceDirection.DOWN);
    }

    public void Rotate()
    {
        List<Point> pointsAfterRotate = Piece.PointsAfterRotate;
        if (!Board.IsPointsInsideBoard(pointsAfterRotate))
            return;

        foreach (Point p in pointsAfterRotate)
        {
            Tile rotatedTile = Board.GetTile(p.X, p.Y);
            if (rotatedTile.IsFull)
            {
                if (!Piece.IsContainsTile(rotatedTile))
                    return;
            }
        }

        // delete piece
        foreach (Point p in Piece.Points)
            Board.GetTile(p.X, p.Y).Color = Color.white;

        // changeTiles
        Piece.Points = Piece.PointsAfterRotate;

        // draw piece
        foreach (Point p in Piece.Points)
            Board.GetTile(p.X, p.Y).Color = Color.blue;
    }

    private void movePiece(PieceDirection dir)
    {
        int dy = 0;
        int dx = 0;
        if (dir == PieceDirection.DOWN)
            dy = -1;
        if (dir == PieceDirection.RIGHT)
            dx = 1;
        else if (dir == PieceDirection.LEFT)
            dx = -1;
        
        if (!IsPieceCanMove(dir))
            return;

        // delete piece
        foreach (Point p in Piece.Points)
            Board.GetTile(p.X, p.Y).Color = Color.white;

        // move one step down
        foreach (Point p in Piece.Points)
        {
            p.X += dx;
            p.Y += dy;
        }

        // draw piece
        foreach (Point p in Piece.Points)
            Board.GetTile(p.X, p.Y).Color = Color.blue;
    }

    private void removeFullLines()
    {
        
    }
}
