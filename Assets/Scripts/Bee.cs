using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class Bee : MonoBehaviour
    {
        private const string IS_FRIGHTENED = "IsFrightened";

        private Animator _animator;

        public void StartShaking()
        {
            _animator.SetBool(IS_FRIGHTENED, true);
        }

        public void StopShaking()
        {
            _animator.SetBool(IS_FRIGHTENED, false);
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
    }
}