using UnityEngine;
using System.Collections;

public class WorldMaster : MonoBehaviour {

	public GameObject[] WorldTilePrefabs;

	public WorldTile[,] WorldTiles;

	// Use this for initialization
	void Start () {
		genMap (10, 10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Generate A New Map  |  insert x/y size of new map
	public void genMap (int genX, int genY){

		WorldTiles = new WorldTile[genX, genY];

		//From x-y to param1-param2 spawn new WorldTile in place
		for (int x = 0; x < genX; x++) {
			for (int y = 0; y < genY; y++) {

				Vector3 newPos = new Vector3 (x,y,0);
				int newIndex = Random.Range (0, WorldTilePrefabs.Length);

				GameObject newTile = Instantiate (WorldTilePrefabs [newIndex], newPos, Quaternion.identity) as GameObject;
				newTile.transform.SetParent (transform);
				WorldTile curWT = newTile.GetComponent<WorldTile> ();
				WorldTiles [x, y] = curWT;
			}
		}
	}
}
