using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHallCommand : LevelCommand
{
    Structures.Hall hall;
    GameObject levelStart;
    public PlaceHallCommand(Structures.Hall h, GameObject l)
    {
        hall = h;
        levelStart = l;
    }
    public void Execute()
    {
        for (int i = 0; i < (int)(hall.end - hall.start).magnitude; i++)
        {
            Vector2 location = ((hall.end - hall.start).normalized*i) + hall.start;
            GameObject newFloor = BuildingFactory.createFloor(0);
            newFloor.transform.position = new Vector3(location.x * 4, 0, location.y * 4) + levelStart.transform.position;
            hall.hallComponents.Add(newFloor);

            float angle = Vector2.Angle((hall.end - hall.start), Vector2.right);

            Vector3 offsetDirection = (Vector2.Perpendicular(hall.end - hall.start).normalized);
            offsetDirection.z = offsetDirection.y;
            offsetDirection.y = 0;
            float offsetDistance = 1.96f;

            GameObject newWall1 = BuildingFactory.createWall(0);
            newWall1.transform.position = new Vector3(location.x * 4, 0, location.y * 4) + levelStart.transform.position + (offsetDirection * offsetDistance);
            newWall1.transform.Rotate(Vector3.forward, angle + 180);
            hall.hallComponents.Add(newWall1);
            GameObject newWall2 = BuildingFactory.createWall(0);
            newWall2.transform.position = new Vector3(location.x * 4, 0, location.y * 4) + levelStart.transform.position + (offsetDirection * -offsetDistance);
            newWall2.transform.Rotate(Vector3.forward, angle);
            hall.hallComponents.Add(newWall2);
        }
        /*
        if (hall.start.x == hall.end.x)//up and down
        {
            if (hall.start.y < hall.end.y)//hall going downwards
                for (int n = (int)hall.start.y; n < (int)hall.end.y; n++)
                {
                    GameObject newFloor = BuildingFactory.createFloor(0);
                    newFloor.transform.position = new Vector3(hall.start.x * 4, 0, n * 4) + levelStart.transform.position;
                    hall.hallComponents.Add(newFloor);

                    GameObject newWall1 = BuildingFactory.createWall(0);
                    newWall1.transform.position = new Vector3((hall.start.x + 0.5f) * 4, 0, (n) * 4) + levelStart.transform.position;
                    newWall1.transform.Rotate(Vector3.forward,270);
                    hall.hallComponents.Add(newWall1);
                    GameObject newWall2 = BuildingFactory.createWall(0);
                    newWall2.transform.position = new Vector3((hall.start.x - 0.5f) * 4, 0, (n) * 4) + levelStart.transform.position;
                    newWall2.transform.Rotate(Vector3.forward, 90);
                    hall.hallComponents.Add(newWall2);
                }
            else//hall going upwards
                for (int n = (int)hall.start.y-1; n >= (int)hall.end.y; n--)
                {
                    GameObject newFloor = BuildingFactory.createFloor(0);
                    newFloor.transform.position = new Vector3(hall.start.x * 4, 0, n * 4) + levelStart.transform.position;
                    hall.hallComponents.Add(newFloor);

                    GameObject newWall1 = BuildingFactory.createWall(0);
                    newWall1.transform.position = new Vector3((hall.start.x + 0.5f) * 4, 0, (n) * 4) + levelStart.transform.position;
                    newWall1.transform.Rotate(Vector3.forward, 270);
                    hall.hallComponents.Add(newWall1);
                    GameObject newWall2 = BuildingFactory.createWall(0);
                    newWall2.transform.position = new Vector3((hall.start.x - 0.5f) * 4, 0, (n) * 4) + levelStart.transform.position;
                    newWall2.transform.Rotate(Vector3.forward, 90);
                    hall.hallComponents.Add(newWall2);
                }
        }
        else
        {
            if (hall.start.x < hall.end.x)//left and right
                for (int n = (int)hall.start.x; n < (int)hall.end.x; n++)//hall going right
                {
                    GameObject newFloor = BuildingFactory.createFloor(0);
                    newFloor.transform.position = new Vector3(n * 4, 0, hall.start.y * 4) + levelStart.transform.position;
                    hall.hallComponents.Add(newFloor);

                    GameObject newWall1 = BuildingFactory.createWall(0);
                    newWall1.transform.position = new Vector3(n * 4, 0, (hall.start.y - 0.5f) * 4) + levelStart.transform.position;
                    hall.hallComponents.Add(newWall1);
                    GameObject newWall2 = BuildingFactory.createWall(0);
                    newWall2.transform.position = new Vector3(n * 4, 0, (hall.start.y + 0.5f) * 4) + levelStart.transform.position;
                    newWall2.transform.Rotate(Vector3.forward, 180);
                    hall.hallComponents.Add(newWall2);
                }
            else//hall going left
                for (int n = (int)hall.start.x-1; n >= (int)hall.end.x; n--)
                {
                    GameObject newFloor = BuildingFactory.createFloor(0);
                    newFloor.transform.position = new Vector3(n * 4, 0, (hall.start.y) * 4) + levelStart.transform.position;
                    hall.hallComponents.Add(newFloor);

                    GameObject newWall1 = BuildingFactory.createWall(0);
                    newWall1.transform.position = new Vector3(n * 4, 0, (hall.start.y + 0.5f) * 4) + levelStart.transform.position;
                    newWall1.transform.Rotate(Vector3.forward, 180);
                    hall.hallComponents.Add(newWall1);
                    GameObject newWall2 = BuildingFactory.createWall(0);
                    newWall2.transform.position = new Vector3(n * 4, 0, (hall.start.y - 0.5f) * 4) + levelStart.transform.position;
                    hall.hallComponents.Add(newWall2);
                }
        }*/
    }
    public void Undo()
    {
        for (int i = 0; i < hall.hallComponents.Count; i++)
        {
            hall.hallComponents[i].SetActive(false);
            hall.hallComponents[i].transform.rotation = Quaternion.identity;
            hall.hallComponents[i].transform.Rotate(Vector3.left, 90);
        }
        hall.hallComponents.Clear();
    }
}