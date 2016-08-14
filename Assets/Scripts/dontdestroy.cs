using UnityEngine;
using System.Collections;

public class dontdestroy : MonoBehaviour {

	private static dontdestroy instance = null;
	public static dontdestroy Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
