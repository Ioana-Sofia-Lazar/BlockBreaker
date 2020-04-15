using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.IncrementBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameStatus>().AddToScore();
        Destroy(gameObject);
        level.DecrementBreakableBlocks();
    }
}
