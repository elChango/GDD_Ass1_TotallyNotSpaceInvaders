using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsHandler : MonoBehaviour
{
    public TMP_Text textComponent;

    private int score = 0;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }


    public void AddScore(int points)
    {
        score += points;
        textComponent.SetText(string.Format("Score - {0:D6}", score));
        PlayerPrefs.SetInt(ConstantsHelper.KEY_SCORE, score);
    }
}
