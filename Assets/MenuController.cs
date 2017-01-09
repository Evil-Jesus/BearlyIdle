using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	public static Job selectedJob; //This is the job that will be attempted placed when clicking tiles

	public List<GameObject> Menus;

	public void closeAll(){
		foreach (GameObject curMenu in Menus) {
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
}
