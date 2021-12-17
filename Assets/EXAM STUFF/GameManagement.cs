using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagement : MonoBehaviour
{
    public Camera mainCamera;
    static public float deltaTime = 0f;
    static public int winLose = 0;
    public bool pause = false;

    public Text scoreText;
    public int score = 0;

    public int bullets = 3;
    public Text bulletText;

    public Text lives;

    public Text WinLose;

    private float mouseTime = 0f;
    private float bulletRefresh = 0f;

    public GameObject BirdObject;
    private List<GameObject> birds = new List<GameObject>();
    private float birdSpawnDelay = 0;
    private int activeBirds = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject newBird = GameObject.Instantiate(BirdObject);
            birds.Add(newBird);
        }
        
        bullets = 3;
        scoreText.text = score.ToString();
        bulletText.text = bullets.ToString();
    }
    float pauseTime = 0f;
    // Update is called once per frame
    void Update()
    {
        //text refresh
        scoreText.text = score.ToString();
        bulletText.text = bullets.ToString();
        lives.text = (2 + winLose).ToString();


        activeBirds = 0;
        for (int i = 0; i < 3; i++)
        {
            if (birds[i].activeSelf)
            {
                activeBirds++;
            }
        }
                //bird Spawning
        if (birdSpawnDelay <= 0&&activeBirds<3&&!(winLose==-3||winLose==1))
        {
            for(int i = 0; i < 3; i++)
            {
                if (!birds[i].activeSelf)
                {
                    birds[i].SetActive(true);
                    birds[i].GetComponent<BirdAI>().newStart();
                    birds[i].transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 0f), 0);
                    birdSpawnDelay = Random.Range(0.5f, 2.5f);
                    break;
                }
            }           
        }
        else
        {
            birdSpawnDelay -= Time.deltaTime;
        }


        if (score == 1000)
            winLose = 1;
        if (mouseTime > 0)
        {
            mouseTime -= Time.deltaTime;
        }
        if (pauseTime > 0)
        {
            pauseTime -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&&pauseTime<=0)
        {
            pause = !pause;
        }
        if (!pause)
            deltaTime = Time.deltaTime;
        else
            deltaTime = 0f;

        //Getting new Bullets
        if (bullets < 3 && !(winLose == -3 || winLose == 1))
        {
            bulletRefresh += Time.deltaTime;
            if (bulletRefresh >= 1.5f)
            {
                bullets++;
                bulletRefresh = 0f;
            } 
        }

        if (winLose == -3)//winning and losing
        {
            WinLose.text = "LOST!";
        }
        else if (winLose == 1)
        {
            pause = true;
            WinLose.text = "WIN!";
        }


        if (Input.GetMouseButtonDown(0)&& mouseTime<=0f&&bullets>0&&winLose>-3)//bullet shooting
        {
            mouseTime = 0.2f;
            bullets--;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.CompareTag("Bird"))
                {
                    hitInfo.collider.gameObject.SetActive(false);
                    score += 100;
                }

            }
        }
    }
}
