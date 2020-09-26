using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } = null;
    private bool _isGameOnPause = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLevel(int level)
    {
        LevelController.Instance.LoadLevel(level);
    }

    public void RestartGame()
    {
        LevelController.Instance.RestartGame();
    }

    public void OnPauseButtonCick() {
        if(_isGameOnPause) {
            _isGameOnPause = false;
            ResumeGame();
        } else {
            _isGameOnPause = true;
            PauseGame();
        }
    }
    public void PauseGame() {
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
    }
}
