using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Game Instance Singleton
    public static GameController Instance { get; private set; } = null;

    private void Awake() {
        // if the singleton hasn't been initialized yet
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void RestartGame() {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
