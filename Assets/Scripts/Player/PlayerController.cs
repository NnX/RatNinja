using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioSource;

    private bool touchBegan;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.Play("KungfuKickRight");
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.Play("KungfuKickLeft");
            audioSource.Play();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && !touchBegan)
            {
                touchBegan = true;
                Debug.Log("Touch Position : " + touch.position);

                if (touch.position.x > (Screen.width / 2))
                {
                    anim.Play("KungfuKickRight");
                    audioSource.Play();
                }
                else if (touch.position.x < (Screen.width / 2))
                {
                    anim.Play("KungfuKickLeft");
                    audioSource.Play();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                touchBegan = false;
            }
        }
    }
}
