using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    // Start is called before the first frame update
    private float direction = 1f;
    private float directionSpeed = 1f;
    private float upSpeed = 1f;
    private float directionChange = 0f;
    private float directionChangeVar = 0f;

    [DllImport("resize")]
    private static extern Vector2Int generateRoomSize(int minSize, int maxSize);
    void Start()
    {
        float newScale = generateRoomSize(0.5f,1.2f).x;
        gameObject.transform.localScale = new Vector3(newScale,newScale,newScale);
        upSpeed += Random.Range(0f,1f);
        directionSpeed += Random.Range(0f, 2f);
        directionChange = Random.Range(0, 5);
    }
    
    public void newStart()
    {
        upSpeed += Random.Range(0f, 1f);
        directionSpeed += Random.Range(0f, 2f);
        directionChange = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagement.deltaTime != 0f)
        {
            directionChange += Time.deltaTime;
            if (directionChange >= directionChangeVar)
            {
                directionChange = 0f;
                direction *= -1;
                directionChangeVar = Random.Range(0,5);
            }
            gameObject.transform.Translate(new Vector3(direction *directionSpeed *  Time.deltaTime,Time.deltaTime * upSpeed,0));
        }
        if (transform.position.y >= 8.5f)
        {
            LevelCommandInvoker.AddCommand(new LoseCommand());
            gameObject.SetActive(false);
        }
        if(transform.position.x<=-6.8|| transform.position.x >= 6.8)
        {
            direction *= -1;
        }
    }
}
