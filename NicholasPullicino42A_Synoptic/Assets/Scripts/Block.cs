using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int maxHits;
    [SerializeField] int timesHit = 0;

    [SerializeField] AudioClip breakSound;

    Level level; 
    GameStatus gameStatus;

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();

        if(tag == "breakable")
            level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {   
        if (tag == "breakable")
        {
            timesHit++;
            if (timesHit >= maxHits)
            {
                FindObjectOfType<GameStatus>().AddToScore();
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                Destroy(this.gameObject);
                level.BlockDestroyed();
            }
        }
    } 
}
