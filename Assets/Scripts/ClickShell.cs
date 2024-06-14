using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickShell : MonoBehaviour
{
    public BallMovement ball;
    public ShellMovement shell;
    public ShellMovement1 shell1;
    public ShellMovement2 shell2;
    public GameManager game;
    
    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object hit by the raycast is this object
                if (hit.collider.gameObject == gameObject)
                {
                    OnObjectClicked();
                }
            }
        }
    }
    
    void OnObjectClicked()
    {
        if (gameObject.name.Equals("Shell"))
        {
            gameObject.GetComponent<ShellMovement>().MoveShellUp();
            if (ball.transform.position.x == shell.transform.position.x)
            {
                game.Success();
            }
            else
            {
                game.Loss();
            }
        }
        if (gameObject.name.Equals("Shell(1)"))
        {
            gameObject.GetComponent<ShellMovement1>().MoveShellUp();
            if (ball.transform.position.x == shell1.transform.position.x)
            {
                game.Success();
            }
            else
            {
                game.Loss();
            }
            
        }
        if (gameObject.name.Equals("Shell(2)"))
        {
            gameObject.GetComponent<ShellMovement2>().MoveShellUp();
            if (ball.transform.position.x == shell2.transform.position.x)
            {
                game.Success();
            }
            else
            {
                game.Loss();
            }
        }
    }
}
