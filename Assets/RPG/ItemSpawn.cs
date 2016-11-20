using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour {
	public RPGinventory sword;
	public Transform RPGsword1 ;
	public Transform Character ;

	void Update () 
	{if (Input.GetKeyDown ("r")) {
						SpawnItem ();
				}
	}

	void SpawnItem () 
	{  
		if (sword.hasSword) {
						Transform mySword = (Transform)Instantiate (RPGsword1, transform.position, transform.rotation);
						mySword.transform.parent = Character.transform; 
				}
		
	}
}
