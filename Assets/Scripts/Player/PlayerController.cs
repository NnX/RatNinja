using UnityEngine; 

public class PlayerController : MonoBehaviour {
    private const string AnimationJump = "JumpAnimation";
    private const string AnimationSlide = "SlideAnimation";
    private const string AnimationLand = "LandAnimation";

    [SerializeField] private WeaponController weaponController;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject jumpFxPrefab;
    [SerializeField] private GameObject slideFxPrefab;
    [SerializeField] private Transform jumpFxParent;
    [SerializeField] private AudioSource jumpStart;
    [SerializeField] private AudioSource jumpLand;
    [SerializeField] private float jumpPower = 1;
    [SerializeField] private AudioSource[] slideSounds;
    
    public Transform groundCheckPosition;

    private bool _touchBegan;
    private Rigidbody2D _myBody;
    private bool _isGrounded;
    private bool _jumped;
    private float _defaultYposition;
    private GameObject _jumpFx;
    private GameObject _slideFx;

    private void Awake() {
        if(GameController.Instance != null)
        {
            GameController.Instance.ResumeGame();
        }
        
        _myBody = GetComponent<Rigidbody2D>();

        _defaultYposition = groundCheckPosition.position.y;
    }

    private void Update () {

        if (GameController.Instance != null && GameController.Instance.GameStopped()) {
            return;
        }

        
        if (Input.GetKeyDown(KeyCode.A) && !_jumped)
        {
            OnPlayerJump();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            OnPlayerSlide();
        }

        if (Input.touchCount > 0) {
            var touch = Input.GetTouch (0);
            if (!_jumped && touch.phase == TouchPhase.Began && !_touchBegan) {
                if (touch.position.x < Screen.width >> 1) {
                    OnPlayerJump();
                }

                if (touch.position.x > Screen.width >> 1)
                {
                    OnPlayerSlide();
                }
            }
        }

        var currentJumpStatus = _jumped;
        JumpCheck();
        if(currentJumpStatus && _jumped == false)
        {
            weaponController.DenyDamageCollision();
            jumpLand.Play();
            anim.Play(AnimationLand);
        }
    }

    private void OnPlayerSlide()
    {
        slideSounds[Random.Range(0, slideSounds.Length)].Play();
        anim.Play(AnimationSlide);
        PLaySlideFxAnimation();
    }

    private void OnPlayerJump()
    {
        weaponController.DenyDamageCollision();
        PlayerJump();
        anim.Play(AnimationJump);
        PLayJumpFxAnimation();
    }

    private void PLayJumpFxAnimation()
    {
        if (_jumpFx == null)
        {
            var jumpFx = Instantiate(jumpFxPrefab, jumpFxParent);
            _jumpFx = jumpFx;
            _jumpFx.transform.SetParent(gameObject.transform.parent);
        }
        else
        {
            _jumpFx.transform.position = jumpFxParent.transform.position;
            _jumpFx.SetActive(true);
        }
    }
    private void PLaySlideFxAnimation()
    {
        if (_slideFx == null)
        {
            var jumpFx = Instantiate(slideFxPrefab, jumpFxParent);
            _slideFx = jumpFx;
        }
        else
        {
            _slideFx.SetActive(true);
        }
    }

    private void PlayerJump()
    {
        if (!_jumped)
        { 
            jumpStart.Play();
            _myBody.AddForce(new Vector3(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    private void JumpCheck()
    {
        _jumped = !(groundCheckPosition.position.y <= _defaultYposition);
        if (groundCheckPosition.position.y <= _defaultYposition - 5 && !GameController.Instance.GameStopped())
        {
            GameController.Instance.PauseGame();
            GameController.Instance.ShowGameOverWindow();
        }
    }
        
}