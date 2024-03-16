using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enem_animC : MonoBehaviour
{
    public EnemyAI AI;
    public Animator EnemyAnim;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        followAnim();
        attackAnim();

    }
    void followAnim()
    {
        if (AI.playerInSightRange && AI.playerInAttackRange == false)
        {
            EnemyAnim.SetBool("followPlayer", AI.playerInSightRange);
        }
        else
        {
            EnemyAnim.SetBool("followPlayer", AI.playerInSightRange);
        }
    }
    void attackAnim()
    {
        if (AI.playerInAttackRange && AI.playerInAttackRange)
        {
            EnemyAnim.SetBool("attackPlayer", AI.playerInAttackRange);
            
        }
        else
        {
            EnemyAnim.SetBool("attackPlayer", AI.playerInAttackRange);
            
        }
    }
    public void deathAnim()
    {
        //Debug.Log("Death animation triggered");
        EnemyAnim.SetBool("isDead", true);
    }
}