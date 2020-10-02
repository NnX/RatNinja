using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject slainedWindow;
    [SerializeField] private GameObject pauseWindowPrefab;

    public static GameController Instance { get; private set; } = null;

    private bool _isGameOnPause = false;

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy (this.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad (this.gameObject);
    }

    public bool GameStoped () {
        return _isGameOnPause;
    }

    public void LoadLevel (int level) {
        ResumeGame ();
        LevelController.Instance.LoadLevel (level);
    }

    public void RestartGame () {
        ResumeGame ();
        LevelController.Instance.RestartGame ();
    }

    public void ToWorldMap () {
        LevelController.Instance.LoadLevel (0);
    }

    public void OnPauseButtonCick () {
        if (_isGameOnPause) {
            ResumeGame ();
        } else {
            PauseGame ();
        }
    }

    public void PauseGame () {
        _isGameOnPause = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame () {
        _isGameOnPause = false;
        Time.timeScale = 1f;
    }

    public void ShowGameOverWindow () {
        _isGameOnPause = true;
        var slaineWindow = Instantiate (slainedWindow, new Vector3 (0, 0, 0), Quaternion.identity);
        var canvas = FindObjectOfType<Canvas> ();
        slaineWindow.transform.SetParent (canvas.transform, false);
    }

    public void ShowPauseWindow () {
        _isGameOnPause = true;
        var pauseWindow = Instantiate (pauseWindowPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        var canvas = FindObjectOfType<Canvas> ();
        pauseWindow.transform.SetParent (canvas.transform, false);
    }
}