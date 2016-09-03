using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayTiles : MonoBehaviour 
{
    public GameObject DisplayTileObj;
    public Sprite TileSprite1;
    public Sprite TileSprite2;
    public Sprite TileSprite3;
    public Sprite TileSprite4;
    public Sprite TileSprite5;

    public float TimeBetweenCreations = 0.5F;
    private float _timeToCreate = 0.0F;

    public int NumberOfTilesAtStartUp = 20;

    private List<GameObject> _tiles = new List<GameObject>();

    // Use this for initialization
    void Start () 
    {
        for (int i = 0; i < NumberOfTilesAtStartUp; ++i)
        {
            createTile(new Vector3(Random.Range(-4.0F, 4.0F), Random.Range(-6.0F, 6.0F), 0.0F));
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        _timeToCreate -= Time.deltaTime;

        if (_timeToCreate <= 0.0F)
        {
            _timeToCreate = TimeBetweenCreations;
            createTile(new Vector3(Random.Range(-4.0F, 4.0F), 6.0F, 0.0F));
        }
	}

    private void createTile(Vector3 position)
    {
        GameObject tile = Instantiate(DisplayTileObj, position, Quaternion.Euler(0.0F, 0.0F, 0.0F)) as GameObject;
        DisplayTile tileScript = tile.GetComponent<DisplayTile>();

        int rand = Random.Range(0, 5);
        if (rand == 0)
            tile.GetComponent<SpriteRenderer>().sprite = TileSprite1;
        else if (rand == 1)
            tile.GetComponent<SpriteRenderer>().sprite = TileSprite2;
        else if (rand == 2)
            tile.GetComponent<SpriteRenderer>().sprite = TileSprite3;
        else if (rand == 3)
            tile.GetComponent<SpriteRenderer>().sprite = TileSprite4;
        else if (rand == 4)
            tile.GetComponent<SpriteRenderer>().sprite = TileSprite5;

        rand = Random.Range(0, 4);
        if (rand == 0)
            tile.GetComponent<SpriteRenderer>().color = Color.red;
        else if (rand == 1)
            tile.GetComponent<SpriteRenderer>().color = Color.blue;
        else if (rand == 2)
            tile.GetComponent<SpriteRenderer>().color = Color.green;
        else if (rand == 3)
            tile.GetComponent<SpriteRenderer>().color = Color.yellow;

        rand = Random.Range(0, 3);
        if (rand == 0)
        {
            tile.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
            tileScript.Speed = 1.0F;
        }
        else if (rand == 1)
        {
            tile.transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
            tileScript.Speed = 0.5F;
        }
        else if (rand == 2)
        {
            tile.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);
            tileScript.Speed = 0.25F;
        }
    }
}
