using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
  public int height = 500;
  public int width = 1000;
  public int roomHeightMax = 100;
  public int roomWidthtMax = 100;
  public int roomCreateTimes = 20;
  public GameObject block;

  private List<Room> roomList = new List<Room>();
  private int[,] map;
  private Transform mapHolder;

  void Start()
  {
    roomList.Clear();
    for (int i = 0; i < roomCreateTimes; i++)
    {
      AddRoom();
    }


    DrawRoom();
  }

  void Update()
  {

  }

  private void AddRoom()
  {
    Room room = CreateRoom();

    bool isValidRoom = true;

    if (room.X2 >= width || room.Y2 >= height)
    {
      isValidRoom = false;
    }

    for (int i = 0; i < roomList.Count && isValidRoom; i++)
    {
      isValidRoom = !room.isOverlap(roomList[i]);
    }

    if (isValidRoom)
    {
      roomList.Add(room);
    }
  }

  private Room CreateRoom()
  {
    int roomHeight = Random.Range(20, roomHeightMax) + 2;
    int roomWidth = Random.Range(20, roomWidthtMax) + 2;
    int x = Random.Range(1, width / 2) * 2;
    int y = Random.Range(1, height / 2) * 2;

    return new Room(x, y, x + roomWidth, y + roomHeight);
  }

  private void DrawRoom()
  {
    mapHolder = new GameObject("Map").transform;

    for (int i = 0; i < roomList.Count; i++)
    {
      Room room = roomList[i];
      Transform roomHolder = new GameObject("Room" + i).transform;

      for (int x = room.X1; x < room.X2 + 1; x++)
      {
        for (int y = room.Y1; y < room.Y2 + 1; y++)
        {
          GameObject go = Instantiate(block, new Vector2(x, y), Quaternion.identity) as GameObject;
          go.transform.SetParent(roomHolder);
        }
      }

      roomHolder.SetParent(mapHolder);
    }
  }
}
