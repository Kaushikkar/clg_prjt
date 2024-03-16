
using UnityEngine;
public class Anim_control : MonoBehaviour
{
    public Animator anim;
    public SimpleTouchControl move;
    
    void Start()
    {

    }
    void Update()
    {
        if (move.isGrounded)
        {
            anim.SetBool("jumped", move.isTap);
        }
        
    }
}
