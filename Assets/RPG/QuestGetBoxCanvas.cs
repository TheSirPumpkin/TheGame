using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class QuestGetBoxCanvas : MonoBehaviour {
	public Transform canvasButton;
	public Canvas canvas;
	public Quest quest;
	void Start ()
	{
		canvasButton.gameObject.SetActive (true);
	}

	public void OnClick()
	{
		canvas.gameObject.SetActive (false);
	}


}
