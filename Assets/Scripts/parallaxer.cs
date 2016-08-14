using UnityEngine;
using System.Collections;

public class parallaxer : MonoBehaviour {

	public float speed = 1.0f;
	
	// Update is called once per frame
	void Update () {
		if(!GameMaster.lost && GameMaster.started)
			gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(gameObject.GetComponent<Renderer>().material.mainTextureOffset.x+Time.deltaTime*speed, 0);
	}
}
