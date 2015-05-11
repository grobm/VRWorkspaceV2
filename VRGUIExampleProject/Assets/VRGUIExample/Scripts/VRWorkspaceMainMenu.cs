using UnityEngine;
using System.Collections;

public class VRWorkspaceMainMenu : VRGUI {

	public GUISkin skin;
	public bool enabled;
	public GameObject Workspace;
	public int menumode;
	public int sky;

	public override void OnVRGUI()
	{
		if (enabled == true) {
			GUI.skin = skin;
			if (menumode== 0){
				if (GUI.Button (new Rect (Screen.width / 2 - 100, 300, 320, 64), "Create VRworkspace")) {
					print ("We have instance of VR Workspace");
					Instantiate(Workspace, transform.position, transform.rotation);
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 100, 400, 320, 64), "Settings")) {
					menumode = 1;
				}
			}
			if (menumode== 1){
				if (GUI.Button (new Rect (Screen.width / 2 - 100, 300, 320, 64), "Select World")) {
					sky = sky++;

				}
				if (GUI.Button (new Rect (Screen.width / 2 - 100, 400, 320, 64), "Workspace Mode")) {
					menumode = 0;
				}
			}
		}
	}

	void FixedUpdate()
	{
//		if (Input.GetKeyDown(KeyCode.Q))
//			YRotation -= RotationRatchet;
//
		if (Input.GetKey ("`")){
		    if (enabled == true){
		    	enabled = false;
				return;
			}
			if (enabled == false){
		    	enabled = true;
				return;
			}
		}
	}
}