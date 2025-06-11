using UnityEngine;

public class OrcAnimatorController : MonoBehaviour
{
    Animator animator;
    public float animationSpeed = 1.0f;


    private Vector2 input;
    private Vector2 lastDirection = Vector2.down; 
    private string activeAxis = ""; 
    bool isMoving;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = animationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = input != Vector2.zero;
       
        animator.SetFloat("Horizontal", Mathf.Round(input.x));
        animator.SetFloat("Vertical", Mathf.Round(input.y));
        HandleInput();
        Animate();

    }
    void HandleInput()
    {
        if (activeAxis == "")
        {
            if (Input.GetAxisRaw("Vertical") != 0)
                activeAxis = "Vertical";
            else if (Input.GetAxisRaw("Horizontal") != 0)
                activeAxis = "Horizontal";
        }
        if (activeAxis == "Vertical")
        {
            float v = Input.GetAxisRaw("Vertical");
            input = new Vector2(0, v);

            if (v == 0)
            {
                input = Vector2.zero;
                activeAxis = "";
            }
        }
        else if (activeAxis == "Horizontal")
        {
            float h = Input.GetAxisRaw("Horizontal");
            input = new Vector2(h, 0);

            if (h == 0)
            {
                input = Vector2.zero;
                activeAxis = "";
            }
        }
        else
        {
            input = Vector2.zero;
        }
        if (input != Vector2.zero)
        {
            lastDirection = input;
        }
    }
    void Animate()
    {
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);
        animator.SetFloat("LastHorizontal", lastDirection.x);
        animator.SetFloat("LastVertical", lastDirection.y);

        animator.SetBool("IsMoving", isMoving);
    }
}
