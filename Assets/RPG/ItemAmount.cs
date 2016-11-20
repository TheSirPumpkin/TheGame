using UnityEngine;
using System.Collections;

public class ItemAmount : MonoBehaviour {
	public float amount = 1f;
	public bool Dead=false;
	//public GameObject obj;
	
	public void ReciveDamage (float amount){
		
		amount -= amount;

		if (amount <= 0) {
			Die ();
		}
	}
	void Die()
	{
		Destroy(gameObject);
		Dead = true;}

	
}
