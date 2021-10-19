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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
            
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Spawn();
        }
        else if (timeRemaining == 0)
        {
            gf.GameOver();
        }

    }
    public void Spawn()
    {
        bool obstaclespawn = false;
        
        if (counter < 7) {
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


