using UnityEngine;
using System.Collections;

public class Job_GrowTrees : Job {

	public GameObject replacingWorldTile = null;

	public override void doJob () {
		progress += 5;

		if (progress >= targetProgress) {
			GetComponentInParent<WorldTile> ().changeTile (replacingWorldTile);
			Invoke ("delJob", 0f); //Why do I need to invoke this?
		}
	}
}
