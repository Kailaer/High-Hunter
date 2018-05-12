using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    //OPENING DIRECTION 
    public int openingDirection;
    //1 -> need bottom room
    //2 -> need top room
    //3 -> need left room
    //4 -> need right room

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    private void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (!spawned)
        {
            switch (openingDirection)
            {
                case 1: //Need B-Room
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 2: //Need T-Room
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 3: //Need L-Room
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 4: //Need R-Room
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
            Destroy(this.gameObject);
        }
    }


}
