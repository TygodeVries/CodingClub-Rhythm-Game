using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int scoreCount = 0;
    TMP_Text scoreText;
    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }


    public void AddScore(int amount)
    {
        scoreCount += amount;
        scoreText.text = "" + scoreCount;
    }

    public void RemoveScore(int amount)
    {
        scoreCount -= amount;
        scoreText.text = "" + scoreCount;
    }
}
