using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickShell : MonoBehaviour
{
    // Update is called once per frame
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
        }
        if (gameObject.name.Equals("Shell(1)"))
        {
            gameObject.GetComponent<ShellMovement1>().MoveShellUp();
        }
        if (gameObject.name.Equals("Shell(2)"))
        {
            gameObject.GetComponent<ShellMovement2>().MoveShellUp();
        }
        
        //Debug.Log("Object clicked: " + gameObject.name);
        // Add any additional logic you want to execute when the object is clicked
    }
}
