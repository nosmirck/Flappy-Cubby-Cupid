using UnityEngine;
using System.Collections;

public class Producer : MonoBehaviour {

	public GameObject [] obstacle;
	private bool invoked = false;
	public float min = 1.5f;
	public float max = 1.5f;
	// Use this for initialization
	void Start () {
		//Invoke("Spawn", 3.0f);
	}
	void Update(){
		if(!GameMaster.destroyed && GameMaster.started && !invoked){
			invoked = true;
			Invoke("Spawn", 0.5f);
	
		}
	}
	// Update is called once per frame
	void Spawn () {
		if(!GameMaster.destroyed){
			int r = Random.Range(0, obstacle.Length);
			Instantiate(obstacle[r], transform.position, Quaternion.identity);
			Invoke("Spawn", Random.Range(min, max));
		}
	}
}
