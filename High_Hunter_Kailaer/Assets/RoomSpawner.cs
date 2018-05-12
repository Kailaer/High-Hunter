using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public int openingDirection;
    // 1 - Need Bottom Doors
    // 2 - Need Top Doors
    // 3 - Need Left Doors
    // 4 - Need Right Doors

    private RoomTemplates templates;
    private bool spawned = false;
    private int rand;

    private void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("SpawnRoom", 0.1f);
    }

    private void SpawnRoom()
    {
        if(!spawned)
        {
            switch(openingDirection)
            {
                case 1: //BOT
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 2: //TOP
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 3: //LEFT
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 4: //RIGHT
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                    break;

            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if((other.GetComponent<RoomSpawner>().spawned == false) && (spawned == false))
            {
                Debug.Log("Instantiate on x: " + transform.position.x + " y: " + transform.position.y);
                Instantiate(templates.wallRoom, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            spawned = true;
        }
    }
}
