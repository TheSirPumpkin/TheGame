using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;



public class RPGpause : MonoBehaviour 
{/*public bool lvl2;
	public bool lvl1;
	public bool lvl3;
	public bool lvl4;*/
	public Transform player;
	public Transform gold;
	public Transform sword;
	public Transform quest1item;
	public Transform Boar;
	public float x;
	public float y;
	public float z;
	public float x1;
	public float y1;
	public float z1;
	public float x2;
	public float y2;
	public float z2;
	public float x3;
	public float y3;
	public float z3;
	public float x4;
	public float y4;
	public float z4;
	//public bool GOLDpicked = false;
	//public bool SWORDpicked = false;
	//public InventoryPickup GoldPick;
	//public HealthPlayer health;
	public bool playerSave= false;
	public bool playerLoad= false;
	public InventoryPickup pickup;
	public bool stopSW = false;
	public bool stopGD = false;
	public bool stopQ1I = false;
	public bool stopBoar = false;
	public bool YouMustBeInteractive = false ;
	public RPGinventory playerInventory;
	public Quest quest1;
	public IsInteractive quest1Item ;
	public QuestKillBoar quest2;
	//public GameObject questitem ;//= (GameObject)GameObject.FindGameObjectWithTag("Quest1Objective") as GameObject ;
	//	[System.NonSerialized]
	//public string sp = " ";
	
	
	void OnGUI()
	{//quest1Item = GameObject.FindGameObjectsWithTag("Quest1Objective") ;
		//questitem = (GameObject)GameObject.FindGameObjectWithTag("Quest1Objective") as GameObject ;
		if (Input.GetKey ("escape")) {
			Time.timeScale = 0.0f;
			Cursor.visible = true;
			/*if (GUI.Button (new Rect (Screen.width / 5f, Screen.height / 2, Screen.width / 5, Screen.height / 5), "Exit to menu")) {
				Application.LoadLevel (0);
			}*/
			/*if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 5), "Restart Level")) {
				if (lvl2) {
					Application.LoadLevel (2);
				} else if (lvl1) {
					Application.LoadLevel (6);
				} else if (lvl3) {
					Application.LoadLevel (11);
				} else if (lvl4) {
					Application.LoadLevel (13);
				}
			}*/
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 5), "Quick Save")) {
				playerSave = true;//сделай по тегам как с булями
				StreamWriter sw = new StreamWriter ("PathStrewnWithSulls.v0.01_Data/SaveGame"); 
				sw.WriteLine ("Gold" + " "+ playerInventory.gold);
				sw.WriteLine ("PlayerX" + " " + player.position.x); 
				sw.WriteLine ("PlayerY" + " " + player.position.y);
				sw.WriteLine ("PlayerZ" + " " + player.position.z);
				
				if (sword != null) {
					sw.WriteLine ("SwordX" + " " + sword.position.x); 
					sw.WriteLine ("SwordY" + " " + sword.position.y);
					sw.WriteLine ("SwordZ" + " " + sword.position.z);
					stopSW = true;
				} else if (sword == null) {
					stopSW = false;
					
				}
				
				if (gold != null) {
					sw.WriteLine ("GoldX" + " " + gold.position.x); 
					sw.WriteLine ("GoldY" + " " + gold.position.y);
					sw.WriteLine ("GoldZ" + " " + gold.position.z);
					stopGD = true;
				} else if (gold == null) {
					stopGD = false;
					
				}
				if (quest1item != null) {
					sw.WriteLine ("QuestItemX" + " " + quest1item.position.x); 
					sw.WriteLine ("QuestItemY" + " " + quest1item.position.y);
					sw.WriteLine ("QuestItemZ" + " " + quest1item.position.z);
					stopQ1I = true;
					YouMustBeInteractive = true; 
				} else if (quest1item == null) {
					stopQ1I = false;
					
				}

				if (Boar != null) {
					sw.WriteLine ("BoarX" + " " + Boar.position.x); 
					sw.WriteLine ("BoarY" + " " + Boar.position.y);
					sw.WriteLine ("BoarZ" + " " + Boar.position.z);
					stopBoar = true;
					//YouMustBeInteractive = true; 
				} else if (Boar == null) {
					stopBoar = false;
					
				}
				
				//sw.WriteLine(GoldPick.GoldFound);
				//sw.WriteLine (health.health);
				//sw.Close (); 
				
				//StreamWriter sw1 = new StreamWriter ("PathStrewnWithSulls.v0.01_Data/SaveGameBool");
				//sw1.WriteLine ("тут будет bool");
				sw.WriteLine ("QuestItem" + " " + playerInventory.Quest1item);
				sw.WriteLine ("HaveSword" + " " + playerInventory.hasSword);
				//sw1.WriteLine ("GOLDfound" + " " + pickup.GoldFound);
				//sw1.WriteLine ("GOLDpicked" + " " + pickup.GOLDpicked);
			   //sw1.WriteLine ("swordFound" + " " + pickup.SwordFound);
				//sw1.WriteLine ("SWORDpicked" + " " + pickup.SWORDpicked);
				sw.WriteLine ("PlayerIsHere" + " " + quest1.PlayerIsHere);
				sw.WriteLine ("QuestAccepted" + " " + quest1.QuestAccepted);
				sw.WriteLine ("QuestCompleted" + " " + quest1.QusetCompleted);
				sw.WriteLine ("QuestIsMade" + " " + quest1.PlayerMadeQuest);
				sw.WriteLine ("DialogDone" + " " + quest1.playerALRDYtalked);
				//if (quest1item.GetComponent("InteractableScript") != null){
			    sw.WriteLine ("QuestItemActive" + " " + quest1Item.interactive);//}
				sw.WriteLine ("StopGold" + " " + stopGD);
				sw.WriteLine ("StopSword" + " " + stopSW);
				sw.WriteLine ("StopQ1I" + " " + stopQ1I);
				sw.WriteLine ("ItemFoundBeforeQ1" + " " + quest1.playerFoundBeforeQuest); 
				sw.WriteLine ("BoarKilledBeforeQ2" + " " + quest2.BoarKilledBeforeQuest); 
				sw.WriteLine ("QuestCompleted2" + " " + quest2.QusetCompleted);
				sw.WriteLine ("PlayerIsHere2" + " " + quest2.PlayerIsHere);
				sw.WriteLine ("QuestAccepted2" + " " + quest2.QuestAccepted);
				sw.WriteLine ("DialogDone2" + " " + quest2.playerALRDYtalked);
				sw.WriteLine ("QuestIsMade2" + " " + quest2.PlayerMadeQuest);
				
				
				sw.Close (); 
				
			}
			if (GUI.Button (new Rect (Screen.width / 5f, Screen.height / 3, Screen.width / 5, Screen.height / 5), "Quick Load")) {
				
				
				
				
				/*StreamReader streamReaderBool = new StreamReader ("PathStrewnWithSulls.v0.01_Data/SaveGameBool");
				if (streamReaderBool != null) {
					string[] rows = File.ReadAllLines ("PathStrewnWithSulls.v0.01_Data/SaveGameBool");
					
					bool.TryParse (GetValue (rows, "HaveSword"), out playerInventory.hasSword)
						;
					bool.TryParse (GetValue (rows, "QuestItem"), out playerInventory.Quest1item)
						;
					bool.TryParse (GetValue (rows, "GOLDfound"), out pickup.GOLDpicked)
						;
					bool.TryParse (GetValue (rows, "swordFound"), out pickup.SwordFound)
						;
					bool.TryParse (GetValue (rows, "SWORDpicked"), out pickup.SWORDpicked)
						;
					bool.TryParse (GetValue (rows, "PlayerIsHere"), out quest1.PlayerIsHere)
						;
					bool.TryParse (GetValue (rows, "QuestAccepted"), out  quest1.QuestAccepted)
						;
					bool.TryParse (GetValue (rows, "QuestCompleted"), out quest1.QusetCompleted)
						;
					bool.TryParse (GetValue (rows, "DialogDone"), out quest1.playerALRDYtalked)
						;
					bool.TryParse (GetValue (rows, "QuestItemActive"), out quest1Item.interactive)
						;
					bool.TryParse (GetValue (rows, "QuestIsMade"), out quest1.PlayerMadeQuest)
						;
					bool.TryParse (GetValue (rows, "StopGold"), out stopGD)
						;
					bool.TryParse (GetValue (rows, "StopSword"), out stopSW)
						;
					bool.TryParse (GetValue (rows, "StopQ1I"), out stopQ1I)
						;
					bool.TryParse (GetValue (rows, "ItemFoundBeforeQ1"), out quest1.playerFoundBeforeQuest)
						;

					
					
					
				}*/
				StreamReader streamReader = new StreamReader ("PathStrewnWithSulls.v0.01_Data/SaveGame");
				if (streamReader != null) {playerLoad=true;
					while (!streamReader.EndOfStream) {
						string[] rows = File.ReadAllLines ("PathStrewnWithSulls.v0.01_Data/SaveGame");
						string st = streamReader.ReadLine();
						//File.ReadAllLines ("PathStrewnWithSulls.v0.01_Data/SaveGame");
						float _x;
						float _y;
						float _z;
						float _x1;
						float _y1;
						float _z1;
						float _x2;
						float _y2;
						float _z2;
						float _x3;
						float _y3;
						float _z3;
						float _x4;
						float _y4;
						float _z4;

						if(float.TryParse (GetValue (rows, "Gold"), out playerInventory.gold)){
						}
						if(float.TryParse (GetValue (rows, "PlayerX"), out x)){
						}
						if(float.TryParse (GetValue (rows, "PlayerY"), out y)){
						}
						if(float.TryParse (GetValue (rows, "PlayerZ"), out z)){
						}
						
						if (float.TryParse (GetValue (rows, "SwordX"), out x1)){
						}
						if (float.TryParse (GetValue (rows, "SwordY"), out y1)){
						}
						if (float.TryParse (GetValue (rows, "SwordZ"), out z1)){
						}
						
						if (float.TryParse (GetValue (rows, "GoldX"), out  x2)){
						}
						if (float.TryParse (GetValue (rows, "GoldY"), out  y2)){
						}
						if (float.TryParse (GetValue (rows, "GoldZ"), out  z2)){
						}
						
						if (float.TryParse (GetValue (rows, "QuestItemX"), out x3)){
						}
						if (float.TryParse (GetValue (rows, "QuestItemY"), out y3)){
						}
						if (float.TryParse (GetValue (rows, "QuestItemZ"), out z3)){
						}

						if (float.TryParse (GetValue (rows, "BoarX"), out x4)){
						}
						if (float.TryParse (GetValue (rows, "BoarY"), out y4)){
						}
						if (float.TryParse (GetValue (rows, "BoarZ"), out z4)){
						}
						
						bool.TryParse (GetValue (rows, "HaveSword"), out playerInventory.hasSword)
							;
						bool.TryParse (GetValue (rows, "QuestItem"), out playerInventory.Quest1item)
							;
						bool.TryParse (GetValue (rows, "GOLDfound"), out pickup.GOLDpicked)
							;
						bool.TryParse (GetValue (rows, "swordFound"), out pickup.SwordFound)
							;
						bool.TryParse (GetValue (rows, "SWORDpicked"), out pickup.SWORDpicked)
							;
						bool.TryParse (GetValue (rows, "PlayerIsHere"), out quest1.PlayerIsHere)
							;
						bool.TryParse (GetValue (rows, "QuestAccepted"), out  quest1.QuestAccepted)
							;
						bool.TryParse (GetValue (rows, "QuestCompleted"), out quest1.QusetCompleted)
							;
						bool.TryParse (GetValue (rows, "DialogDone"), out quest1.playerALRDYtalked)
							;
						bool.TryParse (GetValue (rows, "QuestItemActive"), out quest1Item.interactive)
							;
						bool.TryParse (GetValue (rows, "QuestIsMade"), out quest1.PlayerMadeQuest)
							;
						bool.TryParse (GetValue (rows, "StopGold"), out stopGD)
							;
						bool.TryParse (GetValue (rows, "StopSword"), out stopSW)
							;
						bool.TryParse (GetValue (rows, "StopQ1I"), out stopQ1I)
							;
						bool.TryParse (GetValue (rows, "ItemFoundBeforeQ1"), out quest1.playerFoundBeforeQuest)
							;
						bool.TryParse (GetValue (rows, "BoarKilledBeforeQ2"), out quest2.BoarKilledBeforeQuest)
							;
						bool.TryParse (GetValue (rows, "QuestCompleted2"), out quest2.QusetCompleted)
							;
						bool.TryParse (GetValue (rows, "PlayerIsHere2"), out quest2.PlayerIsHere)
							;
						bool.TryParse (GetValue (rows, "QuestAccepted2"), out quest2.QuestAccepted)
							;
						bool.TryParse (GetValue (rows, "DialogDone2"), out quest2.playerALRDYtalked)
							;
						bool.TryParse (GetValue (rows, "QuestIsMade2"), out quest2.PlayerMadeQuest)
							;

					}
					
					//.health = System.Convert.ToSingle (streamReader.ReadLine ());
				}
				
				//if (x != 0 && y != 0 && z != 0)
				
				player.position = new Vector3 (x, y, z);
				
				if (sword != null) {
					sword.position = new Vector3 (x1, y1, z1);
				} else if (sword == null /*&& pickup.SWORDpicked == true*/ && stopSW == true) {
					GameObject instance = Instantiate (Resources.Load ("RPGsword1", typeof(GameObject))) as GameObject;
					sword = GameObject.FindWithTag ("sword").transform;
					sword.position = new Vector3 (x1, y1, z1);
					playerInventory.hasSword = false;//штука для удаления подобраных вещей если квиек сейв был до сбора
					playerInventory.SwordCount -= 1f;
				}//
				
				if (gold != null) {
					gold.position = new Vector3 (x2, y2, z2);
				} else if (gold == null /*&& pickup.GOLDpicked == true*/ && stopGD == true) {
					GameObject instance = Instantiate (Resources.Load ("Sphere", typeof(GameObject))) as GameObject;
					gold = GameObject.FindWithTag ("gold").transform;
					gold.position = new Vector3 (x2, y2, z2);
					playerInventory.gold -= 1;
				}//штука для удаления подобраных вещей если квиек сейв был до сбора}
				
				if (quest1item != null) {
					quest1item.position = new Vector3 (x3, y3, z3);
				} else if (quest1item == null /*&& pickup.Quest1ItemFound == true*/ && stopSW == true) {
					GameObject instance = Instantiate (Resources.Load ("Cube", typeof(GameObject))) as GameObject;
					quest1item = GameObject.FindWithTag ("Quest1Objective").transform;
					playerInventory.Quest1item = false;//штука для удаления подобраных вещей если квиек сейв был до сбора
					
				}//
				if (Boar != null) {
					Boar.position = new Vector3 (x4, y4, z4);
				} else if (Boar == null /*&& pickup.Quest1ItemFound == true*/ && stopBoar == true) {
					GameObject instance = Instantiate (Resources.Load ("Boar", typeof(GameObject))) as GameObject;
					Boar = GameObject.FindWithTag ("Boar").transform;
					//playerInventory.Quest1item = false;//штука для удаления подобраных вещей если квик сейв был до сбора
					
				}//


				
				
			}
			
			
			
			if (GUI.Button (new Rect (Screen.width / 1.69f, Screen.height / 2, Screen.width / 5, Screen.height / 5), "Exit Game")) {
				Application.Quit ();
			} 
		} else if (Input.GetKeyUp ("escape")) {
			Time.timeScale = 1.0f;
			Cursor.visible = false;
		}
		
		
	}
	
	
	
	
	string GetValue(string[] line, string pattern)
	{
		string result = "";
		foreach(string key in line)
		{
			if(key.Trim() != string.Empty)
			{
				string value = "";
				value = key;
				
				if(pattern == value.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)[0])
				{
					result = value.Remove(0, value.IndexOf(' ')+1);
				}
			}
		}
		return result;
	}
	
}		