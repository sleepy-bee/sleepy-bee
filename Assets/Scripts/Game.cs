using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        private int _currentLevelNumber;
        private List<LevelConfig> _levelConfigs = new List<LevelConfig>()
        {
            new LevelConfig() { TimeToWin = 60, SpeedFactor = 1, SpawnDelay = 1.8f },
            new LevelConfig() { TimeToWin = 60, SpeedFactor = 1, SpawnDelay = 1.8f },
            new LevelConfig() { TimeToWin = 60, SpeedFactor = 1, SpawnDelay = 1.8f },
            new LevelConfig() { TimeToWin = 60, SpeedFactor = 1, SpawnDelay = 1.8f }
        };
    }
}
