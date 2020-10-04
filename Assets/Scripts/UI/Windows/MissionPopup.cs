using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MissionPopup : MonoBehaviour
{
    [SerializeField] private int currentLevel;

    [SerializeField] private Text levelScoreText;
    private void Start()
    {
        levelScoreText.text = GameController.Instance.SaveKeeper.GetLevelKillsCount(currentLevel).ToString();
    }
}
