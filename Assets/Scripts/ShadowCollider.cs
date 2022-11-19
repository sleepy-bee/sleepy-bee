using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class ShadowCollider : MonoBehaviour
    {
        public event EventHandler ShadowEnter;

        public event EventHandler ShadowExit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Shadow>() != null)
            {
                ShadowEnter?.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Shadow>() != null)
            {
                ShadowExit?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}