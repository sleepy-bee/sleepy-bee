using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(RawImage))]
    public class Shadow : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ShadowData _data;
        [SerializeField] private Vector3 _target;

        private RawImage _icon;

        public void Init(ShadowData data, Vector2 target)
        {
            StopCoroutine(Animation());
            _data = data;
            _target = target;
            StartCoroutine(Animation());
        }

        public void Kill()
        {
            Debug.Log("I am defeated, but... I'll be back!");
            Destroy(gameObject);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Kill();
        }

        private void Awake()
        {
            _icon = GetComponent<RawImage>();
        }

        private void Start()
        {
            if (_data != null) StartCoroutine(Animation());
        }

        private void FixedUpdate()
        {
            if (_data != null)
            {
                var distance = _target - transform.localPosition;
                var step = Vector3.Normalize(distance) * _data.Speed * Time.fixedDeltaTime;

                transform.position += step;
            }
        }

        private IEnumerator Animation()
        {
            while (true)
            {
                foreach (var frame in _data.Frames)
                {
                    _icon.texture = frame;
                    yield return new WaitForSeconds(_data.FrameDelay);
                }
            }
        }
    }
}