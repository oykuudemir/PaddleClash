using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int paddle1Score = 0;
    private int paddle2Score = 0;

    public Text paddle1ScoreText;
    public Text paddle2ScoreText;

    public void paddle1Goal()
    {
        paddle1Score++;
        paddle1ScoreText.text = paddle1Score.ToString();
    }

    public void paddle2Goal()
    {
        paddle2Score++;
        paddle2ScoreText.text = paddle2Score.ToString();
    }
}
