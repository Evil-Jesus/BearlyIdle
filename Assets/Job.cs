using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Job : MonoBehaviour {

	public List<string> acceptedKeys;
	public WorldTile wt;

	public bool needWorker = true;
	public Worker assignedWorker;

	public float progress = 0;
	public float targetProgress = 100;
	public Vector3 statScale = new Vector3 (1.0f, 1.0f, 1.0f);  // progress points per stat point scale ( Str, Agi, Int )

	public SpriteRenderer spr = null;

	void FixedUpdate(){
		jobOverlayTick ();
	}

	public virtual void delJob (){
		GameObject.Find ("WorldMaster").GetComponent<WorldMaster> ().WorldJobs.Remove (this);
		assignedWorker.setState ("idle");
		Destroy (gameObject);
	}

	//if there is anything that needs to be given back
	//to the player when canceling the job this is the one to override
	public virtual void cancelJob(){
		delJob ();
	}

	public virtual void doJob (){
		//add progress
		progress += assignedWorker.baseStats.x * statScale.x;
		progress += assignedWorker.baseStats.y * statScale.y;
		progress += assignedWorker.baseStats.z * statScale.z;
	}

	public void jobOverlayTick(){
		if (spr != null) {
			if (!needWorker) {
				spr.enabled = false;
			} else {
				if (assignedWorker != null) {
					spr.color = new Color (0f, 0.8f, 0f, 0.5f);
				} else {
					spr.color = new Color (0.8f, 0.8f, 0f, 0.5f);
				}
			}
		} else {
			print ("spr(SpriteRenderer) is not valid at " + this);
		}
	}
}
