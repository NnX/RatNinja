using UnityEngine.SceneManagement;
public class LevelController : IGameController
{
    private static LevelController _instance;
    public int CurrentLevel { get; private set; } = 1;

    public static LevelController Instance => _instance ?? new LevelController();

    public void LoadLevel(int level)
    {
        CurrentLevel = level;
        if (level == 0)
        {
            SceneManager.LoadScene("WorldMap");
        }
        else
        {
            SceneManager.LoadScene("Level_" + level);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_" + CurrentLevel);
    }
}
