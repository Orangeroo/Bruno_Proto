using UnityEngine;
using System.Collections;

public class MainMenuScript : TouchControls {
    void Start()
    {
        // Make sure the screen doesn't go to sleep
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
