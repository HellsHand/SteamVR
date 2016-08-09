using UnityEngine;

public class ScriptTest : MonoBehaviour {

	//EnemyBehavior enemy;
	GlobalVar global;

	// Use this for initialization
	void Start () {
		global = GameObject.FindObjectOfType(typeof(GlobalVar)) as GlobalVar;
	}
	
	// Update is called once per frame
	void Update () {
		//enemy = GameObject.FindObjectOfType(typeof(EnemyBehavior)) as EnemyBehavior;
		if(Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift)) {
			global.enemy.SendMessage("RecieveDamage", 10);
		}
		else if(Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) {
			global.enemy.SendMessage("RecieveDamage", 1000);
		}
		if(Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift)) {
			global.playerLevel += 1;
		}
		else if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S)) {	
			global.playerLevel += 100;
		}
	}
}
