using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    private Vector3 playerPos;
    private Hidawall room;
    private EnemySpawner spawn;
    private MyController myController;
    private int playerRot;

    // Use this for initialization
    void Start () {
        playerPos = transform.position;
        playerRot = (int)transform.eulerAngles.y;
        if (transform.FindChild("Controller (left)") != null)
        {
            myController = transform.FindChild("Controller (left)").GetComponent<MyController>();
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (!EnemiesLeft()) { 
            PlayerControls();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerRot += 90;
            if (playerRot > 360)
            {
                playerRot -= 360;
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, playerRot, transform.eulerAngles.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            playerRot -= 90;
            if (playerRot < 0)
            {
                playerRot += 360;
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, playerRot, transform.eulerAngles.z);
        }
    }

    private void PlayerControls()
    {
        playerPos.y = transform.position.y;

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(Mathf.Round(transform.forward.x) < 0 && !room.GetWallsBlocked(1))
            {
                playerPos.x += 7.5f;
            }
            else if (Mathf.Round(transform.forward.x) > 0 && !room.GetWallsBlocked(4))
            {
                playerPos.x += -7.5f;
            }
            else if (Mathf.Round(transform.forward.z) < 0 && !room.GetWallsBlocked(3))
            {
                playerPos.z += 7.5f;
            }
            else if (Mathf.Round(transform.forward.z) > 0 && !room.GetWallsBlocked(2))
            {
                playerPos.z += -7.5f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (Mathf.Round(transform.forward.x) < 0 && !room.GetWallsBlocked(4))
            {
                playerPos.x -= 7.5f;
            }
            else if (Mathf.Round(transform.forward.x) > 0 && !room.GetWallsBlocked(1))
            {
                playerPos.x -= -7.5f;
            }
            else if (Mathf.Round(transform.forward.z) < 0 && !room.GetWallsBlocked(2))
            {
                playerPos.z -= 7.5f;
            }
            else if (Mathf.Round(transform.forward.z) > 0 && !room.GetWallsBlocked(3))
            {
                playerPos.z -= -7.5f;
            }
        }
        if(myController != null)
        {
            if (myController.GetNorthPressed() && !room.GetWallsBlocked(1))
            {
                playerPos.x += 7.5f;
            }
            else if (myController.GetEastPressed() && !room.GetWallsBlocked(2))
            {
                playerPos.z += -7.5f;
            }
            else if (myController.GetWestPressed() && !room.GetWallsBlocked(3))
            {
                playerPos.z += 7.5f;
            }
            else if (myController.GetSouthPressed() && !room.GetWallsBlocked(4))
            {
                playerPos.x += -7.5f;
            }
        }

        transform.position = playerPos;
    }

    private bool EnemiesLeft()
    {
        if (spawn != null)
        {
            if (spawn.GetEnemiesLeft() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    public void SetRoom(Hidawall rooms)
    {
        room = rooms;
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        spawn = spawner;
    }

}
