using Assets.Scripts.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LobbyBehaviour : SceneBehaviour
    {
        [SerializeField] private string _levelSceneName;

        public void LoadFirstLevel()
        {
            SceneManager.LoadScene(_levelSceneName);
        }

        public void Exit()
        {
            Debug.Log("Bye-bye");
            Application.Quit();
        }
    }
}
