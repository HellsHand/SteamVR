using UnityEngine;

public class MouseFollower : MonoBehaviour {
	
	GlobalVar global;
	private bool hovering;
	
	// Use this for initialization
	void Start () {
		global = GameObject.FindObjectOfType(typeof(GlobalVar)) as GlobalVar;
		hovering = false;
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 25));
		transform.position = mouseLoc;
	}
	
	void OnTriggerEnter(Collider collided) {
		hovering = true;
		if(collided.tag == "Enemy") {
			collided.SendMessage("RecieveDamage", 10);
		}	
	}
	
	void OnTriggerExit(Collider collided) {
		hovering = false;
	}
}
