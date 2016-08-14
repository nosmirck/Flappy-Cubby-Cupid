using UnityEngine;
using System.Collections;

public class FlappyCharacterController : MonoBehaviour {
	public float flapForce = 10;
	public Camera mainCam;
	private float floorHeight;
	private float ceilling;
	public AudioClip hit;
	public AudioClip flap;
	private bool onfloor = false;
	public Transform hitsprt;
	private bool gone;
	private bool first;
	// Use this for initialization
	void Start () {
		gone = false;
		first = false;
		gameObject.GetComponent<Collider2D>().enabled = true;
		floorHeight = 0.75f-(mainCam.ScreenToWorldPoint(new Vector2(0, Screen.height)).y-0.7f);
		ceilling = mainCam.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
	}
	
	// Update is called once per frame
	void Update () {
		if(!first && GameMaster.started){
			first = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, flapForce);
			GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.2f);
			GetComponent<AudioSource>().clip = flap;
			GetComponent<AudioSource>().Play();
		}
		if(!GameMaster.destroyed && GameMaster.started && !GameMaster.lost && transform.position.y < ceilling){
			if (Input.GetKeyDown ("space") || (Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Began) || Input.GetMouseButtonDown(0)){
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, flapForce);
				GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.2f);
				GetComponent<AudioSource>().clip = flap;
				GetComponent<AudioSource>().Play();
			} 
		}
		if(!GameMaster.started){
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			transform.position = new Vector2(transform.position.x, 0);
		}
		if(transform.position.y <= floorHeight && !onfloor){
			onfloor = true;
			GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
			GetComponent<AudioSource>().clip = hit;
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			GetComponent<Rigidbody2D>().gravityScale = 0.0f;
			transform.position = new Vector2(transform.position.x, floorHeight);
			GameMaster.destroyed = true;
			GameMaster.lost = true;
			GameMaster.winscreen.SetActive(true);
		}
		if(GetComponent<Rigidbody2D>().velocity.y <0.0 && !onfloor){
			float v = GetComponent<Rigidbody2D>().velocity.y/25.0f;
			if(v<-1.0f) v = 1.0f;
			transform.rotation = new Quaternion(0, 0, v, 1);
		}else if(!onfloor){
			float v = GetComponent<Rigidbody2D>().velocity.y/25.0f;
			if(v>0.3f) v = 0.3f;
			transform.rotation = new Quaternion(0, 0, v, 1);
		}
		if(GameMaster.restart){
			GameMaster.restart = false;
			RestartLevel();
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "obstacles" && !GameMaster.destroyed && !GameMaster.lost){
			GameMaster.lost = true;
			GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
			GetComponent<AudioSource>().clip = hit;
			GetComponent<AudioSource>().Play();
			Time.timeScale = 0.25f;
			StartCoroutine(UnStop());
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		Debug.Log(other.gameObject.tag);
		if(other.gameObject.tag == "obstacles" && !gone){
			Instantiate(hitsprt, other.contacts[0].point, Quaternion.identity);
			gone = true;
			gameObject.GetComponent<Collider2D>().enabled = false;
			OnTriggerEnter2D(other.collider);
		}
	}
	IEnumerator UnStop(){
		yield return new WaitForSeconds(0.1f);
		Time.timeScale = 1.0f;
	}
	void RestartLevel(){
		Time.timeScale = 1.0f;
		fadeInOut.setSeconds(0.66f);
		fadeInOut.fout = true;
		StartCoroutine(LoadFadeLevel());
	}
	IEnumerator LoadFadeLevel(){
		yield return new WaitForSeconds(0.66f);
		Application.LoadLevel(Application.loadedLevel);
	}
}
