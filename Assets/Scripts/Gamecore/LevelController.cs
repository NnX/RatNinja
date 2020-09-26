using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int _currentLevel;
    private static LevelController _instance;

    public static LevelController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LevelController();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }

    }

    public void LoadLevel(int level)
    {
        _currentLevel = level;
        SceneManager.LoadScene("Level_" + level);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("Level_" + _currentLevel, LoadSceneMode.Single);
    }
}
