﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour 
{
	public int PosX;
	public int PosY;

	private bool _isSelected = false;
	public bool IsSelected
	{
		get { return _isSelected; }
		set 
		{ 
			_isSelected = value; 
		}
	}

	void Start () 
	{

	}

    void Update () 
	{
	
	}

    private void updateFrameColor()
	{

	}
}
