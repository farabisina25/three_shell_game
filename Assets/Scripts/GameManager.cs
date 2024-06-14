using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public BallMovement ball;
    public ShellMovement shell;
    public ShellMovement1 shell1;
    public ShellMovement2 shell2;
    public Score score;
    
    public void Success()
    {
        score.IncrementScore();
        Restart();
    }

    public void Loss()
    {
        score.DecrementScore();
        Restart();
    }

    public void Restart()
    {
        ball.Invoke("Restart", 2f);
        shell.Invoke("Restart", 2f);
        shell1.Invoke("Restart", 2f);
        shell2.Invoke("Restart", 2f);
    }
}
