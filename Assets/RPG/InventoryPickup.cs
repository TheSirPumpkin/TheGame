using UnityEngine;
using System.Collections;

public class InventoryPickup : MonoBehaviour {



	public RPGinventory gold;
	public RPGinventory sword;
	public RPGinventory QI1;
	public float range= 100.0f;
	float pickup = 1;
	public IsInteractive isInteractive ;
	//ItemAmount interactive ;
	//public GameObject obj;
	public RPGinventory playerInventory; 
	//public RPGpause noItem;
	public RPGpause picked;
	public Quest Q;

	public bool GOLDpicked = false;
	public bool SWORDpicked = false;
	public bool GoldFound = false;
	public bool SwordFound = false;
	public bool Quest1ItemFound = false;
	// quest1item ;


	void Update () {//interactive = gameObject.GetComponent<IsInteractive>();
		//quest1item = GameObject.FindWithTag("Quest1Objective");
				if (Input.GetKeyDown("e") ) {
						Ray ray = new Ray (transform.position, transform.forward);
						RaycastHit hitInfo;
		
						if (Physics.Raycast (ray, out hitInfo, range)) {
								Vector3 hitPoint = hitInfo.point;
								GameObject go = hitInfo.collider.gameObject;
								Debug.Log ("Hit Object" + go.name);
								Debug.Log ("Hit Point" + hitPoint);
				if(go.GetComponent<IsInteractive>()!=null){
				IsInteractive II = go.GetComponent<IsInteractive>();
				RPGinventory g = go.GetComponent<RPGinventory> ();
				ItemAmount IA = go.GetComponent<ItemAmount> ();

				if (II.interactive == true)
				{
				if (go.GetComponent<Collider>().gameObject.tag == "gold") 
					
				{
						GOLDpicked = true;
					//noItem.noGOLD = true;
					GoldFound = true;
					IA.ReciveDamage (pickup);
					gold.gold+=1;
				}
				if (go.GetComponent<Collider>().gameObject.tag == "sword") 

				{
					SWORDpicked = true;
					//noItem.noSWORD = true;
					SwordFound = true;
					IA.ReciveDamage (pickup);
					sword.SwordCount+=1;
						sword.hasSword = true;}
				
				
					if (go.GetComponent<Collider>().gameObject.tag == "Quest1Objective") 
						
					{

						Quest1ItemFound = true;
						QI1.Quest1item = true;
						IA.ReciveDamage (pickup);
						Q.QusetCompleted = true;
					}
					}
					
				}
				/*else if(go.GetComponent<IsInteractive>()==null || isInteractive.interactive == false)
				{
					Debug.Log ("Is not interactive");
				}*/
				}
			}
								
			    }	
		
				}




