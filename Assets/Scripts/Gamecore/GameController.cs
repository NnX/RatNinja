using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
