using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWindow : MonoBehaviour
{
    
    void Start()
    {
        GameController.Instance.PauseGame();
    }

    void OnDestroy() {
        GameController.Instance.ResumeGame();
    }
}
