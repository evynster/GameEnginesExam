using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory : MonoBehaviour
{


    [SerializeField]
    private GameObject floor = null;
    private static GameObject floorObject;

    [SerializeField]
    private GameObject wall = null;
    private static GameObject wallObject;

    [SerializeField]
    private GameObject door = null;
    private static GameObject doorObject;

    [SerializeField]
    private GameObject lvlStart = null;
    private static GameObject levelStart;

    [SerializeField]
    private Material white = null;
    private static Material mat0;
    [SerializeField]
    private Material red = null;
    private static Material mat1;
    [SerializeField]
    private Material orange = null;
    private static Material mat2;
    [SerializeField]
    private Material yellow = null;
    private static Material mat3;
    [SerializeField]
    private Material green = null;
    private static Material mat4;
    [SerializeField]
    private Material blue = null;
    private static Material mat5;
    [SerializeField]
    private Material purple = null;
    private static Material mat6;
    public enum buildingColour
    {
        none,
        red,
        orange,
        yellow,
        green,
        blue,
        purple
    }
    private static List<GameObject> floors;

    public static GameObject createFloor(buildingColour colour)
    {
        GameObject tempFloor = null;
        for (int i = 0; i < floors.Count; i++)
        {
            if (!floors[i].activeSelf)
            {
                floors[i].SetActive(true);
                 tempFloor = floors[i];
                break;
            }
        }
        
        tempFloor.transform.localScale = new Vector3(200, 200, 200);
        tempFloor.layer = LayerMask.NameToLayer("Ground");
        tempFloor = setColour(tempFloor,colour);
        return tempFloor;
    }

    private static List<GameObject> walls;
    public static GameObject createWall(buildingColour colour)
    {
        GameObject tempWall = null;
        for (int i = 0; i < walls.Count; i++)
        {
            if (!walls[i].activeSelf)
            {
                walls[i].SetActive(true);
                tempWall = walls[i];
                break;
            }
        }
        tempWall.transform.localScale = new Vector3(200, 200, 200);
        tempWall.layer = LayerMask.NameToLayer("Ground");
        tempWall = setColour(tempWall, colour);
        return tempWall;
    }
    private static List<GameObject> doors;
    public static GameObject createDoor(buildingColour colour)
    {
        GameObject tempDoor = null;
        for (int i = 0; i < doors.Count; i++)
        {
            if (!doors[i].activeSelf)
            {
                doors[i].SetActive(true);
                tempDoor = doors[i];
                break;
            }
        }
        tempDoor.transform.localScale = new Vector3(200, 200, 200);
        tempDoor.layer = LayerMask.NameToLayer("Ground");
        tempDoor = setColour(tempDoor, colour);
        return tempDoor;
    }

    private static GameObject setColour(GameObject building, buildingColour colour)
    {
        switch (colour)
        {
            case buildingColour.none:
                building.GetComponent<MeshRenderer>().material = mat0;
                break;
            case buildingColour.red:
                building.GetComponent<MeshRenderer>().material = mat1;
                break;
            case buildingColour.orange:
                building.GetComponent<MeshRenderer>().material = mat2;
                break;
            case buildingColour.yellow:
                building.GetComponent<MeshRenderer>().material = mat3;
                break;
            case buildingColour.green:
                building.GetComponent<MeshRenderer>().material = mat4;
                break;
            case buildingColour.blue:
                building.GetComponent<MeshRenderer>().material = mat5;
                break;
            case buildingColour.purple:
                building.GetComponent<MeshRenderer>().material = mat6;
                break;
            default:
                building.GetComponent<MeshRenderer>().material = mat0;
                break;
        }

        return building;
    }

    private void Awake()
    {
        levelStart = lvlStart;
        mat0 = white;
        mat1 = red;
        mat2 = orange;
        mat3 = yellow;
        mat4 = green;
        mat5 = blue;
        mat6 = purple;

        floorObject = floor;
        floors = new List<GameObject>();

        int floorMax = GetComponent<CreateLevel>().maxSizeX * GetComponent<CreateLevel>().maxSizeY /2;
        for (int i = 0; i < floorMax; i++)
        {
            floors.Add(Instantiate(floorObject));
            floors[i].transform.SetParent(levelStart.transform);
            floors[i].SetActive(false);
        }


        wallObject = wall;
        walls = new List<GameObject>();

        int wallMax = floorMax/2;

        for (int i = 0; i < wallMax; i++)
        {
            walls.Add(Instantiate(wallObject));
            walls[i].transform.SetParent(levelStart.transform);
            walls[i].SetActive(false);
        }

        doorObject = door;
        doors = new List<GameObject>();
        int doorMax = GetComponent<CreateLevel>().maxRooms * 2;
        for (int i = 0; i < doorMax; i++)
        {
            doors.Add(Instantiate(doorObject));
            doors[i].transform.SetParent(levelStart.transform);
            doors[i].SetActive(false);
        }

    }
}
