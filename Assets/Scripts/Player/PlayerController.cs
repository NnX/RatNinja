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
        GameController.Instance.ResumeGame ();
        myBody = GetComponent<Rigidbody2D>();

        defaultYposition = groundCheckPosition.position.y;
        Debug.Log($"[test] groundCheckPosition.positionY = {groundCheckPosition.position.y}, defaultYposition = {defaultYposition}");
    }

    void Update () {

        if (GameController.Instance.GameStoped()) {
            return;
        }

        if (Input.GetKeyDown (KeyCode.D)) {
                                
            anim.Play ("PIxelNinjaPunchRight");
            audioSource.Play ();
        }

        if (Input.GetKeyDown (KeyCode.A)) {/*
            anim.Play ("PixelNinjaPunchLeft");
            audioSource.Play ();*/
            //CheckIfGrounded();
            jumped = true;
            PlayerJump();
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            jumped = false;
        }



        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch (0);
            if (touch.phase == TouchPhase.Began && !touchBegan) {
                touchBegan = true;
                Debug.Log ("Touch Position : " + touch.position);

                if (touch.position.x > (Screen.width / 2)) {
                    anim.Play ("PIxelNinjaPunchRight");
                    audioSource.Play ();
                } else if (touch.position.x < (Screen.width / 2)) {
                    jumped = true;
                    PlayerJump();
/*                    anim.Play ("PixelNinjaPunchLeft");
                    audioSource.Play ();*/
                }
            }

            if (touch.phase == TouchPhase.Ended) {
                touchBegan = false;
                jumped = false;
            } 
        }

        if (groundCheckPosition.position.y <= defaultYposition)
        {
            jumped = false;
        }
        else
        {
            jumped = true;
        }

        void PlayerJump()
        {
            JumpCheck();
            Debug.Log($"[test] isGrounded= {isGrounded}, jumped = {jumped}");
            if (!jumped)
            { 
                myBody.AddForce(new Vector3(0, jumpPower), ForceMode2D.Impulse);
            }
        }
    } // update 
     
    private void JumpCheck() {
        if (groundCheckPosition.position.y <= defaultYposition)
        {
            jumped = false;
        }
        else
        {
            jumped = true;
        }
    }
        
}