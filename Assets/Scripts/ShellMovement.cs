using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class ShellMovement : MonoBehaviour
{
    [SerializeField] private List<Mug> _mugs = new();

    public void ResetMugs()
    {
        _mugs.ForEach(x => x.OnReset());
    }

    public Mug findBallMug()
    {
        for (int i = 0; i < _mugs.Count; i++)
        {
            if (_mugs[i].HasBall == true)
            {
                return _mugs[i];
            }
        }

        return null;
    }

    public Tween PrepareBall(Ball ball)
    {
        return SelectRandomMug().AddBall(ball);
    }

    private Mug SelectRandomMug() => _mugs[Random.Range(0, _mugs.Count)];

    public async UniTask MixMugsAsync()
    {
        for (var i = 0; i < Random.Range(10, 20); i++)
        {
            var second = SelectRandomMug();
            var first = SelectRandomMug();
            while (first == second)
                second = SelectRandomMug();
            second.MixMove(first.Position);
            await first.MixMove(second.Position).AsyncWaitForCompletion();
        }
    }
}