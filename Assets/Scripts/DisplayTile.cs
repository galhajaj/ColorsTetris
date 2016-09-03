using UnityEngine;
using System.Collections;

public class DisplayTile : MonoBehaviour 
{
    public float Speed;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - Speed * Time.deltaTime, this.transform.position.z);

        if (this.transform.position.y <= -6.0F)
            Destroy(this.gameObject);
	}
}
