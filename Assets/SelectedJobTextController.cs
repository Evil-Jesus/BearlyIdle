using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectedJobTextController : MonoBehaviour {

	public Text txt = null;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (MenuController.selectedJob != null) {
			txt.text = MenuController.selectedJob.name;
		} else {
			txt.text = "None";
		}
	}
}
