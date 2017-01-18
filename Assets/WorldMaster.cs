using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldMaster : MonoBehaviour {

	public static bool debug = true;

	public GameObject[] WorldTilePrefabs;
	public GameObject workerPrefab;

	public WorldTile[,] WorldTiles;

	public List<Job> WorldJobs;
	public List<Worker> workers;

	// Use this for initialization
	void Start () {
		genMap (50, 50);
		Worker.wm = this;
		InvokeRepeating ("tick", 0.0f, 0.5f);
	}

	public void tick(){

		//Trigger all self sustained jobs
		foreach (Job curJob in WorldJobs) {
			if (curJob.needWorker == false) {
				curJob.doJob ();
			}
		}

		//Trigger all workers
		foreach (Worker curWorker in workers) {
			curWorker.tick ();
		}
	}

	public void addWorker (){
		Instantiate (workerPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
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
				curWT.posX = x;
				curWT.posY = y;
				WorldTiles [x, y] = curWT;
			}
		}
	}
}
