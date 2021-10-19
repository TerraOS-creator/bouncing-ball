using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int counter=0;
    int score;
    public Spawner spawner;
    public ScoreManage sm;
    public CircleCollider2D col;
    private void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Enemy") { 
        Destroy(col.gameObject);
        counter++;
            sm.currentScore = TempScore();
           // sp.counter--;

            }

    }
    
    public int TempScore()
    {
        
        score = counter  ;
        return score;
    }

    
}
