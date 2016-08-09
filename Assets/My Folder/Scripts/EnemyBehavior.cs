using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	GlobalVar global;
	public int hitPoints;
    public int expUp;
	int damageVar;
    GameObject sword;
	
	// Use this for initialization
	void Start () {
		global = GameObject.FindObjectOfType(typeof(GlobalVar)) as GlobalVar;
		damageVar = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(hitPoints <= 0 && damageVar <= 50) {
			/*global.*/sword.SendMessage("ExpUp", expUp * 10 * global.playerLevel);
			Destroy(gameObject);
		}
		else if(hitPoints <= 0 && damageVar < 5000) {
			/*global.*/sword.SendMessage("ExpUp", expUp * 100 * global.playerLevel);
			Destroy(gameObject);
		}
	}
	
	public void RecieveDamage(int damage) {
		hitPoints -= damage;
		damageVar = damage;
	}

    public void HitBy(GameObject weapon)
    {
        sword = weapon;
    }
}
