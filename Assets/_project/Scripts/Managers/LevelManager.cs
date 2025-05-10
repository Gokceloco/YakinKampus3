using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;

    private Level _currentLevel;

    public int levelNo;

    internal void RestartLevel()
    {
        DeleteCurrentLevel();
        CreateNewLevel();
    }

    private void CreateNewLevel()
    {
        levelNo = Mathf.Clamp(levelNo, 1, levels.Count);
        _currentLevel = Instantiate(levels[levelNo-1]);
    }

    private void DeleteCurrentLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }
    }
}
