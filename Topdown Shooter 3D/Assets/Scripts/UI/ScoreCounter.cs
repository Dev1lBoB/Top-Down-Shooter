using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Text scoreUI;

    private int playerScore = 0;
    private int enemyScore = 0;


    public void UpdateScore(GameObject go)
    {
        // When 1 unit dies adds 1 point to another
        if (go.tag == "Player")
        {
            ++enemyScore;
        }
        else if (go.tag == "Enemy")
        {
            ++playerScore;
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreUI.text = playerScore + ":" + enemyScore;
    }
}
