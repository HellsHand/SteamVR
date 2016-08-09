using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    private EnemySpawner spawn;
    private int hitpoints;
    private int dodgeChance;

    void Start()
    {
        dodgeChance = 15;
        hitpoints = 10;
    }

    public void DeathStrike()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        spawn.RemoveEnemy(this);
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        spawn = spawner;
        spawn.AddEnemy(this);
    }

    private void RecieveDamage(int damage)
    {
        hitpoints -= damage;
        if (hitpoints <= 0)
        {
            DeathStrike();
        }
    }

    private void MissedHit()
    {
        Debug.Log("Missed Me!" + gameObject.name);
    }

    public void Attacked(int damage)
    {
        int random = Random.Range(0, 100);
        if (random > dodgeChance)
        {
            RecieveDamage(damage);
        }
        else
        {
            MissedHit();
        }
    }
}
