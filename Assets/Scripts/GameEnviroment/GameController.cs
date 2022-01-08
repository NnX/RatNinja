using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject slainedWindow;
    [SerializeField] private GameObject pauseWindowPrefab;
    [HideInInspector] public int levelKills;
    
    private SaveKeeper _saveKeeper;
    private bool _isGameOnPause;

    public SaveKeeper SaveKeeper => _saveKeeper ??= new SaveKeeper();
    public static GameController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SaveKeeper.LoadDataBox();
        SaveKeeper.SaveDataBox();
    }

    public bool GameStopped()
    {
        return _isGameOnPause;
    }

    public void LoadLevel(int level)
    {
        ResumeGame();
        LevelController.Instance.LoadLevel(level);
    }

    public void RestartGame()
    {
        ResumeGame();
        LevelController.Instance.RestartGame();
    }

    public void ToWorldMap()
    {
        LevelController.Instance.LoadLevel(0);
    }
    
    public void PauseGame()
    {
        _isGameOnPause = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        _isGameOnPause = false;
        Time.timeScale = 1f;
    }

    public void ShowGameOverWindow()
    {
        if (levelKills > SaveKeeper.GetLevelKillsCount(LevelController.Instance.CurrentLevel))
        {
            SaveKeeper.SetLevelKillsCount(LevelController.Instance.CurrentLevel, levelKills);
            SaveKeeper.SaveDataBox();
        }

        var slaineWindow = Instantiate(slainedWindow, new Vector3(0, 0, 0), Quaternion.identity);
        var canvas = FindObjectOfType<Canvas>();
        slaineWindow.transform.SetParent(canvas.transform, false);
    }

    public void ShowPauseWindow()
    {
        _isGameOnPause = true;
        var pauseWindow = Instantiate(pauseWindowPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        var canvas = FindObjectOfType<Canvas>();
        pauseWindow.transform.SetParent(canvas.transform, false);
    }
}