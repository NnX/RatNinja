using UnityEngine; 

public class PlayerController : MonoBehaviour {
    private const string AnimationJump = "JumpAnimation";
    private const string AnimationSlide = "SlideAnimation";
    private const string AnimationLand = "LandAnimation";

    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float jumpPower = 1;

    public Transform groundCheckPosition;

    private bool _touchBegan;
    private Rigidbody2D _myBody;
    private bool _isGrounded;
    private bool _jumped;
    private float _defaultYposition;

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

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerJump();
            anim.Play(AnimationJump);
        }

        if (Input.GetKeyDown (KeyCode.D)) {
            anim.Play (AnimationSlide);
        }

        if (Input.touchCount > 0) {
            var touch = Input.GetTouch (0);
            if (touch.phase == TouchPhase.Began && !_touchBegan) {
                if (touch.position.x < Screen.width >> 1) {
                    PlayerJump();
                    anim.Play(AnimationJump);
                }

                if (touch.position.x > Screen.width >> 1)
                {
                    anim.Play(AnimationSlide);
                }
            }
        }

        var currentJumpStatus = _jumped;
        JumpCheck();
        if(currentJumpStatus && _jumped == false)
        {
            anim.Play(AnimationLand);
        }
    } 
    
    private void PlayerJump()
    {
        if (!_jumped)
        { 
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