using Cysharp.Threading.Tasks;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public Ball ball;
    public GameManager game;
    public ShellMovement shells;

    void Update()
    {
        if (PhaseManager.PhaseType != PhaseType.Select)
            return;
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
                if (hit.collider.TryGetComponent<Mug>(out var comp))
                {
                    OnObjectClicked(comp).Forget();
                }
            }
        }
    }

    public async UniTaskVoid OnObjectClicked(Mug mug)
    {
        await mug.Clicked().AsyncWaitForCompletion();
        Mug temp = shells.findBallMug();
        if (temp != mug)
        {
            await mug.Move( new Vector3(mug.transform.position.x, 0 , mug.transform.position.z), 1).AsyncWaitForCompletion();
            await temp.Clicked().AsyncWaitForCompletion();
        }
        
        if (Mathf.Approximately(ball.transform.position.x, mug.Position.x))
        {
            game.Success();
        }
        else game.Loss();
    }
}