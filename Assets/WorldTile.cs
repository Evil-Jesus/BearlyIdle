using UnityEngine;
using System.Collections;

public class WorldTile : MonoBehaviour {

	public string tileName = "tileName";

	public SpriteRenderer spr = null;

	// Use this for initialization
	void Start () {
			spr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
