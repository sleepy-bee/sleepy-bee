using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class GamePrefs
    {
        public const string LAST_COMPLETED_LEVEL_KEY = "last-completed-level";

        public static int CurrentLevel
        {
            get => PlayerPrefs.GetInt(LAST_COMPLETED_LEVEL_KEY, 0);
            set => PlayerPrefs.SetInt(LAST_COMPLETED_LEVEL_KEY, value);
        }
    }
}
