using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BrunoControls : MonoBehaviour {

	// Bruno 
	public GameObject bruno;
	BrunoController brunoController;

	// Level spawner
	public GameObject levelSpawner;
	LevelBlockSpawner spawner;

	// Pause button
	public GameObject pauseButton;
	public GameObject pauseScreen;
	PauseScript pauseScript;

	// Resume button
	public GameObject resumeButton;

    // Restart button
    public GameObject restartButton;

    // Main menu button
    public GameObject mainMenuButton;

	// Press to start text
	public GameObject pressToStartText;

	float middlePoint;
	bool waitingToStart;

	void Awake()
    {
		middlePoint = DisplayMetricsAndroid.WidthPixels/2;
		brunoController = bruno.GetComponent<BrunoController>();
		spawner = levelSpawner.GetComponent<LevelBlockSpawner>();
		waitingToStart = !spawner.isSpawnLevel;
		pauseScript = pauseScreen.GetComponent<PauseScript>();
        Debug.Log("Bruno controls on awake");
	}

	void Update ()
    {
		// PC Controls
		bool inputJump = Input.GetButtonDown("Jump");
		bool inputDash = Input.GetButtonDown("Dash");

		// Touch controls
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			
			if( touch.phase == TouchPhase.Began )
			{
                Debug.Log("Touch phase began");
				if(!checkTouch(Input.GetTouch(0).position) && !pauseScript.isPaused)
				{
                    Debug.Log("Start touched");
					inputJump = touch.position.x < middlePoint;			
					inputDash = !inputJump;
				}
				else
				{
					inputDash = false;
					inputJump = false;
				}
			}
		}

		// TODOJOANNA - there should be a better way to start the level instead of having to check each time?
		if(waitingToStart && (inputJump || inputDash))
		{
            Debug.Log("Touch to start");
			spawner.isSpawnLevel = true;
			waitingToStart = false;
			Destroy(pressToStartText);

            // Reset and start timer
            GameTimer.Instance.ResetTimer();
            GameTimer.Instance.StartTimer();
		}
		// Bruno jump
		else if(inputJump)
			brunoController.Jump();
		else if(inputDash)
			brunoController.Dash();
	}

	// Deal with GUI components
	bool checkTouch( Vector3 pos)
    {
		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos);

		if(hit != null && hit.transform.gameObject.tag == "GUI")
		{
			// Pause
			if(hit.transform.gameObject == pauseButton)
			{
				pauseScript.TogglePause();
			}				
			// Resume from pause menu
			else if(hit.transform.gameObject == resumeButton)
			{
				pauseScript.Unpause();
			}
            else if (hit.transform.gameObject == restartButton)
            {
                // Unpause game
                pauseScript.Unpause();

                // Reload level
                SceneManager.LoadScene("Bruno");
            }
            else if (hit.transform.gameObject == mainMenuButton)
            {
                SceneManager.LoadScene("MainMenu");
            }
			return true;
		}

		return false;
	}


}




