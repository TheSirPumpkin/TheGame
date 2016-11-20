using UnityEngine;
using System.Collections;

public class GoldPickup : MonoBehaviour {
	public RPGinventory gold;


	void OnTriggerEnter(Collider other) {
		gold.gold+=1;
		Destroy(gameObject);
	}
}