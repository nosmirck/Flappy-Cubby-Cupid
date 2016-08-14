using UnityEngine;
using System.Collections;

public class Casitas : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0);
	}
	
	void FixedUpdate(){
		if(GameMaster.destroyed || GameMaster.lost)
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
	}
}
