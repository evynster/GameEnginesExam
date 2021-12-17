using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structures
{
    public class Room 
    {
        public Room(bool con = false)
        {
            pos = new Vector2();
            size = new Vector2();
            connected = con;
            roomComponents = new List<GameObject>();
            colour = BuildingFactory.buildingColour.none;
            connectedHalls = new List<Hall>();
        }
        public Vector2 size;
        public Vector2 pos;
        public bool connected;
        public BuildingFactory.buildingColour colour;
        public List<GameObject> roomComponents;
        public List<Hall> connectedHalls;
    }

    public class Hall
    {
        public Hall()
        {}
        public Hall(Vector2 strtPos, Vector2 endPos)
        {
            start = strtPos;
            end = endPos;
        }
        public Hall(float sx, float sy, float ex, float ey)
        {
            start.x = sx;
            start.y = sy;
            end.x = ex;
            end.y = ey;
        }
        public Vector2 start = new Vector2();
        public Vector2 end = new Vector2();
        public List<GameObject> hallComponents = new List<GameObject>();
    }

}
