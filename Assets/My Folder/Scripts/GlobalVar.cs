using UnityEngine;

public class GlobalVar : MonoBehaviour {

	public int playerLevel;
	public EnemyBehavior enemy;
	public BloodDrinker sword;

	// Use this for initialization
	void Start () {
		playerLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
		enemy = GameObject.FindObjectOfType(typeof(EnemyBehavior)) as EnemyBehavior;
		sword = GameObject.FindObjectOfType(typeof(BloodDrinker)) as BloodDrinker;
	
	}
}
