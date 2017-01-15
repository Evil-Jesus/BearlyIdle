using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Job : MonoBehaviour {

	public List<string> acceptedKeys;
	public WorldTile wt;

	public void delJob (){
		GameObject.Find ("WorldMaster").GetComponent<WorldMaster> ().WorldJobs.Remove (this);
	}
}
