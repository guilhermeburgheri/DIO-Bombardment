using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayUIScript : MonoBehaviour
{
    private static readonly int Score_Factor = 10;

    [SerializeField]
    private TextMeshProUGUI scoreLabel;
    
    [SerializeField]
    private TextMeshProUGUI HighestScoreLabel;

    void Start()
    {
        scoreLabel.text = GetScoreString();
        HighestScoreLabel.text = GetHighestScoreString();
    }


    void Update()
    {
        scoreLabel.text = GetScoreString();
        HighestScoreLabel.text = GetHighestScoreString();
    }

    private string GetScoreString()
    {
        return (GameManager.Instance.GetScore() * Score_Factor).ToString();
    }
    
    private string GetHighestScoreString()
    {
        return (GameManager.Instance.GetHighestScore() * Score_Factor).ToString();
    }
}
