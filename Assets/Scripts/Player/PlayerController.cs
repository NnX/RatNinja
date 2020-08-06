using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Animator anim;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)) {
            anim.Play("StrikeRight");
        } else if (Input.GetKeyDown(KeyCode.A)) {
            anim.Play("StrikeLeft");
        }

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Debug.Log( "Touch Position : " + touch.position);

            if(touch.position.x > (Screen.width / 2)) {
                anim.Play("StrikeRight");
            } else if (touch.position.x < (Screen.width / 2)) {
                anim.Play("StrikeLeft");
            }
        }  
    }
}
