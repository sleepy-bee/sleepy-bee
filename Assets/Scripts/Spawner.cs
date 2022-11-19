using Assets.Scripts.Extensions;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Shadow _shadowPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private RectTransform[] _spawnZones;
        [SerializeField] private ShadowData[] _shadows;

        public float SpawnDelay { get; set; } = 1.8f;

        public float SpeedFactor { get; set; } = 1;

        public void KillAll()
        {
            _container.GetComponentsInChildren<Shadow>().ToList().ForEach(c => c.Kill());
        }

        public IEnumerator SpawnArmyOfShadows()
        {
            while (true)
            {
                var shadowData = _shadows.Random();
                shadowData.SpeedFactor = SpeedFactor;
                var spawnPoint = GetRandomSpawnPoint();

                var shadow = Instantiate(_shadowPrefab, _container);
                shadow.transform.position = spawnPoint;
                shadow.Init(shadowData, Vector2.zero);
                
                Debug.Log($"Shadow {shadowData.name} spawned");

                yield return new WaitForSeconds(SpawnDelay);
            }
        }

        private Vector2 GetRandomSpawnPoint()
        {
            var spawnZone = _spawnZones.Random();
            var localUpRight = spawnZone.rect.size / 2;
            
            var randomPointInSpawnZone = Vector3.Scale(localUpRight, Random.insideUnitCircle);
            return randomPointInSpawnZone + spawnZone.position;
        }
    }
}