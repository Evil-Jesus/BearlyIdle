using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Worker : MonoBehaviour {

	public static WorldMaster wm;
	public string state = "idle";
	public GameObject target = null;
	public Vector3 baseStats = new Vector3 (5.0f, 5.0f, 3.0f);

	public void Start(){
		GameObject.Find ("WorldMaster").GetComponent<WorldMaster> ().workers.Add (this);
	}

	public void tick (){
		if (state == "idle") {

			//Find a job
			if (target != null) {
				setState ("moving");
			} else {
				findJob ();
			}

		} else if (state == "moving") {

			//If there is a target to move to
			if (target != null) {

				//If not at target location
				if (transform.position != target.transform.position) {
					step (); //Move towards target location
					//print ("stepping");

				} else {

					//If target is a job
					if (target.GetComponent<Job> () != null) {
						setState ("working");
					}

				}

				//If the target got deleted or lost
			} else {
				setState ("idle");
			}
		} else if (state == "working") {
			
			//if target is still a job
			if (target.GetComponent<Job> () != null) {
				//trigger doJob()
				target.GetComponent<Job> ().doJob ();
			} else {
				setState ("idle");
			}
		}
	}

	public List<string> acceptedStates;
	public void setState (string newState){
		foreach (string curState in acceptedStates) {
			if (newState == curState) {
				state = newState;
				if (newState == "idle") {
					target = null;
				}
			}
		}
	}

	public void step(){
		float newX = transform.position.x;
		float newY = transform.position.y;

		// x value
		if (x () < tx ()) {
			newX = x () + 1;
		}
		if (x () > tx ()) {
			newX = x () - 1;
		}

		// y value
		if (y () < ty ()) {
			newY = y () + 1;
		}
		if (y () > ty ()) {
			newY = y () - 1;
		}

		//move
		transform.position = new Vector3 (newX, newY, 0);
	}

	public int x(){
		return(Mathf.RoundToInt (transform.position.x));
	}

	public int tx(){
		if (target != null) {
			return(Mathf.RoundToInt (target.transform.position.x));
		} else {
			return(-1);
		}
	}

	public int y(){
		return(Mathf.RoundToInt (transform.position.y));
	}

	public int ty(){
		if (target != null) {
			return(Mathf.RoundToInt (target.transform.position.y));
		} else {
			return(-1);
		}
	}


	public void findJob (){
		foreach (Job curJob in wm.WorldJobs) {
			if (curJob.needWorker == true) {
				if (curJob.canDoJob == true) {
					if (curJob.assignedWorker == null) {
						curJob.assignedWorker = this;
						target = curJob.gameObject;
						return;
					}	
				}
			}
		}
	}
}
