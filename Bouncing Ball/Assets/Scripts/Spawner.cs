using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX, dirY, moveSpeed;
    public Transform[] Spawnpoints;
    public GameObject[] enemy;

    [SerializeField]
    private GameObject Obstacle;

    public Vector2 center;
    public Vector2 size;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 50.0f;
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        //int randspawn = Random.Range(0, Spawnpoints.Length);
        //int randenemy = Random.Range(0, enemy.Length);
        //Instantiate(enemy[randenemy], Spawnpoints[randspawn].position, Spawnpoints[randspawn].rotation);
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

    private void spawn()
    {
        bool obstaclespawn = false;

        while (!obstaclespawn)
        {
            int count = 0;
            if (count > 6)
            {
                break;
            }
            else { 
            Vector3 hexagonplace = new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f), 0f);
            if ((hexagonplace - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(Obstacle, hexagonplace, Quaternion.identity);
                obstaclespawn = true;
            }
            count++;
        }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        spawn();
    }

    public void OnDrawGizmosSelected()
    {
        Vector2 areaStartPosition = transform.position;
        Vector2 areaEndPosition = transform.position;
        
    }
}
