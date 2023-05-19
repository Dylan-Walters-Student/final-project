using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI blueScoreText;
    [SerializeField] GameObject bumperBlue;
    Collection collection;
    AudioSource ScoreSound;
    int high = 4;
    int mid = 3;

    void Start()
    {
        ScoreSound = GetComponent<AudioSource>();
        blueScoreText = FindObjectOfType<TextMeshProUGUI>();
        collection = FindObjectOfType<Collection>();
        StaticHelper.playerScore = 0;
        ShowScore();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Score(other);
        ShowScore();
    }

    private void Score(Collider2D other)
    {
        if (other.tag == "HighZoneBlue" && StaticHelper.hasPiece)
        {
            StaticHelper.playerScore += StaticHelper.scorebase + high;
            ScoreSound.Play();
            collection.RemoveGamePiece();
            StaticHelper.points += 3;
        }

        if (other.tag == "MidZoneBlue" && StaticHelper.hasPiece)
        {
            StaticHelper.playerScore += StaticHelper.scorebase + mid;
            ScoreSound.Play();
            collection.RemoveGamePiece();
            StaticHelper.points += 2;
        }

        if (other.tag == "LowZoneBlue" && StaticHelper.hasPiece)
        {
            StaticHelper.playerScore += StaticHelper.scorebase;
            ScoreSound.Play();
            collection.RemoveGamePiece();
            StaticHelper.points += 1;
        }
         
    }

    private void ShowScore()
    {
        blueScoreText.text = $"{StaticHelper.playerScore}";
    }
}