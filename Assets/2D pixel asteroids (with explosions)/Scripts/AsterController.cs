using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterController : DestroyAfterExpl
{
    bool explInProgress = false;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartExplosion()
    {
        if (!explInProgress)
        {
            explInProgress = true;
            animator.SetBool("expl", true);
        }
    }

    
}
