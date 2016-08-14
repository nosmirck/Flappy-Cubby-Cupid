using UnityEngine;
using System.Collections;

public class fbbutton : MonoBehaviour {

	// Use this for initialization
	void OnMouseEnter(){
		transform.localScale = new Vector2(1.2f, 1.2f);
	}
	void OnMouseExit(){
		transform.localScale = new Vector2(1, 1);
	}
	void OnMouseDown(){
		/*if(!GameMaster.hitplay){
			GameObject.Find("FacebookPlugin").GetComponent<FBManager>().CallFBFeed();	
		}
		if(GameMaster.destroyed){
			GameObject.Find("FacebookPlugin").GetComponent<FBManager>().CallFBFeedShareScore();
		}*/
	}
}
