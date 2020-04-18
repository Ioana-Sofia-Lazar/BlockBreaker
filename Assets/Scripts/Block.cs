using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] Sprite[] damageLevelSprites;

    Level level;

    [SerializeField] int timesHit;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.IncrementBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        
        int maxHits = damageLevelSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextDamageLevelSprite();
        }
    }

    private void ShowNextDamageLevelSprite()
    {
        int spriteIndex = timesHit - 1;
        if (damageLevelSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damageLevelSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSession>().AddToScore(tag);
        Destroy(gameObject);
        level.DecrementBreakableBlocks();
    }
}
