using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text Msg;
    [SerializeField] TMP_Text ScoreText1;

    public int playerScore = 0;
    private bool gameOver = false;

    void Start()
    {
        Msg.text = "";
        UpdateScoreUI();
    }

    public void AddPoints(int points)
    {
        if (gameOver) return;

        playerScore += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        ScoreText1.text = "Sammie: " + playerScore;
    }

    public void ShowMissionComplete()
    {
        Msg.text = "MISSION COMPLETE";
        gameOver = true;
    }
}
