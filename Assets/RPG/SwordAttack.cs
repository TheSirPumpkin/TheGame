using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {
	//public Collider player;
	public float damage = 20f;
	public GameObject target;
		void Update()
	{

	}
	void OnTriggerEnter (Collider collision)
	{if (gameObject.tag != "Player") {
			target = collision.gameObject;
			RPGHealth h = target.GetComponent<RPGHealth> ();
			if(h != null) {

								h.ReciveDamage (damage);
			}else if (h == null){Debug.Log("ударил обьект без хп");}
				}
	}
	void OnTriggerExit (Collider other)
	{
	}
}



