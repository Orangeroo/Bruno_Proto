using UnityEngine;
using System.Collections;

public class ReturnButton : MonoBehaviour {
    public GUIText loinLabel;
    public GUIText loinNr;

    void OnTouch()
    {
        Camera.main.transform.position = new Vector3(0, 0, Camera.main.transform.position.z);
        loinLabel.enabled = false;
        loinNr.enabled = false;
    }
}
