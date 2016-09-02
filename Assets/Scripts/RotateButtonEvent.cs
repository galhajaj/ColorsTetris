using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RotateButtonEvent : MonoBehaviour, IPointerDownHandler
{
    public GameLoop GameLoopScript;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        GameLoopScript.Rotate();
    }
}
