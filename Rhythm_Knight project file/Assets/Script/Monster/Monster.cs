using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Animator anim;
    public GameManager GM;

    // Update is called once per frame
    void Update()
    {
        if (GM.hit)
        {
            MonsterHurt();
        }

        if (GM.miss)
        {
            MonsterAttack();
        }

        if(GM.songEnd)
        {
            MonsterDeath();
        }
        
    }

    void MonsterHurt()
    {
        anim.SetTrigger("Hurt");

    }

    void MonsterAttack()
    {
        anim.SetTrigger("Attack");
        
    }
    
    void MonsterDeath()
    {
        anim.Play("Monster_death");
       
    }
}
