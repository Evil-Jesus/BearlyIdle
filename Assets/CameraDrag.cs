using UnityEngine;
using System.Collections;
 
// Attach to orthographic camera with rotation (0,0,0)
public class CameraDrag : MonoBehaviour {
 
    private Vector3 startMousePos;
	public Camera cam = null;
 
    void Update() {

		if (Input.GetMouseButtonDown (0)) {
			startMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			startMousePos.z = 0.0f;
		}
 
		if (Input.GetMouseButton (0)) {
			Vector3 nowMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			nowMousePos.z = 0.0f;
			transform.position += startMousePos - nowMousePos;
		}

		if (Input.mouseScrollDelta.y != 0) {
			cam.orthographicSize -= Input.mouseScrollDelta.y;
		}

		if (cam.orthographicSize > 12) {
			cam.orthographicSize = 12;
		}

		if (cam.orthographicSize < 4) {
			cam.orthographicSize = 4;
		}
	}
}