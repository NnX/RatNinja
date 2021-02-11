using UnityEngine; 

public class PlayerController : MonoBehaviour {
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int jumpPower = 3;
    [SerializeField] float movingSpeed;

    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    private bool touchBegan;
    private Rigidbody2D myBody;
    private bool isGrounded;
    private bool jumped;
    private float defaultYposition;

    private void Awake() {
        if(GameController.Instance != null)
        {
            GameController.Instance.ResumeGame();
        }
        
        myBody = GetComponent<Rigidbody2D>();

        defaultYposition = groundCheckPosition.position.y;
        Debug.Log($"[test] groundCheckPosition.positionY = {groundCheckPosition.position.y}, defaultYposition = {defaultYposition}");
    }

    void Update () {

        if (GameController.Instance != null && GameController.Instance.GameStoped()) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerJump();
            anim.Play("JumpAnimation");
        }

        if (Input.GetKeyDown (KeyCode.D)) {
            anim.Play ("SlideAnimation");
        }



        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch (0);
            if (touch.phase == TouchPhase.Began && !touchBegan) {
                touchBegan = true;
                Debug.Log ("Touch Position : " + touch.position);

                if (touch.position.x < (Screen.width / 2)) {
                    PlayerJump();
                    anim.Play("JumpAnimation");
                }

                if (touch.position.x > (Screen.width / 2))
                {
                    anim.Play("SlideAnimation");
                }
            }
        }

        var currentJumpStatus = jumped;
        JumpCheck();
        if(currentJumpStatus == true && jumped == false)
        {
            touchBegan = false;
            Debug.Log($"[test] LandAnimation");
            anim.Play("LandAnimation");
        }


    } // update 
    private void PlayerJump()
    {
        Debug.Log($"[test] isGrounded= {isGrounded}, jumped = {jumped}");
        if (!jumped)
        {
            Debug.Log($"[test] jumped = {jumped}");
            myBody.AddForce(new Vector3(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    private void JumpCheck() {

        if (groundCheckPosition.position.y <= defaultYposition)
        {
            jumped = false;
        }
        else
        {
            jumped = true;
        }

        
        Debug.Log($"[test] isGrounded= {isGrounded}, jumped = {jumped}");

        if (groundCheckPosition.position.y <= defaultYposition - 5)
        {
            GameController.Instance.ShowGameOverWindow();
        }
    }
        
}