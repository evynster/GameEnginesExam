using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaceRoomCommand : LevelCommand
{
    
    Structures.Room room;
    GameObject levelStart;

    public PlaceRoomCommand(Structures.Room r,GameObject l)
    {
        room = r;
        levelStart = l;
    }
    public void Execute()
    {  
        for (int i = 0; i < room.size.x; i++)
        {
            for (int n = 0; n < room.size.y; n++)
            {
                GameObject newFloor = BuildingFactory.createFloor(room.colour);
                
                newFloor.transform.position = new Vector3((room.pos.x + i) * 4, 0, (room.pos.y + n) * 4) + levelStart.transform.position;
                room.roomComponents.Add(newFloor);
                
                if (n == 0)//bottom
                {
                    bool door = false;
                    for(int o = 0; o < room.connectedHalls.Count; o++)
                    {
                        if ((room.connectedHalls[o].start == new Vector2(i + room.pos.x, n + room.pos.y) || room.connectedHalls[o].end == new Vector2(i + room.pos.x, n + room.pos.y))&&(room.connectedHalls[o].start.x == room.connectedHalls[o].end.x))
                        {
                            GameObject newDoor = BuildingFactory.createDoor(room.colour);
                            newDoor.transform.position = new Vector3((room.pos.x + i) * 4, 0, (room.pos.y + n - 0.49f) * 4) + levelStart.transform.position;
                            room.roomComponents.Add(newDoor);
                            door = true;
                        }
                    }
                    if (!door)
                    {
                        GameObject newWall = BuildingFactory.createWall(room.colour);
                        newWall.transform.position = new Vector3((room.pos.x + i) * 4, 0, (room.pos.y + n - 0.49f) * 4) + levelStart.transform.position;
                        room.roomComponents.Add(newWall);
                    }
                }
                else if(n == room.size.y - 1)//top
                {
                    bool door = false;
                    for (int o = 0; o < room.connectedHalls.Count; o++)
                    {
                        if ((room.connectedHalls[o].start == new Vector2(i + room.pos.x, n + room.pos.y+1) || room.connectedHalls[o].end == new Vector2(i + room.pos.x, n + room.pos.y+1)) && (room.connectedHalls[o].start.x == room.connectedHalls[o].end.x))
                        {
                            GameObject newDoor = BuildingFactory.createDoor(room.colour);
                            newDoor.transform.position = new Vector3((room.pos.x + i) * 4, 0, (room.pos.y + n + 0.49f) * 4) + levelStart.transform.position;
                            newDoor.transform.Rotate(Vector3.forward, 180f);
                            room.roomComponents.Add(newDoor);
                            door = true;
                        }
                    }
                    if (!door)
                    {
                        GameObject newWall = BuildingFactory.createWall(room.colour);
                        newWall.transform.position = new Vector3((room.pos.x + i) * 4, 0, (room.pos.y + n + 0.49f) * 4) + levelStart.transform.position;
                        newWall.transform.Rotate(Vector3.forward, 180f);
                        room.roomComponents.Add(newWall);
                    }
                    
                }
                if (i == 0)//left
                {
                    bool door = false;
                    for (int o = 0; o < room.connectedHalls.Count; o++)
                    {
                        if ((room.connectedHalls[o].start == new Vector2(i + room.pos.x , n + room.pos.y) || room.connectedHalls[o].end == new Vector2(i  + room.pos.x, n + room.pos.y)) && (room.connectedHalls[o].start.y == room.connectedHalls[o].end.y ))
                        {
                            GameObject newDoor = BuildingFactory.createDoor(room.colour);
                            newDoor.transform.position = new Vector3((room.pos.x + i - 0.49f) * 4, 0, (room.pos.y + n) * 4) + levelStart.transform.position;
                            newDoor.transform.Rotate(Vector3.forward, 90f);
                            room.roomComponents.Add(newDoor);
                            door = true;
                            
                        }
                    }
                    if (!door)
                    {
                        GameObject newWall = BuildingFactory.createWall(room.colour);
                        newWall.transform.position = new Vector3((room.pos.x + i - 0.49f) * 4, 0, (room.pos.y + n) * 4) + levelStart.transform.position;
                        newWall.transform.Rotate(Vector3.forward, 90f);
                        room.roomComponents.Add(newWall);
                    }
                }
                else if (i == room.size.x - 1)//right
                {
                    bool door = false;
                    for (int o = 0; o < room.connectedHalls.Count; o++)
                    {
                        if ((room.connectedHalls[o].start == new Vector2(i + room.pos.x + 1, n + room.pos.y) || room.connectedHalls[o].end == new Vector2(i + room.pos.x +1, n + room.pos.y)) && (room.connectedHalls[o].start.y == room.connectedHalls[o].end.y))
                        {
                            GameObject newDoor = BuildingFactory.createDoor(room.colour);
                            newDoor.transform.position = new Vector3((room.pos.x + i + 0.49f) * 4, 0, (room.pos.y + n) * 4) + levelStart.transform.position;
                            newDoor.transform.Rotate(Vector3.forward, 270f);
                            room.roomComponents.Add(newDoor);
                            door = true;
                        }
                    }
                    if (!door)
                    {
                        GameObject newWall = BuildingFactory.createWall(room.colour);
                        newWall.transform.position = new Vector3((room.pos.x + i + 0.49f) * 4, 0, (room.pos.y + n) * 4) + levelStart.transform.position;
                        newWall.transform.Rotate(Vector3.forward, 270f);
                        room.roomComponents.Add(newWall);
                    }
                }
            }
        }
    }

    public void Undo()
    {
        for(int i =0;i< room.roomComponents.Count; i++)
        {
            room.roomComponents[i].SetActive(false);
            room.roomComponents[i].transform.rotation = Quaternion.identity;
            room.roomComponents[i].transform.Rotate(Vector3.left, 90);
        }
        room.roomComponents.Clear();
    }
}
