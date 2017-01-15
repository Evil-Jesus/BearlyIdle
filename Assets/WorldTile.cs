using UnityEngine;
using System.Collections;

public class WorldTile : MonoBehaviour {

	public bool hasJob = false;
	public int posX;
	public int posY;

	public string tileName = "tileName";

	public SpriteRenderer spr = null;

	// Use this for initialization
	void Start () {
			spr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

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
					}
				}
			}
		}
	}
}
