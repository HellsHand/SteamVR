using UnityEngine;
using System.Collections.Generic;

public class Hidawall : MonoBehaviour {

    private bool northBlocked, eastBlocked, westBlocked, southBlocked;
    private EnemySpawner spawn;
    private int diff, lvl;
    private Transform obj;

    void Start () {

        obj = gameObject.transform.parent.parent;
        spawn = gameObject.GetComponent<EnemySpawner>();

        if (gameObject.transform.FindChild("NorthWall") != null)
        {
            northBlocked = true;
        }
        if (gameObject.transform.FindChild("EastWall") != null)
        {
            eastBlocked = true;
        }
        if (gameObject.transform.FindChild("WestWall") != null)
        {
            westBlocked = true;
        }
        if (gameObject.transform.FindChild("SouthWall") != null)
        {
            southBlocked = true;
        }

        lvl = Level();
        diff = Difficulty();
        if (gameObject.transform.FindChild("S&S_Torch/Point light") != null)
        {
            gameObject.transform.FindChild("S&S_Torch/Point light").GetComponent<Light>().color = SetTorchColor();
        }
    }
    
    private void OnTriggerEnter(Collider collided)
    {
        if (collided.GetComponent<CharController>() != null)
        {
            collided.GetComponent<CharController>().SetRoom(this);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            if (spawn != null)
            {
                spawn.Spawner();
                spawn.GetPlayer(collided.GetComponent<CharController>());
                if (collided.transform.FindChild("Controller (left)") != null)
                {
                    spawn.SetController(collided.transform.FindChild("Controller (left)").GetComponent<MyController>());
                }
                else
                {
                    Debug.Log("Could not find Controller");
                }
            }
        }
    }

    private void OnTriggerExit(Collider collided)
    {
        if (spawn != null)
        {
            List<Vector3> purgeList = new List<Vector3>(spawn.takenPoints);
            foreach (Vector3 purge in purgeList)
            {
                spawn.takenPoints.Remove(purge);
            }
        }
    }
    public bool GetWallsBlocked(int num)
    {
        switch(num) {
            case 1:
                return northBlocked;
            case 2:
                return eastBlocked;
            case 3:
                return westBlocked;
            case 4:
                return southBlocked;
            default:
                return false;
        }
    }

    private int Level()
    {
        switch (obj.name) {
            case "Dungeon (Level 1)":
                return 1;
            case "Dungeon (Level 2)":
                return 2;
            case "Dungeon (Level 3)":
                return 3;
            case "Dungeon (Level 4)":
                return 4;
            case "Dungeon (Level 5)":
                return 5;
            case "Dungeon (Level 6)":
                return 6;
            case "Dungeon (Level 7)":
                return 7;
            case "Dungeon (Level 8)":
                return 8;
            case "Dungeon (Level 9)":
                return 9;
            case "Dungeon (Level 10)":
                return 10;
            case "Dungeon (Level 11)":
                return 11;
            case "Dungeon (Level 12)":
                return 12;
            case "Dungeon (Level 13)":
                return 13;
            case "Dungeon (Level 14)":
                return 14;
            case "Dungeon (Level 15)":
                return 15;
            case "Dungeon (Level 16)":
                return 16;
            default:
                return 0;
        }
    }

    private int Difficulty()
    {
        if(lvl >= 1 && lvl < 6)
        {
            return 1;
        }
        else if (lvl >= 6 && lvl < 12)
        {
            return 2;
        }
        else if (lvl >= 12)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }

    public int GetDifficulty()
    {
        return diff;
    }

    private Color SetTorchColor()
    {
        if(lvl == 1)
        {
            return new Color(1, 0, 0);
        }
        else if(lvl == 7 )
        {
            return new Color(0, 1, 0);
        }
        if(lvl == 12)
        {
            return new Color(0, 0, 1);
        }
        return new Color(0, 0, 0);
    }
}
