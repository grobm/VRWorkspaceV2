using UnityEngine;
using System.Collections;

public class ExampleMenu : VRGUI 
{
	public GUISkin skin;
	public bool workspacepanel = false;
	private int clickCount = 0;
	public Vector2 Position;
	public string workspaceURL = "http://google.com";


	//	// Whether the GUI accepts mouse/keyboard input
	//	public bool HasFocus = true;
	public bool IsVisible = true;
		
	private Transform target;
		
	void Start()
	{
		target = this.transform;
	}

	void Update()
	{

		//if (workspacepanel == true) {
			Vector3 viewPos = Camera.main.WorldToViewportPoint (target.position);
			if ((0f <= viewPos.x && viewPos.x <= 1F) && (0f <= viewPos.y && viewPos.y <= 1F) && (Camera.main.transform.position.z < this.transform.position.z)) {
				print ("target is in the camera! ----- ");
				IsVisible = true;
			} else if ((0f > viewPos.x)) {
				print ("target is on the left side!");
				IsVisible = true;
			} else if ((viewPos.x > 1F)) {
				print ("target is on the right side!");
				IsVisible = true;
			} else {
				print ("target is NOT in the camera!");
				IsVisible = false;
			}
		//}
	}

	// Whether the GUI accepts mouse/keyboard input
	public bool HasFocus = true;
	
	public override void OnVRGUI()
	{
		GUI.skin = skin;
		UWKWebView view = gameObject.GetComponent<UWKWebView> ();

		if (workspacepanel == false) {
			GUILayout.BeginArea (new Rect (0f, 0f, Screen.width, Screen.height));
			GUILayout.BeginVertical ();
			if (GUILayout.Button("X"))
			{
				Destroy (gameObject);
			}
			GUILayout.FlexibleSpace ();
			
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
					if (GUILayout.Button("Click Me!"))
					{
					view.LoadURL(workspaceURL);
					workspacepanel = true;
					}
			workspaceURL = GUILayout.TextField(workspaceURL);

			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			
			GUILayout.BeginHorizontal ();
			//		GUILayout.FlexibleSpace();
			//		GUILayout.Label("Clicks: " + clickCount);
			//		GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal ();
			
			GUILayout.FlexibleSpace ();
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}

		if (workspacepanel == true) {
			GUILayout.BeginArea (new Rect (0f, 0f, Screen.width, Screen.height));
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button("Click Me!"))
			{
				view.LoadURL(workspaceURL);
				workspacepanel = true;
			}
			workspaceURL = GUILayout.TextField(workspaceURL);

			if (GUILayout.Button("X"))
			{
				Destroy (gameObject);
			}
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();

			// get the attached view component
			view.URL = workspaceURL;
			// if we have a view attached and it is visible
			if (view != null && view.Visible ()) {
			
				// draw it
				Rect r = new Rect (Position.x, Position.y, view.CurrentWidth, view.CurrentHeight);
				view.DrawTexture (r);
			
				// if we have focus, handle input
				if (HasFocus) {
					// get the mouse coordinate
					Vector3 mousePos = Input.mousePosition;
					mousePos.y = Screen.height - mousePos.y; 
				
					// translate based on position
					mousePos.x -= Position.x;
					mousePos.y -= Position.y;    
				
					view.ProcessMouse (mousePos);            
				
					// process keyboard     
					if (Event.current.isKey)
						view.ProcessKeyboard (Event.current);
				}
			}       

			GUILayout.BeginVertical ();
			GUILayout.FlexibleSpace ();
		
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
//		if (GUILayout.Button("Click Me!"))
//		{
//			clickCount++;
//		}
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
		
			GUILayout.BeginHorizontal ();
//		GUILayout.FlexibleSpace();
//		GUILayout.Label("Clicks: " + clickCount);
//		GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal ();
		
			GUILayout.FlexibleSpace ();
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}
	}
}

//using UnityEngine;
//using System.Collections;
//
//public class CameraGUI : VRGUI
//{
//	
//	public GUISkin skin;
//	
//	private int clickCount = 0;
//	public Vector2 Position;
//	
//	// Whether the GUI accepts mouse/keyboard input
//	public bool HasFocus = true;
//	public bool IsVisible = true;
//	
//	private Transform target;
//	
//	void Start()
//	{
//		target = this.transform;
//	}
//	
//	void Update()
//	{
//		Vector3 viewPos = Camera.main.WorldToViewportPoint(target.position);
//		if ((0f <= viewPos.x && viewPos.x <= 1F) && (0f <= viewPos.y && viewPos.y <= 1F) && (Camera.main.transform.position.z < this.transform.position.z))
//		{
//			print("target is in the camera! ----- ");
//			IsVisible = true;
//		}
//		else if ((0f > viewPos.x))
//		{
//			print("target is on the left side!");
//			IsVisible = true;
//		}
//		else if ((viewPos.x > 1F))
//		{
//			print("target is on the right side!");
//			IsVisible = true;
//		}
//		else
//		{
//			print("target is NOT in the camera!");
//			IsVisible = false;
//		}
//	}
//	
//	public override void OnVRGUI()
//	{
//		GUI.skin = skin;
//		
//		GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
//		
//		// get the attached view component
//		UWKWebView view = gameObject.GetComponent<UWKWebView>();
//		
//		// if we have a view attached and it is visible
//		if (view != null && view.Visible() && IsVisible)
//		{
//			
//			// draw it
//			Rect r = new Rect(Position.x, Position.y, view.CurrentWidth, view.CurrentHeight);
//			view.DrawTexture(r);
//			
//			// if we have focus, handle input
//			if (HasFocus)
//			{
//				// get the mouse coordinate
//				Vector3 mousePos = Input.mousePosition;
//				mousePos.y = Screen.height - mousePos.y;
//				
//				// translate based on position
//				mousePos.x -= Position.x;
//				mousePos.y -= Position.y;
//				
//				view.ProcessMouse(mousePos);
//				
//				// process keyboard     
//				if (Event.current.isKey)
//					view.ProcessKeyboard(Event.current);
//			}
//		}
//		
//		GUILayout.BeginVertical();
//		GUILayout.FlexibleSpace();
//		
//		GUILayout.BeginHorizontal();
//		GUILayout.FlexibleSpace();
//		// if (GUILayout.Button("Click Me!"))
//		// {
//		// clickCount++;
//		// }
//		GUILayout.FlexibleSpace();
//		GUILayout.EndHorizontal();
//		
//		GUILayout.BeginHorizontal();
//		GUILayout.FlexibleSpace();
//		GUILayout.Label("Clicks: " + clickCount);
//		GUILayout.FlexibleSpace();
//		GUILayout.EndHorizontal();
//		
//		GUILayout.FlexibleSpace();
//		GUILayout.EndVertical();
//		GUILayout.EndArea();
//	}
//}
