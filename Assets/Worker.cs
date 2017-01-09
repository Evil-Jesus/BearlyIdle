using UnityEngine;
using System.Collections;

public class Worker : Movement {

	public string state = "idle";
	Job curJob;

	public float Energy = 100;

	public void tick(){
		moveTick ();
	}

	// Use this for initialization
	void Start () {
		move (5, 7);
		InvokeRepeating ("tick", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Energy < 10) {
			if (Energy < 0) {
				Sleep (100);
			} else {
				FindBed ();
			}
		}
	}

	public void FindBed (){
		
	}

	public void Sleep (float targetEnergy){
		state = "sleeping";
		if (Energy < targetEnergy) {
			Energy += 10 * Time.deltaTime;
			Sleep (targetEnergy);
		} else {
			state = "idle";
		}
	}
}
