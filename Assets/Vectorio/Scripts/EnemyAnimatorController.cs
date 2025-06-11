using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim.GetComponent<Animator>();
        // anim.Play("EnemyIdleRight");
    }

    void Update()
    {
       // bool IsTriyingToRun = anim.GetBool("Run");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            //anim.Play(IsTriyingToRun ? "EnemyRunUp" : "OrcWalkUp");
            if (anim.GetBool("Run"))
            {
                anim.Play("EnemyRunUp");

            }
            else
                anim.Play("OrcWalkUp");
            //anim.SetBool("PressedKey", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (anim.GetBool("Run"))
            {
                anim.Play("EnemyRunDown");
            }
            else 
                anim.Play("OrcWalkDown");
            //anim.SetBool("PressedKey", true);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (anim.GetBool("Run"))
            {
                anim.Play("EnemyRunLeft");
            }
            else
                anim.Play("OrcWalkLeft");
            
           // anim.SetBool("PressedKey", true);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (anim.GetBool("Run"))
            {
                anim.Play("EnemyRunRight");
            }
            else
                anim.Play("OrcWalkRight");

            // anim.SetBool("PressedKey", true);

        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //anim.SetBool("PressedKey", false);

            anim.SetTrigger("SetIdle");
        }
    }

}
