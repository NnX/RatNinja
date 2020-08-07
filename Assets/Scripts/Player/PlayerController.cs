using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Animator anim;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)) {
            anim.Play("KungfuKickRight");
        } else if (Input.GetKeyDown(KeyCode.A)) {
            anim.Play("KungfuKickLeft");
        }

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Debug.Log( "Touch Position : " + touch.position);

            if(touch.position.x > (Screen.width / 2)) {
                anim.Play("KungfuKickRight");
            } else if (touch.position.x < (Screen.width / 2)) {
                anim.Play("KungfuKickLeft");
            }
        }  
    }
}
