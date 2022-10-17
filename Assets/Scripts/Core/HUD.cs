using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// A HUD
/// </summary>
public class HUD : MonoBehaviour
{
    #region Fields

    // scoring support
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI coinText;

   public int score { get; private set;  }
    public int coin { get; private set; }


    const string ScorePrefix = "Score: ";
    const string coins = "Coin: ";
  


    #endregion

    void Start()
    {
        coinText.text = coins + score.ToString();
        scoreText.text = ScorePrefix + score.ToString();
        
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }
    public void AddCoin(int points)
    {
        coin += points;
        coinText.text = coins + coin.ToString();
    }

}
