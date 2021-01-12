using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerController : MonoBehaviour {
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioSource;

    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    private bool touchBegan;
    private Rigidbody2D myBody;
    private bool isGrounded;
    private bool jumped;
    private float jumpPower = 12f;
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

        if (!jumped)
        {
            if (groundCheckPosition.position.y <= defaultYposition)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, 0);
            }
            else
            {
                myBody.velocity = new Vector2(myBody.velocity.x, -jumpPower);
            }
        }

        void PlayerJump()
        {
            Debug.Log($"[test] isGrounded= {isGrounded}");
            if (jumped)
            { 
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);

                //anim.SetBool("Jump", true);
            }
        }
    } // update 
}