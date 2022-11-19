using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Shadow", fileName = "New Shadow")]
    public class ShadowData : ScriptableObject
    {
        [Tooltip("Некая скорость передвижения, не знаю в каких еденицах")]
        [SerializeField] private float _speed = 40;

        [Tooltip("Задержка между сменами фреймов в секундах")]
        [SerializeField] private float _frameDelay = 1;

        [SerializeField] private Texture2D[] _frames;

        public float Speed { get => _speed * SpeedFactor; protected set => _speed = value; }

        public float SpeedFactor { get; set; } = 1;

        public float FrameDelay { get => _frameDelay; protected set => _frameDelay = value; }

        public IEnumerable<Texture2D> Frames { get => _frames; protected set => _frames = value.ToArray(); }
    }
}