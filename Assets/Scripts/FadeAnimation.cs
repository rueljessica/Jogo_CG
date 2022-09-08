using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour {

    public Animator animator;
    public void playGame(){
        animator.SetTrigger("game");
    }
}
