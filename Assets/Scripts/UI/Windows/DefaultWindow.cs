using UnityEngine;

public class DefaultWindow : MonoBehaviour
{
    private void Start() {
        GameController.Instance.PauseGame();
    }
    
    public void OnClose() {
        GameController.Instance.ResumeGame();
        Destroy(gameObject);
    }
}
