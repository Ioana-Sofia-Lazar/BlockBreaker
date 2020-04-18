using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks;

    [SerializeField] int levelScore = 0;

    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    public void IncrementBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void DecrementBreakableBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            gameSession.HandleLevelWon();
        }
    }

    public void AddToLevelScore(int points)
    {
        levelScore += points;
    }

    public int GetLevelScore()
    {
        return levelScore;
    }
}
