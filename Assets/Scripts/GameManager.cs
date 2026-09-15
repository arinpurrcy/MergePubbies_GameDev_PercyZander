using UnityEngine;

//<summary> For now, this script just handles keeping track of the Score. - Zander :3 </summary>
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