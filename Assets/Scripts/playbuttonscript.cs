using UnityEngine;
using System.Collections;

public class playbuttonscript : MonoBehaviour {
	private float sec = 0;
	void OnMouseEnter(){
		transform.localScale = new Vector2(1.2f, 1.2f);
	}
	void OnMouseExit(){
		transform.localScale = new Vector2(1, 1);
	}
	void Update(){
		sec+=Time.deltaTime;
		if(GameMaster.destroyed){
			if(Input.GetKeyDown ("space") && sec >0.5f)
				GameMaster.restart = true;
		}
	}
	void OnMouseDown(){
		if(!GameMaster.hitplay){
			GameMaster.startGame();
		}
		if(GameMaster.destroyed){
			GameMaster.restart = true;
		}
	}
}
