using UnityEngine;
using System.Collections;

public class CameraFolllowWithDash : MonoBehaviour {

	void FixedUpdate ()
    {
		Vector2 followerPosition = PlayerCameraFollower.Instance.gameObject.transform.position;
		transform.position = new Vector3(followerPosition.x, followerPosition.y, transform.position.z);
	}
}
