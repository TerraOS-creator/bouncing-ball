using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameFlowManager gf;
    private Rigidbody2D rb;
    public Transform[] Spawnpoints;
    public float timeRemaining = 10;
    public int counter = 0;
    [SerializeField]
    private GameObject enemy;
    public float secondsBetweenSpawn = 3;
    public float elapsedTime;
    private int nextUpdate = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {

        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            UpdateEverySecond();
        }

    }
    void UpdateEverySecond()
    {

        if ( timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            elapsedTime++;
            if(elapsedTime > secondsBetweenSpawn)
            {
               elapsedTime = 0;
            Debug.Log(true);
            Spawn();
            }
                
            
        }
        else if (timeRemaining == 0)
        {
            gf.GameOver();
        }
        elapsedTime += Time.deltaTime;

    }
    public void Spawn()
    {
        bool obstaclespawn = false;

        if (counter < 7)
        {
            while (!obstaclespawn)
            {

                Vector3 hexagonplace = new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f), 0f);
                Instantiate(enemy, hexagonplace, Quaternion.identity);
                obstaclespawn = true;
                counter++;

            }
        }

    }

}


