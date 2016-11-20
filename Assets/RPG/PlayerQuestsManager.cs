using UnityEngine;
using System.Collections;

public class PlayerQuestsManager : MonoBehaviour {
	public RPGinventory playerINV;
	public Quest Q;

	void Update()
	{
		if (playerINV.Quest1item == true) 
		{
			Q.QusetCompleted = true;
				}

	}
		
		
	}

