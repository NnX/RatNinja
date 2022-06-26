using Enemies;
using Environment;
using GameEnvironment.Keepers.SaveKeeper;
using UnityEngine;

namespace GameEnvironment
{
    public class GameController : MonoBehaviour
    {
        private const float TimeToIncreaseDifficulty = 1f;
        [SerializeField] private GameObject slainedWindow;
        [SerializeField] private GameObject pauseWindowPrefab;
        [SerializeField] private GameObject movingGroundPrefab;
        [SerializeField] private GameObject spawnerPrefab;
        private RectTransform _movingGroundRoot;
        private RectTransform _spawnerRoot;

        [HideInInspector] public int levelKills;
    
        private SaveKeeper _saveKeeper;
        private bool _isGameOnPause;
        private float _timer;
        
        private MovingGround _movingGround;
        private EnemySpawner _enemySpawner;
        public SaveKeeper SaveKeeper => _saveKeeper ??= new SaveKeeper();
        public static GameController Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
            DontDestroyOnLoad(Instance.gameObject);
            //DontDestroyOnLoad(gameObject);
            _spawnerRoot = (RectTransform)FindObjectOfType<SpawnerRoot>().transform;
            _movingGroundRoot = (RectTransform)FindObjectOfType<MovingGroundRoot>().transform;
        }

        private void Start()
        {
            SaveKeeper.LoadDataBox();
            SaveKeeper.SaveDataBox();
            
            // Spawn moving ground and spawner
            var movingGroundObj = Instantiate(movingGroundPrefab, _movingGroundRoot);
            if (movingGroundObj.TryGetComponent<MovingGround>(out var movingGround))
            {
                _movingGround = movingGround;
            }
            
            
            var ratSpawner = Instantiate(spawnerPrefab, _spawnerRoot);
            if (ratSpawner.TryGetComponent<EnemySpawner>(out var enemySpawner))
            {
                _enemySpawner = enemySpawner;
            }
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer> TimeToIncreaseDifficulty)
            {
                ResetDifficultyTimer();
                _movingGround.IncreaseGapSize();
            }
        }

        private void ResetDifficultyTimer()
        {
            _timer = 0;
        }

        public bool GameStopped()
        {
            return _isGameOnPause;
        }

        public void LoadLevel(int level)
        {
            ResumeGame();
            LevelController.Instance.LoadLevel(level);
        }

        public void RestartGame()
        {
            //LevelController.Instance.RestartGame();
            _enemySpawner.Reset();
            _movingGround.ResetGapSize();
            _movingGround.ReinitPlatforms();
            ResetSpeed();
            ResetDifficultyTimer();
            ResumeGame(); 
            
            var playerController = FindObjectOfType<PlayerController>();
            playerController.Reset();
            var playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.Reset();
        }

        public void ToWorldMap()
        {
            LevelController.Instance.LoadLevel(0);
        }
    
        public void PauseGame()
        {
            _isGameOnPause = true;
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            _isGameOnPause = false;
            Time.timeScale = 1f;
        }

        private GameObject _gameOverWindow;
        public void ShowGameOverWindow()
        {
            if (levelKills > SaveKeeper.GetLevelKillsCount(LevelController.Instance.CurrentLevel))
            {
                SaveKeeper.SetLevelKillsCount(LevelController.Instance.CurrentLevel, levelKills);
                SaveKeeper.SaveDataBox();
            }

            _gameOverWindow = Instantiate(slainedWindow, new Vector3(0, 0, 0), Quaternion.identity);
            var canvas = FindObjectOfType<Canvas>();
            _gameOverWindow.transform.SetParent(canvas.transform, false);
            
            
        }

        private GameObject _pauseWindow;
        public void ShowPauseWindow(bool isSHow)
        {
            _isGameOnPause = isSHow;
            if (isSHow)
            {
                
                _pauseWindow = Instantiate(pauseWindowPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                var canvas = FindObjectOfType<Canvas>();
                _pauseWindow.transform.SetParent(canvas.transform, false); 
            }
            else
            {
                ResumeGame();
                if (_pauseWindow)
                {
                 Destroy(_pauseWindow);   
                }   
            }

        }
        
        public void SetSpeed()
        {
            _enemySpawner.IncreaseSpeed();
            _movingGround.SetMoveSpeed();
        }
        public void ResetSpeed()
        {
            _enemySpawner.ResetSpeed();
            _movingGround.ResetSpeed();
        }
    }
}