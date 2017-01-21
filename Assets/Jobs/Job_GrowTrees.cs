using UnityEngine;
using System.Collections;

public class Job_GrowTrees : Job
{

    public GameObject replacingWorldTile = null;

    public override void doJob()
    {
        progress += 5;

        if (progress >= targetProgress)
        {
            Destroy(GetComponentInParent<WorldTile>());
            WorldTile newWT = transform.parent.gameObject.AddComponent<WT_Planes>();
            newWT.changeTile(replacingWorldTile);
            Invoke("delJob", 0f); //Why do I need to invoke this?
        }
    }
}
