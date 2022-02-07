using GameEnvironment;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class MissionPopup : MonoBehaviour
    {
        [SerializeField] private int currentLevel;
        [SerializeField] private Text levelScoreText;

        private void Start()
        {
            levelScoreText.text = "Hi-Score " + GameController.Instance.SaveKeeper.GetLevelKillsCount(currentLevel).ToString();
        }
    }
}
