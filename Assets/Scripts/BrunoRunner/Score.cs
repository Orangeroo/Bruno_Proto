using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Singleton
	public static Score Instance;

	public int score = 0;
	GameObject diamond_counter;


	void Awake()
	{
		// Register the singleton
		if( Instance != null )
		{
			Debug.LogError("Multiple instances of Score");
		}
		
		Instance = this;
	}

	void Start()
	{
		GetComponent<GUIText>().fontSize = 0;

		if( DisplayMetricsAndroid.HeightPixels > 0 )
		{
			GetComponent<GUIText>().fontSize = DisplayMetricsAndroid.HeightPixels/15;
		}

		//diamond_counter = GameObject.Find("diamond_counter");

		//gameObject.transform.position = diamond_counter.transform.position;
	}

	void Update () {
		GetComponent<GUIText>().text = score.ToString();	
	}

	public void AddScore()
	{
		score++;
	}

	public void ReduceScoreByHalf()
	{
		score = (score / 2);
	}
}
