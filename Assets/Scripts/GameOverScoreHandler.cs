using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScoreHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();

        int score = PlayerPrefs.GetInt(ConstantsHelper.KEY_SCORE);
        scoreText.SetText(string.Format("You achieved {0:D6} points!", score));

    }
}
