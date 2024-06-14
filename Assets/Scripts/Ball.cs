using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform startPosition;

    public void Restart()
    {
        transform.DOMove(startPosition.position, .2f);
    }
}