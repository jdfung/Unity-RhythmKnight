using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterAttackFx : MonoBehaviour
{
    public Animator anim;
    public GameManager GM;

    // Update is called once per frame
    void Update()
    {
        if (GM.miss)
        {
            MonsterAttack();
        }
    }

    void MonsterAttack()
    {
        anim.SetTrigger("Attack");
    }
}
