using UnityEngine;
using System.Collections;

public class ExampleHUD : VRGUI 
{
	public GUISkin skin;
	
	public override void OnVRGUI()
	{
		GUI.skin = skin;
		
		GUI.Label(new Rect(0f, 0f, 600f, 100f), "Time: " + Time.time);
		
		GUI.Label(new Rect(Screen.width/2 - 400, Screen.height - 100, 800, 100), "Press Space For Menu"); 
	}
}
