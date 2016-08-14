using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {
	public Camera mainCam;
	// Use this for initialization
	void Start () {
		transform.position = new Vector2(0, -(mainCam.ScreenToWorldPoint(new Vector2(0, Screen.height)).y)+0.7f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
