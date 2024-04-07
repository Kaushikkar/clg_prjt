using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Loop : MonoBehaviour
{
    public Health_Manager hp;
    public GameObject player;
    void Update()
    {
        //Debug.Log(hp.health);
        if(hp.health <= 0 || player.transform.position.y<0 ||hp.isCollided)
        {
            
            
            SceneManager.LoadScene(2);
            
        }
    }
}
