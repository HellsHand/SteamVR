using UnityEngine;

public class BloodDrinker : MonoBehaviour {

	public GameObject nextPhase;
	GlobalVar global;
	double weaponExp;
	int weaponLevel, weaponDamage;

    // Use this for initialization
    void Start () {
		weaponExp = 0;
		weaponLevel = 1;
		weaponDamage = 5;
        global = GameObject.FindObjectOfType(typeof(GlobalVar)) as GlobalVar;
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log (weaponExp + " : " + weaponLevel + " : " + global.playerLevel + " : " + weaponDamage);
		
		
		switch(gameObject.name) {
            case "MonkeyBlade":
                if (weaponExp >= 100 * weaponLevel)
                {
                    weaponLevel += 1;
                    weaponExp = weaponExp - (100 * (weaponLevel - 1));
                    SendMessage("DamageUp");
                    if (weaponLevel > 9)
                    {
                        nextPhase.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }


                break;

            case "Phase1":
				if(weaponExp >= 100 * weaponLevel) {
					weaponLevel += 1;
					weaponExp = weaponExp - (100 * (weaponLevel - 1));	
					SendMessage("DamageUp");
					if(weaponLevel > 9) {
                        nextPhase.SetActive(true);
                        gameObject.SetActive(false);
					}
				}
				
				
				break;
				
			case "Phase2":
				if(weaponExp >= 200 * weaponLevel) {
					weaponLevel += 1;
					weaponExp = weaponExp - (100 * (weaponLevel - 1));
					SendMessage("DamageUp");
					if(weaponLevel > 99) {
                        nextPhase.SetActive(true);
                        gameObject.SetActive(false);
					}	
				}
				break;
				
			case "Phase3":
				if(weaponExp >= 200 * weaponLevel) {
					weaponLevel += 1;
					weaponExp = weaponExp - (100 * (weaponLevel - 1));
					SendMessage("DamageUp");
				}
				break;
				
		}
		
	}
	
	public void ExpUp (double exp) {
		switch(gameObject.name) {
            case "MonkeyBlade":
                weaponExp += exp * 4;
                break;
            case "Phase1":
				weaponExp += exp * 2;
				break;
			case "Phase2":
				weaponExp += exp * 1;
				break;
		}
		
	}
	public void DamageUp() {
		switch(gameObject.name) {
		case "Phase1":
			if(weaponLevel >= 10 && weaponLevel <= 20) {
				weaponDamage = 10;
			}
			break;
		case "Phase2":
			if(weaponLevel >= 20 && weaponLevel <= 50) {
				weaponDamage = 20;
			} 
			break;
		case "Phase3":
			
			break;
		}
	}
}
