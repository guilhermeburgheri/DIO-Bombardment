using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private static readonly string Key_Highest_Score = "HighestScore";

    public bool isGameOver { get; private set; }
    
    [Header("Audio")]
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource gameOverSfx;
    
    [Header("Score")]
    [SerializeField] private float score;
    [SerializeField] private int highestScore;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        score = 0;
        highestScore = PlayerPrefs.GetInt(Key_Highest_Score);
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;

            if (GetScore() > GetHighestScore())
            {
                highestScore = GetScore();
            }
        }
    }

    public int GetScore() {
        return (int) Mathf.Floor(score);
    }

    public int GetHighestScore()
    {
        return highestScore;
    }

    public void EndGame()
    {
        if (isGameOver) return;

        isGameOver = true;

        musicPlayer.Stop();

        gameOverSfx.Play();

        PlayerPrefs.SetInt(Key_Highest_Score, GetHighestScore());

        StartCoroutine(ReloadScene(6));
    }

    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

}
