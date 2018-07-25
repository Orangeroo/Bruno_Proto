using UnityEngine;
using System.Collections;

public class DashLimiter : MonoBehaviour {

	void Start ()
    {
		transform.position = new Vector2 (Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0)).x, 0);
	}

}
