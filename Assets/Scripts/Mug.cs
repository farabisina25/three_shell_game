using System;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class Mug : MonoBehaviour
    {
        public bool HasBall;
        private Sequence _addBallSequence;
        [SerializeField] private Transform mugHolder;
        private Transform _transform;
        public Vector3 Position => _transform.position;

        private void Awake()
        {
            _transform = transform;
        }

        public void OnReset()
        {
            HasBall = false;
            _transform.DOKill();
            mugHolder.DOKill();
            _addBallSequence?.Kill();
            Move(CopyWithY(mugHolder.position, 0), .2f);
        }

        public Tween MixMove(Vector3 position)
        {
            var isMoveLeft = _transform.position.x - position.x > 0;

            var path = new[]
            {
                Position,
                Vector3.Lerp(Position, position, .5f) + (isMoveLeft ? Vector3.forward : Vector3.back) * 15,
                position
            };
            return _transform.DOPath(path, .4f);
        }

        public static Vector3 CopyWithY(Vector3 position, float y)
        {
            return new Vector3(position.x, y, position.z);
        }

        public Tween Move(Vector3 position, float duration)
        {
            return mugHolder.DOMove(position, duration);
        }

        public Sequence AddBall(Ball ball)
        {
            HasBall = true;
            _addBallSequence?.Kill();
            _addBallSequence = DOTween.Sequence()
                .Append(Move(CopyWithY(mugHolder.position, 30), .3f))
                .AppendCallback(() => ball.transform.SetParent(_transform, true))
                .Append(ball.transform.DOLocalMove(Vector3.zero, .4f))
                .Append(Move(CopyWithY(mugHolder.position, 0), .3f));
            return _addBallSequence;
        }

        public Tween Clicked()
        {
            return Move(CopyWithY(mugHolder.position, 30), 1);
        }
    }
}