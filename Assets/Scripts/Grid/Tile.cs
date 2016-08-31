using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour 
{
	public int PosX;
	public int PosY;

	/*private bool _isSelected = false;
	public bool IsSelected
	{
		get { return _isSelected; }
		set 
		{ 
			_isSelected = value; 
		}
	}*/
    
    public Color Color
    {
        get { return this.gameObject.GetComponent<SpriteRenderer>().color; }
        set { this.gameObject.GetComponent<SpriteRenderer>().color = value; }
    }

    public bool IsFull
    {
        get 
        { 
            if (this.Color == Color.white)
                return false;
            return true;
        }
    }

	void Start () 
	{

	}

    void Update () 
	{
	
	}

    /*public void SetColor(Color color)
	{
        this.gameObject.GetComponent<SpriteRenderer>().color = color;
	}*/
}
