using UnityEngine;
using System.Collections;

public class IsInteractive : MonoBehaviour
{public bool interactive ;
	public Quest quest;
	public bool QuestObj;
	//public RPGpause rpgp; 

	void Update(){
				if (gameObject.GetComponent<IsInteractive> ()) {
						if (QuestObj) {
				/*if (rpgp.YouMustBeInteractive == true) {
					interactive = true;}*/
								if (quest.QuestAccepted == true) {
										interactive = true;
								}
								//public GameObject obj;
						}
				}
		}
}
