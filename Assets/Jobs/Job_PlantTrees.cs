﻿using UnityEngine;
using System.Collections;

public class Job_PlantTrees : Job
{

    public GameObject growTreePrefab = null;

    public override void doJob()
    {
        base.doJob();

        //add code for tool checking here
        //apply additional progress bonus based on tool

        if (progress >= targetProgress)
        {
            if (Inventory.noOakSaplings >= 1)
            {
                Inventory.noOakSaplings -= 1;

                MenuController.selectedJob = growTreePrefab;
                transform.parent.GetComponent<WorldTile>().placeJob(true);
                base.delJob();
            }
        }
    }

    public override void jobOverlayTick()
    {
        base.jobOverlayTick();

        //checks if job can be done
        if (Inventory.noOakSaplings >= 1)
        {
            canDoJob = true;
        }
        else {
            canDoJob = false;
            fireWorker();
        }
    }
}
