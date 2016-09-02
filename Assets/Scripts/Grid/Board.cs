using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Board : MonoBehaviour 
{
	public int BoardSizeX;
	public int BoardSizeY;
	public Transform TilePrefab;

    public List<Transform> Tiles = new List<Transform>();
    private Dictionary<string, Tile> _tilesDictioanry = new Dictionary<string, Tile>();

    void Start () 
	{
		generateTiles();
	}

    private void generateTiles()
	{
		float boardOriginX = this.transform.position.x;
		float boardOriginY = this.transform.position.y;
		float tileWidth = TilePrefab.GetComponent<SpriteRenderer> ().bounds.size.x;
		float tileHeight = TilePrefab.GetComponent<SpriteRenderer> ().bounds.size.y;
		
		for ( int x = 0; x < BoardSizeX; x++ ) 
		{
			for ( int y = 0; y < BoardSizeY; y++ ) 
			{
				Vector3 tilePosition = new Vector3(boardOriginX + (x * tileWidth), boardOriginY + (y * tileHeight), 0);
				Transform tile = (Transform)Instantiate(TilePrefab, tilePosition, Quaternion.identity);
				tile.name = "Tile" + x + y;
				tile.parent = this.transform;

                Tile tileScript = tile.GetComponent<Tile>();

                tileScript.PosX = x;
                tileScript.PosY = y;

                Tiles.Add(tile);
                _tilesDictioanry[x.ToString() + "-" + y.ToString()] = tileScript;
			}
		}
	}

    public Tile GetTile(int x, int y)
    {
        return _tilesDictioanry[x.ToString() + "-" + y.ToString()];
    }

    public bool IsPointsInsideBoard(List<Point> points)
    {
        foreach (Point p in points)
        {
            if (p.X < 0 || p.X >= BoardSizeX)
                return false;
            if (p.Y < 0 || p.X >= BoardSizeY)
                return false;
        }
        return true;
    }

    public bool CheckFullLine(int lineNumber)
    {
        for (int i = 0; i < BoardSizeX; ++i)
        {
            if (!GetTile(i, lineNumber).IsFull)
                return false;
        }
        return true;
    }

    public void ClearLine(int lineNumber)
    {
        for (int i = 0; i < BoardSizeX; ++i)
        {
            GetTile(i, lineNumber).Color = Color.white;
        }
    }

    public void CollapseOnLine(int lineNumber)
    {
        for (int j = lineNumber; j < BoardSizeY - 1; ++j)
        {
            for (int i = 0; i < BoardSizeX; ++i)
            {
                GetTile(i, j).Color = GetTile(i, j + 1).Color;
            }
        }
        ClearLine(BoardSizeY - 1);
    }
}
