using UnityEngine;
using System.Collections;

public class ExamplePlayerController : MonoBehaviour {
	
	public float moveAccelleration = 4f;
	public float moveDrag = 2f;
	public float mouseSensitivity = 2f;
	
	private float   rotationY = 0f;
	private Vector3 velocity  = Vector3.zero;
	private CharacterController controller;
	public ExampleMenu menu;
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
		menu = GetComponent<ExampleMenu>();
		
		// hide the cursor
		Cursor.visible = false;
	}
	
	void FixedUpdate()
	{
		// toggle the menu on/off
		if (Input.GetKeyDown(KeyCode.Space))
		{
			menu.enabled = !menu.enabled;
		}
		
		// disable movement when menu is open
		if (!menu.enabled)
		{
			// very simplified movement
			rotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
			transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
			
			Vector3 moveKeys = new Vector3(
				(Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0),
				0,
				(Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0));
			
			velocity += transform.rotation * moveKeys * moveAccelleration * Time.deltaTime;
			velocity += -velocity.normalized * moveDrag * Time.deltaTime;
			
			controller.Move(velocity * Time.deltaTime);
		}
	}
}
