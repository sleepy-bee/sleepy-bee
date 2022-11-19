using System;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Extensions
{
    public static class SceneHelper
    {
        public static SceneBehaviour GetBehaviour(this Scene scene)
        {
            var objects = scene.GetRootGameObjects();
            var behaviour = objects.Select(go => go.GetComponent<SceneBehaviour>()).First(c => c != null);
            
            if (behaviour == null)
            {
                throw new NullReferenceException($"Не найден компонент {nameof(SceneBehaviour)}");
            }

            return behaviour;
        }
    }
}
