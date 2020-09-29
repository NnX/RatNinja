using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject slainedWindow;
    [SerializeField] private GameObject pauseWindowPrefab;
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
        ResumeGame();
        LevelController.Instance.RestartGame();
    }

    public void ToWorldMap() {
        LevelController.Instance.LoadLevel(0);
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

    public void ShowGameOverWindow() {
        var slaineWindow = Instantiate(slainedWindow, new Vector3(0, 0, 0), Quaternion.identity);
        var canvas = FindObjectOfType<Canvas>();
        slaineWindow.transform.SetParent(canvas.transform, false);
    }
    
    public void ShowPauseWindow() {
        var pauseWindow = Instantiate(pauseWindowPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        var canvas = FindObjectOfType<Canvas>();
        pauseWindow.transform.SetParent(canvas.transform, false);
    }
}
