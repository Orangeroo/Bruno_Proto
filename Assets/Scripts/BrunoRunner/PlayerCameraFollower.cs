using UnityEngine;
using System.Collections;

public class PlayerCameraFollower : MonoBehaviour {

	// singleton
	public static PlayerCameraFollower Instance;

	public GameObject player;
	private BrunoController playercontroller;
	public float xOffset =  3;	
	private bool readjust = false;
	public float velocityCatchUp;
    
    // y-axis
    public float yMargin = 1f;      // Distance in the y axis the player can move before the camera follows.
    public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
    public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.

	void Awake()
	{
		if(Instance != null)
		{
			Debug.LogError("More than one instace of PlayerCameraFollower");
		}

		Instance = this;
	}

	void Start () {
		playercontroller = player.GetComponent<BrunoController>();
		transform.position = new Vector2(player.transform.position.x + xOffset, transform.position.y);
	}

	void Update()
	{
		if(playercontroller.dashing)
			readjust = true;
	}
	void FixedUpdate () {
		
        // Update x-axis for dashing
        GetComponent<Rigidbody2D>().velocity = playercontroller.GetVelocity();

        //Debug.Log ( "Player vs Follower " + player.transform.position.x  + ", " + (transform.position.x + xOffset).ToString());
		if(readjust && !playercontroller.dashing)
		{
			//Debug.Log ("readjust!");
			Vector2 slowVel = new Vector2(velocityCatchUp, 0);
			GetComponent<Rigidbody2D>().velocity = slowVel; 
			if(transform.position.x >= (player.transform.position.x + xOffset))
			{
				readjust = false;
				transform.position = new Vector2(player.transform.position.x + xOffset, transform.position.y);
			}
		}
        
        // Update y-axis for jumping
        TrackPlayer();
	}

    bool CheckYMargin()
    {
        // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
        return Mathf.Abs(transform.position.y - player.transform.position.y) > yMargin;
    }

    void TrackPlayer()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetY = transform.position.y;

        // If the player has moved beyond the y margin...
        if (CheckYMargin())
            // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
            targetY = Mathf.Lerp(transform.position.y, player.transform.position.y, ySmooth * Time.deltaTime);

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);

    }
}
