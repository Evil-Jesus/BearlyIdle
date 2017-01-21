using UnityEngine;
using System.Collections;

public class job_FellTrees : Job
{

    public GameObject replaceingWorldTile = null;

    public override void doJob()
    {
        base.doJob();

        //add code for tool checking here
        //apply additional progress bonus based on tool

        if (progress >= targetProgress)
        {

            int rnd1 = Random.Range(1, 3);
            int rnd2 = Random.Range(0, 5);

            Inventory.noOakLogs += rnd1;
            Inventory.noOakSaplings += rnd2;

            string msg = "+" + rnd1 + " Log | +" + rnd2 + " Sapling";

            //mc.popOver (msg, transform.position);
            Destroy(GetComponentInParent<WorldTile>());
            WorldTile newWT = transform.parent.gameObject.AddComponent<WT_Planes>();
            newWT.changeTile(replaceingWorldTile);
            base.delJob();
        }
    }
}