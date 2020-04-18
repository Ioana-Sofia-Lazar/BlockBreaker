using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks;

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
}
