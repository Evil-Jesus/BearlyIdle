using UnityEngine;
using System.Collections;

public class WorldTile : MonoBehaviour {

	public bool hasJob = false;
	public int posX;
	public int posY;

	public string tileName = "tileName";

	public SpriteRenderer spr = null;

	// Use this for initialization
	void Start () {
			spr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnMouseDown(){
		Ref.WM.placeJob (posX, posY);
	}
}
