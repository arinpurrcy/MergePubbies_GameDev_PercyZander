using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentScore = 0;
    public static int highScore = 0;

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }
}