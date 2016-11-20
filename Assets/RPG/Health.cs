using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public AudioSource deathAudio;
	public AudioSource ScaryAudio;
	public float HitPoints = 100f;
	public bool Boss;
	public bool FullHealth;
	public bool Network; 
	//public bool SaveTest;
	public bool Dead=false;

	public void ReciveDamage (float amount){
						
		if (HitPoints == 100f) {FullHealth=true;}
		if (HitPoints < 100f) {FullHealth=false;}

			HitPoints -= amount;

		if (HitPoints > 0) {
			ScaryAudio.Play ();
		}
				if (HitPoints <= 0) {
			deathAudio.Play ();
						Die ();
				}
		}
		 void Die()
	{if (Boss) {Application.LoadLevel (3);}
		if (Network) {PhotonNetwork.Destroy (gameObject);};
		Destroy(gameObject);
		Dead = true;}
	
}
