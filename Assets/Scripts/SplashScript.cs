using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {

	// Use this for initialization
	void Awake()
	{
		StartCoroutine(MyLoadLevel(5.0f));
		StartCoroutine(fade (3.0f));
	}
	
	IEnumerator MyLoadLevel(float delay)
	{
		yield return new WaitForSeconds(delay);
		Application.LoadLevel(1);
	}
	IEnumerator fade(float delay)
	{
		yield return new WaitForSeconds(delay);
		fadeInOut.fout = true;
	}
	

}
