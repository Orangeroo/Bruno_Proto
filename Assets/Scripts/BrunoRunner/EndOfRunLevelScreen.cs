using UnityEngine;
using System.Collections;

public class EndOfRunLevelScreen : MonoBehaviour {

    public static EndOfRunLevelScreen instance;     // singleton    
    public GameObject endscreen;
    public GUIText scorekeeper;
    public GUIText timer;
    public GUIText loinLabel;
    public GUIText loinNr;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void ShowEndScreen()
    { 
        // Move end screen
        Vector3 cameraPos = Camera.main.transform.position;
        endscreen.transform.position = new Vector3(cameraPos.x, cameraPos.y, endscreen.transform.position.z);

        // Disable score and timer text
        timer.enabled = false;
        scorekeeper.enabled = false;
        loinLabel.enabled = true;
        loinNr.enabled = true;
    }
}
