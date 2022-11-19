using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelCutSceneBehaviour : SceneBehaviour
    {
        public event EventHandler Ended;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            Ended.Invoke(this, EventArgs.Empty);
        }

        private void OnDestroy()
        {
            Ended = null;
        }
    }
}