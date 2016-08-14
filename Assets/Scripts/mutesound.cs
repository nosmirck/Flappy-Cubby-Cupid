using UnityEngine;
using System.Collections;

public class mutesound : MonoBehaviour {
	public GameObject isOn;
	public GameObject isOff;
	private static bool muted = false;
	// Use this for initialization
	void Start () {
		try{
			isOn.SetActive(true);
			isOff.SetActive(false);
		}catch(UnassignedReferenceException e){
		}
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		AudioListener.volume = 1 - AudioListener.volume;
		muted = !muted;
		if(muted){
			isOn.SetActive(false);
			isOff.SetActive(true);
		}else{
			isOn.SetActive(true);
			isOff.SetActive(false);
		}
	}
}
