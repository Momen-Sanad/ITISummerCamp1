using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public event Action<int> OnScoreChanged;

    public int Score { get; set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        
        

        OnScoreChanged?.Invoke(Score);
    }
}
