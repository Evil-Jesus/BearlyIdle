using UnityEngine;
using System.Collections;

public class Job_PlantTrees : Job {

	public GameObject growTreePrefab = null;

	public override void doJob ()
	{
		base.doJob ();

		//add code for tool checking here
		//apply additional progress bonus based on tool

		if (progress >= targetProgress) {
			MenuController.selectedJob = growTreePrefab;
			transform.parent.GetComponent<WorldTile> ().placeJob (true);
			base.delJob ();
		}
	}
}
