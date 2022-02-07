using GameEnvironment;
using UnityEngine;

namespace UI.Windows
{
    public class GameOverWindow : MonoBehaviour
    {
    
        void Start()
        {
            GameController.Instance.PauseGame();
        }

        void OnDestroy() {
            GameController.Instance.ResumeGame();
        }
    }
}
