using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncrementScore()
    {
        score++;
    }

    public void DecrementScore()
    {
        score--;
    }
}
