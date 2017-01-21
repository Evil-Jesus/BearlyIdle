using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{

    public static int noOakLogs = 0; //The number of oak logs the player has
    [SerializeField]
    private int debug_noOakLogs = 0;

    public static int noOakSaplings = 1; //The number of oak saplings the player has
    [SerializeField]
    private int debug_noOakSaplings = 0;

    public static int noRocks = 0;
    [SerializeField]
    private int debug_noRocks = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WorldMaster.debug)
        {
            debug_noOakLogs = noOakLogs;
            debug_noOakSaplings = noOakSaplings;
            debug_noRocks = noRocks;
        }
    }
}
