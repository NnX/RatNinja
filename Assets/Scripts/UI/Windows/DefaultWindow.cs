﻿using GameEnvironment;
using UnityEngine;

namespace UI.Windows
{
    public class DefaultWindow : MonoBehaviour
    {
        private void Start() {
            GameController.Instance.PauseGame();
        }
    
        public void OnClose() {
            GameController.Instance.RestartGame();
            Destroy(gameObject);
            //Destroy(gameObject);
        }
    }
}
