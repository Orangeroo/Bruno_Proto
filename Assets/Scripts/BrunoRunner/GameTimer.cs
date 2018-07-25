using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {
    public static GameTimer Instance;

    float timeRemaining;
    public float totalTimeOfLevel = 60f;
    bool isCounting = false;

    // Register the singleton
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of timer");
        }

        Instance = this;
    }

    // Reset the timer
    void Start()
    {
        this.ResetTimer();
    }  

    // Public methods
    public void ResetTimer()
    {
        timeRemaining = totalTimeOfLevel;
    }

    public void StartTimer()
    {
        isCounting = true;
    }

    public void PauseTimer()
    {
        isCounting = false;
    }
	
	void FixedUpdate ()
    {
        if (isCounting)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining == 0f)
            {
                OnEndTimer();
            }
        }

        GetComponent<GUIText>().text = ((int)timeRemaining).ToString();
	}

    // At the end of each running round
    void OnEndTimer()
    {         
        // Save game
        PlayerStats.instance.Save();

        // Stop spawning level
        LevelBlockSpawner.Instance.isSpawnLevel = false;
    }
}
