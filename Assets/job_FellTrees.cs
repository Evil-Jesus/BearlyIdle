using UnityEngine;
using System.Collections;

public class job_FellTrees : Job {

	public GameObject replaceingWorldTile = null;

	public override void doJob(){
		base.doJob ();
		//add code for tool checking here
		//apply additional progress bonus based on tool

		if (progress >= targetProgress) {
			GetComponentInParent<WorldTile> ().changeTile (replaceingWorldTile);
			Inventory.noOakLogs += Random.Range (1, 3);
			Inventory.noOakSaplings += Random.Range (0, 5);
			base.delJob ();
		}
	}
}
