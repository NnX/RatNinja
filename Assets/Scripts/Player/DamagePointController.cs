using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePointController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnEnable() {
        anim.Play("PixelPunchSmokeRight");
    }
}
