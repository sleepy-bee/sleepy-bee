using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Text _panel;

        private float _remaining = 0;
        private float _step;
        
        public event EventHandler Restarted;
        public event EventHandler Completed;
        public event EventHandler Canceled;

        public bool IsStarted { get; private set; } = false;

        public void Run(float delay, float step = 1)
        {
            if (IsStarted) Cancel();

            _remaining = delay;
            _step = step;

            StartCoroutine(TimerCoroutine());
            InvokeEvent(Restarted);
        }

        public void Cancel()
        {
            if (IsStarted)
            {
                StopCoroutine(TimerCoroutine());
                InvokeEvent(Canceled);
            }
        }

        private IEnumerator TimerCoroutine()
        {
            while (_remaining > 0)
            {
                _panel.text = Format(_remaining);
                yield return new WaitForSeconds(_step);
                _remaining -= _step;
            }

            InvokeEvent(Completed);
        }

        private void InvokeEvent(EventHandler e)
        {
            e?.Invoke(this, EventArgs.Empty);
        }

        private string Format(float time)
        {
            var seconds = Math.Round(time % 60);
            var minutes = Math.Floor(time / 60);
            return (minutes * 100 + seconds).ToString("00:00");
        }
    }
}