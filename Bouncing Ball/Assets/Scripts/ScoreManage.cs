using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManage : MonoBehaviour
{
    public Player pl;

    #region Singleton

    private static ScoreManage _instance = null;

    public static ScoreManage Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManage>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }

    #endregion
    public int CurrentScore { get { return currentScore; } }

    public int currentScore;

    private void Start()
    {
        ResetCurrentScore();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void IncrementCurrentScore()
    {
        currentScore = pl.TempScore();
    }
}
