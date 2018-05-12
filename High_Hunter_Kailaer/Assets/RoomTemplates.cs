using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

    [Header("Entry Room")]
    public GameObject entryRoom;
    [Header("DirectionRooms")]
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    private void Start()
    {
        CreateDungeon();
    }

    private void CreateDungeon()
    {
        Instantiate(entryRoom, Vector2.zero, Quaternion.identity);
    }
}
