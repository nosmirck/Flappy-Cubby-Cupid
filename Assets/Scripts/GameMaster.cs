using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static int currentScore = 0;
	public static int highScore = 0;
	public float offsetY = 100;
	public float sizeX = 200;
	public float sizeY = 100;
	public GameObject getready;
	public GameObject win;
	public GameObject mainwin;
	public TextMesh scoretext;
	public static GameObject winscreen;

	[HideInInspector]
	public static int lastType = -1;
	public static int multiplier = 1;
	public static bool destroyed;
	public static bool restart;
	public static bool started = false;
	public static bool hitplay = false;
	public static bool lost = false;
	private static float t=0;
	void Start(){
		winscreen = win;
		winscreen.SetActive(false);
		currentScore = 0;
		destroyed = false;
		started = false;
		restart = false;
		lost = false;
		getready.SetActive(false);
		mainwin.SetActive(true);
		scoretext.gameObject.SetActive(false);
		highScore = PlayerPrefs.GetInt("best", 0);
		//hitplay = false;
	}

	void Update(){
		t+=Time.deltaTime;
		if ((hitplay && t>0.1f) && !started && (Input.GetKeyDown ("space") || (Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Began) || Input.GetMouseButtonDown(0))){
			started = true;
		}
		if(hitplay && !started)
			getready.SetActive(true);
		else
			getready.SetActive(false);
		if(hitplay){
			mainwin.SetActive(false);
			scoretext.gameObject.SetActive(true);
		}
		scoretext.text = ""+currentScore;
	}
	public static void startGame(){
		t=0;
		hitplay = true;
	}
}
