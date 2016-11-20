using UnityEngine;
using System.Collections;

public class QuestzapasVAR: MonoBehaviour {
	public string[ ] answer ;
	public string[ ] question ;
	public bool showdialog = true;
	public bool activatequest = false;


	void OnGUI () {
		GUI.enabled = true;
		//GUI.Button (new Rect (10,10,150,100), "I am a button");

		GUILayout.BeginArea(new Rect (700,600,400,400));
		if(showdialog && !activatequest)
		{
			GUILayout.Label(question[0 ]);
			GUILayout.Label(question[1 ]);
		
			if (GUILayout.Button(answer[0 ]))
		{
			activatequest = true;
				showdialog = true;
		}
		if (GUILayout.Button(answer[1 ]))
		{
				showdialog = true;
		}
		}
		if(showdialog && activatequest)
		{
			GUILayout.Label(question[2 ]);
			if (GUILayout.Button(answer[2 ]))
			{

				showdialog = true;
			}

		}
		GUILayout.EndArea ();

		
	}


	void OnTriggerEnter () {
		showdialog = true;
		
	}
	void OnTriggerExit () {
		showdialog = false;
	}
}
