using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

        /*weak = 60% levels 1-5
         * 1-1 & 7-9 = 5%
         * 4-6 = 20%
         * 10-13 = 2.5%
         * 
         *medium = 35% 7-11, weak = 35%
         * 1-2 = 35%
         * 3-4 = 10%
         * 5-6 = 5%
         * weak / 4 rounded to nearest whole number = 30%
         * 
         *strong = 25% 13-16, medium = 25%, weak = 20%
         * 1 = 65%
         * 2 = 35%
         * medium / 3 rounded to the nearest whole number = 10%
         * weak / 6 rounded to the nearsest whole number = 20%*/

    private Hidawall room;
    private MyController myController;
    private GameObject spawner;
    private int difficulty, enemyDifficulty, difficultyClass, counter;
    private bool set = false;

    public GameObject weakEnemySpawn, mediumEnemySpawn, strongEnemeySpawn;

    [HideInInspector]
    public List<EnemyBehaviour> enemies;
    [HideInInspector]
    public List<Vector3> takenPoints;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.K))
        {
            List<EnemyBehaviour> count = new List<EnemyBehaviour>(enemies);
            foreach (EnemyBehaviour enemy in count)
            {
                enemy.DeathStrike();
            }
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            if (enemies.Count > 0)
            {
                int random = Random.Range(0, enemies.Count);
                enemies[random].Attacked(5);
            }
        }
        if(myController != null)
        {
            if (myController.controller.GetPressDown(myController.menuButton))
            {
                List<EnemyBehaviour> count = new List<EnemyBehaviour>(enemies);
                foreach (EnemyBehaviour enemy in count)
                {
                    enemy.DeathStrike();
                }
            }
        }
    }

    public void SetController(MyController control)
    {
        myController = control;
    }

    public void Spawner()
    {
        GetRoom();
        difficulty = room.GetDifficulty();
        Transform spawners = transform.FindChild("SpawnPoints");
        foreach (Transform spawn in spawners)
        {
            takenPoints.Add(spawn.transform.position);
        }

        SpawnController(GetDifficultyClass());

    }

    private void GetRoom()
    {
        room = gameObject.transform.GetComponent<Hidawall>();
    }

    public int GetEnemiesLeft()
    {
        try
        {
            return enemies.Count;
        }
        catch
        {
            return 0;
        }
    }

    public void AddEnemy(EnemyBehaviour enemy)
    {
        try
        {
            enemies.Add(enemy);
        }
        catch
        {
            Debug.Log(enemies);
        }
    }

    public void RemoveEnemy(EnemyBehaviour enemy)
    {
        enemies.Remove(enemy);
    }

    public void GetPlayer(CharController player)
    {
        player.SetSpawner(this);
    }

    Vector3 SelectRandomPoint()
    {
        int rand = Random.Range(0, takenPoints.Count);
        Debug.Log(rand);
        Vector3 spawnPoint = takenPoints[rand];
        takenPoints.Remove(spawnPoint);
        return spawnPoint;
    }

    private void SpawnEnemy()
    {
        if (enemyDifficulty == 1)
        {
            spawner = (GameObject)Instantiate(weakEnemySpawn, SelectRandomPoint(), Quaternion.LookRotation(transform.position));
            spawner.GetComponent<EnemyBehaviour>().SetSpawner(this);
            counter += 1;
            spawner.name = "Weak" + counter;
        }
        else if (enemyDifficulty == 2)
        {
            spawner = (GameObject)Instantiate(mediumEnemySpawn, SelectRandomPoint(), Quaternion.LookRotation(transform.position));
            spawner.GetComponent<EnemyBehaviour>().SetSpawner(this);
            counter += 1;
            spawner.name = "Medium" + counter;
        }
        else if (enemyDifficulty == 3)
        {
            spawner = (GameObject)Instantiate(strongEnemeySpawn, SelectRandomPoint(), Quaternion.LookRotation(transform.position));
            spawner.GetComponent<EnemyBehaviour>().SetSpawner(this);
            counter += 1;
            spawner.name = "Strong" + counter;
        }
    }

    private int GetEnemiesNumber()
    {
        float weakEnemies, mediumEnemies, strongEnemies;
        switch (enemyDifficulty)
        {
            case 1:
                weakEnemies = Random.Range(1, 100);
                if(weakEnemies <= 5)
                {
                    return 1;
                }
                else if(weakEnemies > 5 && weakEnemies <= 10)
                {
                    return 2;
                }
                else if(weakEnemies > 10 && weakEnemies <= 15)
                {
                    return 3;
                }
                else if(weakEnemies > 15 && weakEnemies <= 35)
                {
                    return 4;
                }
                else if(weakEnemies > 35 && weakEnemies <= 55)
                {
                    return 5;
                }
                else if(weakEnemies > 55 && weakEnemies <= 75)
                {
                    return 6;
                }
                else if(weakEnemies > 75 && weakEnemies <= 80)
                {
                    return 7;
                }
                else if(weakEnemies > 80 && weakEnemies <= 85)
                {
                    return 8;
                }
                else if(weakEnemies > 85 && weakEnemies <= 90)
                {
                    return 9;
                }
                else if(weakEnemies > 90 && weakEnemies <= 92.5)
                {
                    return 10;
                }
                else if (weakEnemies > 92.5 && weakEnemies <= 95)
                {
                    return 11;
                }
                else if (weakEnemies > 95 && weakEnemies <= 97.5)
                {
                    return 12;
                }
                else if (weakEnemies > 97.5 && weakEnemies <= 100)
                {
                    return 13;
                }
                else
                {
                    return 0;
                }
            case 2:
                mediumEnemies = Random.Range(1, 100);
                if (mediumEnemies <= 10)
                {
                    return 1;
                }
                else if (mediumEnemies > 10 && mediumEnemies <= 20)
                {
                    return 2;
                }
                else if (mediumEnemies > 20 && mediumEnemies <= 55)
                {
                    return 3;
                }
                else if (mediumEnemies > 55 && mediumEnemies <= 90)
                {
                    return 4;
                }
                else if (mediumEnemies > 90 && mediumEnemies <= 95)
                {
                    return 5;
                }
                else if (mediumEnemies > 95 && mediumEnemies <= 100)
                {
                    return 6;
                }
                else
                {
                    return 0;
                }
            case 3:
                strongEnemies = Random.Range(1, 100);
                if (strongEnemies <= 65)
                {
                    return 1;
                }
                else if (strongEnemies > 65 && strongEnemies <= 100)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            default:
                return 0;
        }
    }

    private int GetDifficultyClass()
    {
        if (difficulty == 1)
        {
            int random = Random.Range(1, 100);
            if (random <= 60)
            {
                return 1;    //weak enemies only
            }
            else
            {
                return 0;    //no enemies
            }
        }
        else if (difficulty == 2)
        {
            int random = Random.Range(1, 100);
            if (random <= 35)
            {
                random = Random.Range(1, 100);
                if (random > 60)
                {
                    return 4;    //medium enemies with weak enemies 
                }
                else
                {
                    return 2;   //medium enemies only
                }
            }
            else if (random > 35 && random <= 70)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else if (difficulty == 3)
        {
            int random = Random.Range(1, 100);
            if (random <= 35)
            {
                random = Random.Range(1, 100);
                if (random > 40 && random <= 70)
                {
                    return 5;    //strong enemies with weak enemies    
                }
                else if (random > 70 && random <= 90)
                {
                    return 6;    //strong enemies with medium enemies
                }
                else if (random > 90 && random <= 100)
                {
                    return 7;    //strong enemies with weak and medium enemies
                }
                else
                {
                    return 3;    //strong enemies only
                }
            }
            else if (random > 35 && random <= 60)
            {
                random = Random.Range(1, 100);
                if (random > 60)
                {
                    return 4;    //medium enemies with weak enemies 
                }
                else
                {
                    return 2;   //medium enemies only
                }
            }
            else if (random > 60 && random <= 80)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }

    }

    private void SpawnController(int diffClass)
    {
        if (counter >= 100 && diffClass < 7)
        {
            diffClass += 1;
            counter = 0;
        }
        if (diffClass == 1)  //weak
        {
            enemyDifficulty = 1;
            int track = GetEnemiesNumber();
            for(int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
        }
        else if (diffClass == 2)    //medium
        {
            enemyDifficulty = 2;
            int track = GetEnemiesNumber();
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
        }
        else if (diffClass == 3)    //strong
        {
            enemyDifficulty = 3;
            int track = GetEnemiesNumber();
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
        }
        else if (diffClass == 4)    //medium with weak
        {
            enemyDifficulty = 1;
            int track = GetEnemiesNumber() / 4;
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
            enemyDifficulty = 2;
            track = GetEnemiesNumber();
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
        }
        else if (diffClass == 5)    //strong with weak
        {
            enemyDifficulty = 1;
            int track = GetEnemiesNumber() / 3;
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
            enemyDifficulty = 3;
            track = GetEnemiesNumber();
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
        }
        else if (diffClass == 6)    //strong with medium
        {
            enemyDifficulty = 2;
            int track = GetEnemiesNumber() / 3;
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
            enemyDifficulty = 3;
            track = GetEnemiesNumber() / 3;
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
        }
        else if (diffClass == 7)    //strong with medium and weak
        {
            enemyDifficulty = 1;
            int track = GetEnemiesNumber() / 6;
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
            enemyDifficulty = 2;
            track = GetEnemiesNumber() / 3;
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
            enemyDifficulty = 3;
            track = GetEnemiesNumber();
            for (int i = 0; i < track; i++)
            {
                SpawnEnemy();
            }
        }
    }
}

  /*Vector3 SelectRandomPoint()
    {
        Vector3 spawnPoint = Vector3.zero;
        Vector2 randomPoint = Random.insideUnitCircle * 3.5f;
        bool match = false;

        if (first)
        {
            float x = randomPoint.x + transform.position.x;
            float y = 0.6f;
            float z = randomPoint.y + transform.position.z;
            spawnPoint = new Vector3(x, y, z);
            takenPoints.Add(spawnPoint);
        }
        else
        {
            while (spawnPoint == Vector3.zero)
            {
                foreach (Vector2 taken in takenPoints)
                {
                    if (randomPoint.x > taken.x -1 && randomPoint.x < taken.x + 1)
                    {
                        match = true;
                    }
                    if (randomPoint.y > taken.y - 1 && randomPoint.y < taken.y + 1)
                    {
                        match = true;
                    }
                }
                if (!match)
                {
                    float x = randomPoint.x + transform.position.x;
                    float y = 0.6f;
                    float z = randomPoint.y + transform.position.z;
                    spawnPoint = new Vector3(x, y, z);
                    takenPoints.Add(spawnPoint);
                }
                else
                {
                    randomPoint = Random.insideUnitCircle * 3.5f;
                    match = false;
                }
            }
        }
        first = false;
        return spawnPoint;  
    }*/
