using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Job : MonoBehaviour
{

    public List<string> acceptedKeys;
    public WorldTile wt = null;

    public bool canDoJob = true;
    public bool needWorker = true;
    public Worker assignedWorker;

    public float progress = 0;
    public float targetProgress = 100;
    public Vector3 statScale = new Vector3(1.0f, 1.0f, 1.0f);  // progress points per stat point scale ( Str, Agi, Int )

    public SpriteRenderer spr = null;

    void FixedUpdate()
    {
        jobOverlayTick();
    }

    public virtual void delJob()
    {
        GameObject.Find("WorldMaster").GetComponent<WorldMaster>().WorldJobs.Remove(this);
        if (needWorker)
        {
            if (assignedWorker != null)
            {
                assignedWorker.setState("idle");
            }
        }
        Destroy(gameObject);
    }

    public virtual void doJob()
    {

        if (needWorker)
        {
            //add progress
            progress += assignedWorker.baseStats.x * statScale.x;
            progress += assignedWorker.baseStats.y * statScale.y;
            progress += assignedWorker.baseStats.z * statScale.z;
        }
    }

    //Visulizes if the job is being taken care of or not.
    public virtual void jobOverlayTick()
    {
        if (spr != null)
        {
            if (needWorker)
            {
                if (assignedWorker != null)
                {
                    spr.color = new Color(0f, 0.8f, 0f, 0.5f);
                }
                else {
                    spr.color = new Color(0.8f, 0.8f, 0f, 0.5f);
                }
            }
        }
        else {
            print("spr(SpriteRenderer) is not valid at " + this);
        }
    }

    public void fireWorker()
    {
        if (assignedWorker != null)
        {
            assignedWorker.setState("idle");
            assignedWorker.target = null;
            assignedWorker = null;
        }
    }
}
