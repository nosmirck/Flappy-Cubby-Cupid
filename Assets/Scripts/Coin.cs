using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	private bool counted = false;
	public ParticleSystem emitter;
	void OnTriggerEnter2D(Collider2D other){
		if(!counted){
			emitter.Play();
			GetComponent<AudioSource>().Play();
			GameMaster.currentScore++;
			counted = true;
		}
	}
}
