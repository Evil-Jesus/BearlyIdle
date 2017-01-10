using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	public Job selectedJob; //This is the job that will be attempted placed when clicking tiles

	public List<GameObject> menusT1;
	public List<GameObject> menusT2;

	public List<Job> Jobs;

	public void closeAll(){
		
		foreach (GameObject curMenu in menusT1) {
			curMenu.SetActive (false);
		}

		foreach (GameObject curMenu in menusT2) {
			curMenu.SetActive (false);
		}
	}

	public void openMenu (GameObject menu) {
		if (menu != null) {
			bool newActive = !menu.activeSelf; // Invert active state.
			closeAll();
			menu.SetActive (newActive);
		}
	}

	public void setSelectedJob (string newJob){
		foreach (Job curJob in Jobs) {
			if (curJob.GetType ().Name == newJob) {
				selectedJob = curJob;
			}
		}
	}
}
