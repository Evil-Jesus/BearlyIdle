using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int tileX = 0;
	public int tileY = 0;
	public Vector2 target;

	// Use this for initialization
	void Start () {

	}

	public void move(int x, int y){
		target = new Vector2 (x, y);
	}

	public void moveTick (){

		//X axis
		if (target.x > tileX) {
			tileX += 1;
		} if ((target.x < tileX)) {
			tileX -= 1;
		}

		//Y axis
		if (target.y > tileY) {
			tileY += 1;
		} if (target.y < tileY) {
			tileY -= 1;
		}

		//Move towards
		transform.position = new Vector3 (tileX, tileY, 0);
	}
}
