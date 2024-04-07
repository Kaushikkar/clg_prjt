using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class P_collectibles : MonoBehaviour
{
    public float timeToReset;
    public bool notVulnerable;
    public Health_Manager hp;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with collectibles");
        if (collision.gameObject.tag == "collectible")
        {
            Game_Manager.score += 1; // Accessing the static score variable from Game_Manager

            

            //Debug.Log("score:" + Game_Manager.score);
            Destroy(collision.gameObject);
        }
        else
        {
            if (collision.gameObject.tag == "health")
            {
                if (hp.health != 5)
                {
                    hp.health = hp.health + 1;
                }
                Debug.Log(hp.health);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "shield")
            {
                notVulnerable = true;
                Destroy(collision.gameObject);
            }
        }
    }

    private void Update()
    {
        if (notVulnerable)
        {
            StartCoroutine(ResetBoolAfterDelay());
        }

        //Debug.Log("will not take dmg:" + notVulnerable);
    }

    private IEnumerator ResetBoolAfterDelay()
    {
        yield return new WaitForSeconds(timeToReset);
        notVulnerable = false;
    }
}
