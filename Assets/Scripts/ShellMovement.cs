using UnityEngine;
using DG.Tweening;
public class ShellMovement : MonoBehaviour
{
    public ShellMovement1 shell1;
    public ShellMovement2 shell2;
    
    public Vector3 startposition;
    public Vector3 shell1position;
    public Vector3 shell2position;
    public bool up = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
        shell1position = shell1.transform.position;
        shell2position = shell2.transform.position;
    }

    public void MoveShellUp()
    {
        Vector3 destination = new Vector3(transform.position.x, transform.position.y + 30, transform.position.z);
        transform.DOMove(destination, 2f).OnComplete(setUpTrue);
    }

    public void MoveShellDown()
    {
        Vector3 destination = new Vector3(transform.position.x, transform.position.y - 30, transform.position.z);
        transform.DOMove(destination, 2f).OnComplete(setUpFalse);
    }

    public void Mix01()
    {
        transform.DOMove(shell1position, 1f);
    }
    
    public void Mix02()
    {
        transform.DOMove(shell2position, 1f);
    }

    public void setUpTrue()
    {
        up = true;
    }
    
    public void setUpFalse()
    {
        up = false;
    }

    public void Restart()
    {
        transform.DOMove(startposition, 2f);
    }
}
