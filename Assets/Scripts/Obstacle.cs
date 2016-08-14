using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector2(15, Random.Range(-2, 4));
		GetComponent<Rigidbody2D>().velocity = new Vector2(-3.75f, 0);
	}
	
	void FixedUpdate(){
		if(GameMaster.destroyed || GameMaster.lost)
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
	}
}
