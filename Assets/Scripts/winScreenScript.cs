using UnityEngine;
using System.Collections;

public class winScreenScript : MonoBehaviour {
	public Transform platinum;
	public Transform gold;
	public Transform silver;
	public Transform bronze;
	public Transform newscore;
	public TextMesh score;
	public TextMesh high;
	
	// Use this for initialization
	void OnEnable () {
		if(GameMaster.currentScore > GameMaster.highScore){
			GameMaster.highScore = GameMaster.currentScore;
			newscore.gameObject.SetActive(true);
			PlayerPrefs.SetInt("best", GameMaster.highScore);
		}else{
			newscore.gameObject.SetActive(false);
		}

		score.text = ""+GameMaster.currentScore;
		high.text = ""+GameMaster.highScore;
		bronze.gameObject.SetActive(false);
		silver.gameObject.SetActive(false);
		gold.gameObject.SetActive(false);
		platinum.gameObject.SetActive(false);
		if(GameMaster.currentScore >= 15 && GameMaster.currentScore < 30){
			bronze.gameObject.SetActive(true);
			silver.gameObject.SetActive(false);
			gold.gameObject.SetActive(false);
			platinum.gameObject.SetActive(false);
		}else if(GameMaster.currentScore >= 30 && GameMaster.currentScore < 50){
			bronze.gameObject.SetActive(false);
			silver.gameObject.SetActive(true);
			gold.gameObject.SetActive(false);
			platinum.gameObject.SetActive(false);
		}else if(GameMaster.currentScore >= 50 && GameMaster.currentScore < 100){
			bronze.gameObject.SetActive(false);
			silver.gameObject.SetActive(false);
			gold.gameObject.SetActive(true);
			platinum.gameObject.SetActive(false);
		}else if(GameMaster.currentScore >= 100){
			bronze.gameObject.SetActive(false);
			silver.gameObject.SetActive(false);
			gold.gameObject.SetActive(false);
			platinum.gameObject.SetActive(true);
		}

	}
}
