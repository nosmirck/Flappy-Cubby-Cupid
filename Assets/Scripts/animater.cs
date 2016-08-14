using UnityEngine;
using System.Collections;

public class animater : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool("inIntro", true);
		anim.SetBool("dead", false);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameMaster.started){
			anim.SetBool("inIntro", false);
		}
		if(GameMaster.lost)
			anim.SetBool("dead", true);
	}
}
