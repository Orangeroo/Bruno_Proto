using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	void OnTouch()
	{        
		SceneManager.LoadScene("Bruno");
	}
}
