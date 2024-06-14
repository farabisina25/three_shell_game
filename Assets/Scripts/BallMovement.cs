using UnityEngine;
using DG.Tweening;

public class BallMovement : MonoBehaviour
{
    public ShellMovement shell;
    public ShellMovement1 shell1;
    public ShellMovement2 shell2;
    
    public Vector3 startposition;
    public Vector3 ShellPosition;
    public Vector3 Shell1Position;
    public Vector3 Shell2Position;
    public bool mid = false;
    public int randomValue;
    public int mixcount;
    
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
        ShellPosition = shell.transform.position;
        Shell1Position = shell1.transform.position;
        Shell2Position = shell2.transform.position;
        mixcount = 0;
        RandomGo();
    }
    void FixedUpdate()
    {
        if (randomValue == 0)
        {
            if (mixcount == 0)
            {
                shell1.Invoke("MoveShellDown", 1.5f);
                mixcount++;
            }
            if (mixcount == 1)
            {
                shell.Invoke("Mix01",3f);
                shell1.Invoke("Mix10",3f);
                Invoke("BallGoMid", 3f);
                mixcount++;
            }

            if (mixcount == 2)
            {
                shell.Invoke("Mix02",4f);
                shell2.Invoke("Mix21",4f);
                mixcount++;
            }

            if (mixcount == 3)
            {
                shell.Invoke("Mix01",5f);
                shell2.Invoke("Mix20",5f);
                shell1.Invoke("Mix12",5f);
                Invoke("BallGoRight", 5f);
                mixcount++;
            }
        }

        if (randomValue == 1)
        {
            if (mixcount == 0)
            {
                shell.Invoke("MoveShellDown", 1.5f);
                mixcount++;
            }
            if (mixcount == 1)
            {
                shell.Invoke("Mix01",3f);
                shell1.Invoke("Mix10",3f);
                Invoke("BallGoLeft", 3f);
                mixcount++;
            }

            if (mixcount == 2)
            {
                shell.Invoke("Mix02",4f);
                shell2.Invoke("Mix21",4f);
                Invoke("BallGoRight", 4f);
                mixcount++;
            }

            if (mixcount == 3)
            {
                shell.Invoke("Mix01",5f);
                shell2.Invoke("Mix20",5f);
                shell1.Invoke("Mix12",5f);
                Invoke("BallGoLeft", 5f);
                mixcount++;
            }
        }

        if (randomValue == 2)
        {
            if (mixcount == 0)
            {
                shell2.Invoke("MoveShellDown", 1.5f);
                mixcount++;
            }
            if (mixcount == 1)
            {
                shell.Invoke("Mix01",3f);
                shell1.Invoke("Mix10",3f);
                mixcount++;
            }

            if (mixcount == 2)
            {
                shell.Invoke("Mix02",4f);
                shell2.Invoke("Mix21",4f);
                Invoke("BallGoLeft", 4f);
                mixcount++;
            }

            if (mixcount == 3)
            {
                shell.Invoke("Mix01",5f);
                shell2.Invoke("Mix20",5f);
                shell1.Invoke("Mix12",5f);
                Invoke("BallGoMid", 5f);
                mixcount++;
            }
        }
    }

    void RandomGo()
    {
        randomValue = Random.Range(0,3);
        if (randomValue == 0)
        {
            shell1.MoveShellUp();
            Invoke("BallGoLeft", 1f);
        }

        if (randomValue == 1)
        {
            shell.MoveShellUp();
            Invoke("BallGoMid", 1f);
        }
        if (randomValue == 2)
        {
            shell2.MoveShellUp();
            Invoke("BallGoRight", 1f);
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
    
    public void Restart()
    {
        transform.DOMove(startposition, 2f);
        Invoke("RandomGo", 3f);
        Invoke("ResetMix" , 4f);
    }

    public void ResetMix()
    {
        mixcount = 0;
    }
}
