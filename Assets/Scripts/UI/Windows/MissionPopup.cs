using UnityEngine;
using UnityEngine.UI;


public class MissionPopup : MonoBehaviour
{
    [SerializeField] private int currentLevel;
    [SerializeField] private Text levelScoreText;

    private void Start()
    {
        levelScoreText.text = "Hi-Score " + GameController.Instance.SaveKeeper.GetLevelKillsCount(currentLevel).ToString();
    }
}
