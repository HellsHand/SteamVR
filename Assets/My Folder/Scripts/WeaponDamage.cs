using UnityEngine;

public class WeaponDamage : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collided)
    {
        if (collided.tag == "Enemy")
        {
            collided.SendMessage("HitBy", gameObject);
            collided.SendMessage("RecieveDamage", 10);
        }
    }

}
