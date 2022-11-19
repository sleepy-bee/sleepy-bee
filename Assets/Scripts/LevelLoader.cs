using Assets.Scripts.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public static class LevelLoader
    {
        private static readonly List<LevelConfig> _levelConfigs = new List<LevelConfig>()
        {
            new LevelConfig() { TimeToWin = 60, SpeedFactor = 1, SpawnDelay = 1.8f },
            new LevelConfig() { TimeToWin = 60, SpeedFactor = 1, SpawnDelay = 1.8f },
            new LevelConfig() { TimeToWin = 60, SpeedFactor = 1, SpawnDelay = 1.8f },
            new LevelConfig() { TimeToWin = 60, SpeedFactor = 1, SpawnDelay = 1.8f }
        };

        public static void LoadCurrentLevel()
        {
            var levelConfig = _levelConfigs[GamePrefs.CurrentLevel];

            SceneManager.LoadScene(SceneList.LevelCutScene);

            var cutSceneBehaviour = (LevelCutSceneBehaviour)SceneManager.GetSceneByName(SceneList.LevelCutScene).GetBehaviour();
            cutSceneBehaviour.Ended += (o, e) =>
            {
                SceneManager.LoadScene(SceneList.Level);
                var levelBehaviour = (LevelBehaviour)SceneManager.GetSceneByName(SceneList.Level).GetBehaviour();
                levelBehaviour.Init(levelConfig);
            };
        }

        public static void SwitchToNextLevel()
        {
            GamePrefs.CurrentLevel++;
            LoadCurrentLevel();
        }

        private static void CutSceneBehaviour_Ended(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
