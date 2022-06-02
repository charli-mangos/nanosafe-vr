using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAnimation : MonoBehaviour
{
    public Animator animator;
    public string animationName;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "AnimationUnit")
        {
            animator.Play(animationName);

            Destroy(this);
        }
    }
}
