using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public class SceneLoader : Singletone<SceneLoader>
    {
        public override void OnAwake()
        {
            Instance = this;
        }
        
        public void LoadByIndex(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void Quit()
        {
            Application.Quit();
        }

    }
}
