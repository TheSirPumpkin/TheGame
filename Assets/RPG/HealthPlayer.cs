using UnityEngine;
using System.Collections;

public class HealthPlayer : MonoBehaviour {
	public float health;
	public GUIText HealthBar;
	public bool lvl1;
	public bool lvl2;
	public bool lvl3;
	public bool lvl4;
	// Use this for initialization
	void Start () {  
	}
	
	// Update is called once per frame
	void Update () {HealthBar.text = "Health"+":" + health;
		EnemyAI.PlayerIsAlive = true;
		if (health<=0)
		{
			if(lvl2){Application.LoadLevel (7);}
			else if(lvl1){Application.LoadLevel (4);}
			else if(lvl3){Application.LoadLevel (12);}
			else if(lvl4){Application.LoadLevel (14);}
			Destroy(gameObject);
			EnemyAI.PlayerIsAlive = false;
		}
	}
}
