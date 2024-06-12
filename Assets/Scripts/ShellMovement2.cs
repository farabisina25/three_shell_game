using DG.Tweening;
using UnityEngine;

public class ShellMovement2 : MonoBehaviour
{
    public Vector3 shellposition;
    public Vector3 shell1position;
    public bool up = false;
    
    // Start is called before the first frame update
    void Start()
    {
        shellposition = FindObjectOfType<ShellMovement>().transform.position;
        shell1position = FindObjectOfType<ShellMovement1>().transform.position;
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
    public void Mix20()
    {
        transform.DOMove(shellposition, 1f);
    }
    
    public void Mix21()
    {
        transform.DOMove(shell1position, 1f);
    }
    public void setUpTrue()
    {
        up = true;
    }
    
    public void setUpFalse()
    {
        up = false;
    }
}
