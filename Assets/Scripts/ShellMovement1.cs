using DG.Tweening;
using UnityEngine;

public class ShellMovement1 : MonoBehaviour
{
    public Vector3 shellposition;
    public Vector3 shell2position;
    public bool up = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        shellposition = FindObjectOfType<ShellMovement>().transform.position;
        shell2position = FindObjectOfType<ShellMovement2>().transform.position;
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
    
    public void Mix10()
    {
        transform.DOMove(shellposition, 1f);
    }
    
    public void Mix12()
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
}
