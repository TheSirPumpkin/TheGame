using UnityEngine;
using System.Collections;

public class QuestKillBoar : MonoBehaviour {
	public bool PlayerIsHere = false;
	public bool QuestAccepted = false;
	public bool QusetCompleted = false;
	public bool PlayerMadeQuest = false;
	public bool playerALRDYtalked = false;
	public bool BoarKilledBeforeQuest = false;
	public Collider player;
	public MyCameraController CC;
	public MyCharacterController ChC;
	public QuestKillBoar Q;
	public bool BoarIsDead;
	public RPGinventory PLinv;

	
	void OnTriggerEnter(Collider other) 
	{ 
		if (player.gameObject.tag == "Player") {
			PlayerIsHere = true;
		}
		
		
	}
	
	void OnTriggerExit(Collider other) 
	{ if (player.gameObject.tag == "Player") 
		{
			PlayerIsHere = false;
			Cursor.visible = false;
			playerALRDYtalked = true;
			Q.enabled = true;
			CC.enabled = true;
			ChC.enabled = true;}
	} 
	
	
	
	
	void OnGUI () {//GUI.enabled = true;
		if (PlayerIsHere == true && QuestAccepted == false && PlayerMadeQuest == false && BoarIsDead == true) {
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 2, Screen.height / 2), "You have killed dat bastard!");
			//PLinv.gold = PLinv.gold + 100;
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 2, Screen.height / 2), "Sure, give me some gold")) 
			{
				CC.enabled = true;
				ChC.enabled = true;
				Q.enabled = false;
				PLinv.gold = PLinv.gold + 100;
				PlayerMadeQuest = true;
				//PLinv.Quest1item = false;
				BoarKilledBeforeQuest = true;
			}
		}
		if (PlayerIsHere == true && QuestAccepted == false && PlayerMadeQuest == false && BoarIsDead == false) {
			CC.enabled = false;
			ChC.enabled = false;
			Cursor.visible = true;
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 2, Screen.height / 2), "I need ya to kill a Boar!");
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 2, Screen.height / 2), "accept quest")) {
				CC.enabled = true;
				ChC.enabled = true;
				QuestAccepted = true;
				Q.enabled = false;
				//questItem.interactive = true;
				
			}
		}
		if (QuestAccepted && playerALRDYtalked == true && PlayerIsHere == true && QusetCompleted == false && PlayerMadeQuest == false) {
			Q.enabled = true;
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Go complete my quest!!!");
			CC.enabled = false;
			ChC.enabled = false;
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 2, Screen.height / 2), "okay=(")) 
			{
				CC.enabled = true;
				ChC.enabled = true;
				Q.enabled = false;
			}
		}
		if (QuestAccepted && QusetCompleted == true && PlayerIsHere == true && PlayerMadeQuest == false) {
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Wel done!!!");
			//PLinv.gold = PLinv.gold + 100;
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 2, Screen.height / 2), "okay=)")) 
			{
				CC.enabled = true;
				ChC.enabled = true;
				Q.enabled = false;
				PLinv.gold = PLinv.gold + 100;
				PlayerMadeQuest = true;
				//PLinv.Quest1item = false;
			}
		}
		if (QuestAccepted && QusetCompleted == true && PlayerIsHere == true && PlayerMadeQuest == true) 
		{
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Thank you for help");
		}
		else if (BoarKilledBeforeQuest == true && QusetCompleted == true && PlayerIsHere == true && PlayerMadeQuest == true) 
		{
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Thank you for help!!!!!!");
		}
	}
	
	/*void QuestMaking()
	{
		if(GameObject.Find("Player").GetComponent("put the script name here"))
	}*/
}
