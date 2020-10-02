using UnityEngine.SceneManagement;
using UnityEngine;
public class LevelController : IGameController
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
            }

            return _instance;
        }

    }

    public void LoadLevel(int level)
    {
        _currentLevel = level;
        if(level == 0) {
            SceneManager.LoadScene("WorldMap");
        } else {
            SceneManager.LoadScene("Level_" + level);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_" + _currentLevel);
    }
}
