using UnityEngine;
using System.Collections;

public class GUITextResize : MonoBehaviour
{
	void Start()
	{
		GetComponent<GUIText>().fontSize = 0;
		
		if( DisplayMetricsAndroid.HeightPixels > 0 )
		{
			GetComponent<GUIText>().fontSize = DisplayMetricsAndroid.HeightPixels/15;
		}
	}
}

