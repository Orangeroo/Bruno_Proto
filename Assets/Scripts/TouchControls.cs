using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	void Update () 
	{
		// Touch controls
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			
			if( touch.phase == TouchPhase.Began )
			{
				checkTouch(Input.GetTouch(0).position);
			}
		}
	}
	
	bool checkTouch( Vector3 pos)
	{
		Vector3 wp = Camera.main.ScreenToWorldPoint (pos);
		Vector2 touchPos = new Vector2 (wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint (touchPos);

		if (hit != null && hit.transform.gameObject.tag == "GUI") 
		{
			hit.transform.gameObject.SendMessage ("OnTouch", 0, SendMessageOptions.DontRequireReceiver);

			return true;
		}

		return false;
		
	}
}
