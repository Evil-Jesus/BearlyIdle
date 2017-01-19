using UnityEngine;
using System.Collections;

public class WorldTile : MonoBehaviour {

	public int posX;
	public int posY;

	public string tileName = "tileName";

	// Use this for initialization
	public virtual void Start () {
		posX = Mathf.RoundToInt (transform.position.x);
		posY = Mathf.RoundToInt (transform.position.y);
		GameObject.Find ("WorldMaster").GetComponent<WorldMaster> ().WorldTiles [posX, posY] = this;
	}

	public void changeTile (GameObject newTileGo){
		WorldTile newWt = newTileGo.GetComponent<WorldTile> ();
		SpriteRenderer newSpr = newTileGo.GetComponent<SpriteRenderer> ();

		tileName = newWt.tileName;
		GetComponent<SpriteRenderer> ().sprite = newSpr.sprite;
	}

	void OnMouseDown(){
		placeJob (false);
	}

	public void placeJob (bool force){
		if (!MenuController.delMode) {
			if (MenuController.selectedJob != null) {
				foreach (string curKey in MenuController.selectedJob.GetComponent<Job>().acceptedKeys) {
					if (curKey == tileName) {
						if (transform.childCount == 0 || force) {
							GameObject newJob = Instantiate (MenuController.selectedJob, transform.position, Quaternion.identity) as GameObject;
							newJob.transform.SetParent (transform);
							newJob.GetComponent<Job> ().wt = this;
							GameObject.Find ("WorldMaster").GetComponent<WorldMaster> ().WorldJobs.Add (newJob.GetComponent<Job> ());
						}
					}
				}
			}
		} else {
			if (GetComponentInChildren<Job> () != null) {
				GetComponentInChildren<Job> ().delJob ();
			}
		}
	}
}
