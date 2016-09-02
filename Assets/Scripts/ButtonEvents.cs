using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float TimeBeforeSpeedMove = 1.5F;
    public float TimeOfSpeedMoveStep = 0.25F;
    private float _timeToStartSpeedMove;
    private float _timeToMove = 0.0F;

    private bool _isHold = false;

    public GameLoop GameLoopScript;
    public PieceDirection Direction;

	// Use this for initialization
	void Start () 
    {
        _timeToStartSpeedMove = TimeBeforeSpeedMove;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //_timeToMove -= Time.deltaTime;

        if (_isHold)
        {
            _timeToStartSpeedMove -= Time.deltaTime;
            if (_timeToStartSpeedMove <= 0.0F)
            {
                _timeToMove -= Time.deltaTime;

                if (_timeToMove <= 0.0)
                {
                    //Debug.Log("ACT!");
                    GameLoopScript.MovePiece(Direction);
                    _timeToMove = TimeOfSpeedMoveStep;
                }
            }
        }
        else
        {
            _timeToStartSpeedMove = TimeBeforeSpeedMove;
        }
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("DOWN");
        GameLoopScript.MovePiece(Direction);
        _isHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("UP");
        _isHold = false;
    }
}
