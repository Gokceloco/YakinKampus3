using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public LevelManager levelManager;
    public Player player;

    private void Start()
    {
        RestartLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadPreviousLevel();
        }
    }
    private void LoadNextLevel()
    {
        levelManager.levelNo += 1;
        RestartLevel();
    }
    private void LoadPreviousLevel()
    {
        levelManager.levelNo -= 1;
        RestartLevel();
    }    

    void RestartLevel()
    {
        levelManager.RestartLevel();
        player.RestartPlayer();
    }
}
