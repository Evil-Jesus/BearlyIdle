using UnityEngine;
using System.Collections;

public class Job_MineRocks : Job {

	public WT_Rocks qHolder = null;

	public GameObject replaceingWorldTile = null;

	public override void doJob(){
		base.doJob ();

		//add code for tool checking here
		//apply additional progress bonus based on tool

		if (progress >= targetProgress) {
			if (qHolder != null) {
			
				Inventory.noRocks += 1;
				qHolder.quantity -= 1;
				progress = 0;

				if (qHolder.quantity <= 0) {
					Destroy (GetComponentInParent<WorldTile> ());
					WorldTile newWT = transform.parent.gameObject.AddComponent<WT_Planes> ();
					newWT.changeTile (replaceingWorldTile);
					base.delJob ();
				}
			}
		} else {
			qHolder = GetComponentInParent<WT_Rocks> ();
		}
	}
}
