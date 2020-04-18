using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks;

    [SerializeField] int levelScore = 0;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
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
            sceneLoader.LoadNextScene();
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
