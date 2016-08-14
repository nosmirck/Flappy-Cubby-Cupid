using UnityEngine;
using System.Collections;

public class fadeInOut : MonoBehaviour {
	public static bool fout = false;
	private float alpha;
	private static float sec = 2.0f;
	// Use this for initialization
	void Start () {
		fout = false;
		sec = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(fout){
			alpha = gameObject.GetComponent<Renderer>().material.color.a + Time.deltaTime/sec;
		}else{
			alpha = gameObject.GetComponent<Renderer>().material.color.a - Time.deltaTime/sec;
		}
		if(alpha<0) alpha = 0;
		if(alpha>1) alpha = 1;

		gameObject.GetComponent<Renderer>().material.color = new Color(0,0,0, alpha);
	}
	public static void setSeconds(float s){
		sec = s;
	}
}
