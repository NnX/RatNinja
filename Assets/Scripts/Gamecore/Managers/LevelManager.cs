using UnityEngine.SceneManagement;
public class LevelManager : IGameKeeper
{
    private int _currentLevel;
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
