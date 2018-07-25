using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public bool isPaused = false;
	// public GameObject cameraFollower;
	public GameObject pauseButton;
	public float zaxis = -5f;
	Vector2 positionOriginal;

	void Start()
	{
		positionOriginal = this.transform.position;
	}

	// FOR TESTING

	void Update()
	{
		bool rah = Input.GetButtonDown("Pause");
		if(rah) TogglePause();
	}

	public bool TogglePause()
	{
		if(isPaused)
			Unpause ();
		else
			Pause();

		return isPaused;
	}
	
	public void Unpause()
	{
		// Move pause screen back to 'bank' position
		//this.transform.position = positionOriginal;
        MovePauseScreen(true);

		// Unhide pause button
		pauseButton.GetComponent<Renderer>().enabled = true;

		// Resume the game
		Time.timeScale = 1;

        // Resume the game timer
        GameTimer.Instance.StartTimer();

		// Reset isPaused boolean
		isPaused = false;
	}


	public void Pause()
	{
		// Move pause screen into view
        MovePauseScreen(false);

		// Hide pause button
		pauseButton.GetComponent<Renderer>().enabled = false;

		// Pause game
		Time.timeScale = 0;

        // Pause the game timer
        GameTimer.Instance.PauseTimer();

		// Set isPaused boolean
		isPaused = true;
	}

    public void MovePauseScreen(bool isBackToBank)
    {
        if (isBackToBank)
        {
            this.transform.position = positionOriginal;
        }
        else
        {
            Vector3 cameraPosition = PlayerCameraFollower.Instance.transform.position;
            this.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, zaxis);
        }
    }
}
