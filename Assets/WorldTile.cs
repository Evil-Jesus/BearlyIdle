using UnityEngine;
using System.Collections;

public class WorldTile : MonoBehaviour {

	public int posX;
	public int posY;

	public string tileName = "tileName";

	// Use this for initialization
	void Start () {
	}

	public void changeTile (GameObject newTileGo){
		WorldTile newWt = newTileGo.GetComponent<WorldTile> ();
		SpriteRenderer newSpr = newTileGo.GetComponent<SpriteRenderer> ();

		tileName = newWt.tileName;
		GetComponent<SpriteRenderer> ().sprite = newSpr.sprite;

	}

	void OnMouseDown(){
		placeJob ();
	}

	public void placeJob (){
		if (MenuController.selectedJob != null) {
			foreach (string curKey in MenuController.selectedJob.GetComponent<Job>().acceptedKeys) {
				if (curKey == tileName) {
					if (transform.childCount == 0) {
						GameObject newJob = Instantiate (MenuController.selectedJob, transform.position, Quaternion.identity) as GameObject;
						newJob.transform.SetParent (transform);
						newJob.GetComponent<Job> ().wt = this;
						GameObject.Find ("WorldMaster").GetComponent<WorldMaster> ().WorldJobs.Add (newJob.GetComponent<Job> ());
						newJob.GetComponent<Job> ().spr = newJob.GetComponent<SpriteRenderer> ();
					}
				}
			}
		}
	}
}
