using UnityEngine;
using System.Collections;

public class ViewStatsButton : MonoBehaviour
{
    public GUIText loinlabel;
    public GUIText loinNr;
    public GameObject statsScreen;

    void OnTouch()
    {
        ViewStats();
    }
    
    // Move camera to stats screen and enable GUIText
    void ViewStats()
    {
        Vector2 screenpos = statsScreen.transform.position;
        Vector3 camerapos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(screenpos.x, screenpos.y, camerapos.z);

        // Show loins collected        
        loinNr.text = PlayerStats.instance.data.loinsCollected.ToString();
        loinlabel.enabled = true;
        loinNr.enabled = true;        
    }
    
}
