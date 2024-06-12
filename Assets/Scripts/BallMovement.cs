using UnityEngine;
using DG.Tweening;

public class BallMovement : MonoBehaviour
{
    public Vector3 ShellPosition;

    public Vector3 Shell1Position;

    public Vector3 Shell2Position;
    public bool mid = false;
    public int randomValue;
    public int mixcount;
    
    // Start is called before the first frame update
    void Start()
    {
        ShellPosition = FindObjectOfType<ShellMovement>().transform.position;
        Shell1Position = FindObjectOfType<ShellMovement1>().transform.position;
        Shell2Position = FindObjectOfType<ShellMovement2>().transform.position;
        randomValue = Random.Range(0,3);
        mixcount = 0;
        
        if (randomValue == 0)
        {
            FindObjectOfType<ShellMovement1>().MoveShellUp();
            Invoke("BallGoLeft", 1f);
        }

        if (randomValue == 1)
        {
            FindObjectOfType<ShellMovement>().MoveShellUp();
            Invoke("BallGoMid", 1f);
        }
        if (randomValue == 2)
        {
            FindObjectOfType<ShellMovement2>().MoveShellUp();
            Invoke("BallGoRight", 1f);
        }
        
    }
    void FixedUpdate()
    {
        if (randomValue == 0)
        {
            if (mixcount == 0)
            {
                FindObjectOfType<ShellMovement1>().Invoke("MoveShellDown", 2f);
                mixcount++;
            }
            if (mixcount == 1)
            {
                FindObjectOfType<ShellMovement>().Invoke("Mix01",4f);
                FindObjectOfType<ShellMovement1>().Invoke("Mix10",4f);
                Invoke("BallGoMid", 4f);
                mixcount++;
            }

            if (mixcount == 2)
            {
                FindObjectOfType<ShellMovement>().Invoke("Mix02",6f);
                FindObjectOfType<ShellMovement2>().Invoke("Mix21",6f);
                mixcount++;
            }

            if (mixcount == 3)
            {
                FindObjectOfType<ShellMovement>().Invoke("Mix01",8f);
                FindObjectOfType<ShellMovement2>().Invoke("Mix20",8f);
                FindObjectOfType<ShellMovement1>().Invoke("Mix12",8f);
                Invoke("BallGoRight", 8f);
                mixcount++;
            }
        }

        if (randomValue == 1)
        {
            if (mixcount == 0)
            {
                FindObjectOfType<ShellMovement>().Invoke("MoveShellDown", 2f);
                mixcount++;
            }
            if (mixcount == 1)
            {
                FindObjectOfType<ShellMovement>().Invoke("Mix01",4f);
                FindObjectOfType<ShellMovement1>().Invoke("Mix10",4f);
                Invoke("BallGoLeft", 4);
                mixcount++;
            }

            if (mixcount == 2)
            {
                FindObjectOfType<ShellMovement>().Invoke("Mix02",6f);
                FindObjectOfType<ShellMovement2>().Invoke("Mix21",6f);
                Invoke("BallGoRight", 6f);
                mixcount++;
            }

            if (mixcount == 3)
            {
                FindObjectOfType<ShellMovement>().Invoke("Mix01",8f);
                FindObjectOfType<ShellMovement2>().Invoke("Mix20",8f);
                FindObjectOfType<ShellMovement1>().Invoke("Mix12",8f);
                Invoke("BallGoLeft", 8f);
                mixcount++;
            }
        }

        if (randomValue == 2)
        {
            if (mixcount == 0)
            {
                FindObjectOfType<ShellMovement2>().Invoke("MoveShellDown", 2f);
                mixcount++;
            }
            if (mixcount == 1)
            {
                FindObjectOfType<ShellMovement>().Invoke("Mix01",4f);
                FindObjectOfType<ShellMovement1>().Invoke("Mix10",4f);
                mixcount++;
            }

            if (mixcount == 2)
            {
                FindObjectOfType<ShellMovement>().Invoke("Mix02",6f);
                FindObjectOfType<ShellMovement2>().Invoke("Mix21",6f);
                Invoke("BallGoLeft", 6f);
                mixcount++;
            }

            if (mixcount == 3)
            {
                FindObjectOfType<ShellMovement>().Invoke("Mix01",8f);
                FindObjectOfType<ShellMovement2>().Invoke("Mix20",8f);
                FindObjectOfType<ShellMovement1>().Invoke("Mix12",8f);
                Invoke("BallGoMid", 8f);
                mixcount++;
            }
        }
    }
    

    void BallGoMid()
    {
        transform.DOMove(new Vector3(0, 3f, 0), 1f);
        mid = true;
    }
    
    void BallGoLeft()
    {
        transform.DOMove(new Vector3(-40f, 3f, 0), 1f);
        mid = false;
    }
    
    void BallGoRight()
    {
        transform.DOMove(new Vector3(40f, 3f, 0), 1f);
        mid = false;
    }
}
