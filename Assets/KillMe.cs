using UnityEngine;
using System.Collections;

public class KillMe : MonoBehaviour {
	public RPGpause killme;
	public Quest quest1;
	// Use this for initialization
	void Update () {
		if (killme.stopQ1I == true && quest1.QusetCompleted) {
			Destroy(gameObject);}
	}

}
