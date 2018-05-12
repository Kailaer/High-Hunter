using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

    [Header("Special Rooms")]
    public GameObject spawnRoom;
    public GameObject wallRoom;

    [Header("Direction Rooms")]
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    [Header("List")]
    public List<GameObject> rooms;



    private void Start()
    {
        CreateDungeon();
    }

    private void CreateDungeon()
    {
        Instantiate(spawnRoom, transform.position, Quaternion.identity);
    }
}
