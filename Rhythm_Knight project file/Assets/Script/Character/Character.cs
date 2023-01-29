using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator anim;
    public GameManager GM;

    // Update is called once per frame
    void Update()
    {
        if(GM.hit)
        {
            Attack();
            
        }
        else
        {
            miss();
        }

        if (GM.songEnd)
        {
            Attack();
        }
    }

    void Attack()
    {
        anim.SetBool("Attack1", true);
        
    }

    void miss()
    {
        anim.SetBool("Attack1", false);
        anim.SetTrigger("Hit");
    }
}
