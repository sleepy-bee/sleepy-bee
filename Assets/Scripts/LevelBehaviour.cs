using System;
using UnityEngine;

namespace Assets.Scripts
{
    public partial class LevelBehaviour : SceneBehaviour
    {
        [SerializeField] private Bee _bee;
        [SerializeField] private Timer _timer;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private ShadowCollider _dangerRange;
        [SerializeField] private ShadowCollider _deadRange;

        private LevelConfig _config;

        public void Init(LevelConfig config)
        {
            _config = config;
            _spawner.SpeedFactor = config.SpeedFactor;
            _spawner.SpawnDelay = config.SpawnDelay;
        }

        public void OnLevelEnded(bool isWin)
        {
            _spawner.KillAll();
        }

        private void Awake()
        {
            Init(new LevelConfig() { TimeToWin = 60, SpeedFactor = 1, SpawnDelay = 1.8f });
        }

        private void Start()
        {
            _dangerRange.ShadowEnter += OnShadowExitToDangerRange;
            _dangerRange.ShadowExit += OnShadowHasLeftDangerRange;
            
            _deadRange.ShadowEnter += OnShadowTouched;

            _timer.Completed += OnTimerCompleted;
            _timer.Run(_config.TimeToWin);

            StartCoroutine(_spawner.SpawnArmyOfShadows());
        }

        private void OnTimerCompleted(object sender, EventArgs e)
        {
            OnLevelEnded(true);
        }

        private void OnShadowTouched(object sender, EventArgs e)
        {
            OnLevelEnded(false);
        }

        private void OnShadowHasLeftDangerRange(object sender, EventArgs e)
        {
            _bee.StopShaking();
        }

        private void OnShadowExitToDangerRange(object sender, EventArgs e)
        {
            _bee.StartShaking();
        }
    }
}