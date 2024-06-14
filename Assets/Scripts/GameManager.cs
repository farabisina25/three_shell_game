using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public ShellMovement shells;
    public Score score;

    private void Start()
    {
        Prepare().Forget();
    }

    public async UniTaskVoid Prepare()
    {
        ball.Restart();
        shells.ResetMugs();
        await UniTask.Delay(TimeSpan.FromSeconds(0.3f));
        PhaseManager.ChangePhase(PhaseType.Preparing);
        await shells.PrepareBall(ball).AsyncWaitForCompletion();
        Mixing().Forget();
    }

    public async UniTaskVoid Mixing()
    {
        PhaseManager.ChangePhase(PhaseType.Mixing);
        await shells.MixMugsAsync();
        PhaseManager.ChangePhase(PhaseType.Select);
    }

    public void Success()
    {
        score.IncrementScore();
        Restart().Forget();
    }

    public void Loss()
    {
        score.DecrementScore();
        Restart().Forget();
    }

    private async UniTaskVoid Restart()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        Prepare().Forget();
    }
}