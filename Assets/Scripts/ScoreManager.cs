using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    int score;
    int currentScore;
    void Start()
    {
        score = 0;
    }

   public void OnTeamSelectionResolution()
    {
        // comparer la liste de perso avec les requirements du donjon

        score = currentScore;
        scoreText.text = "score : " + score;
    }

}
