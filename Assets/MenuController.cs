using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	public static bool delMode = false;

	public List<GameObject> menusT1;
	public List<GameObject> menusT2;

	public List<Job> Jobs;
	public static GameObject selectedJob;

	public void Update (){
		if (Input.GetMouseButtonDown (1)) {
			delMode = false;
			selectedJob = null;
			closeAll ();
		}
	}

	public void setDelMode(){
		delMode = true;
		selectedJob = null;
		closeAll ();
	}

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

	public void setSelectedJob (GameObject newJob){
		selectedJob = newJob;
	}
}
