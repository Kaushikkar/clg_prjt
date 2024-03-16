using UnityEngine;

public class SimpleTouchControl : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Vector2 initialTouchPos;
    private bool isDragging = false;
    private float tapTimeThreshold = 0.2f;
    private float tapTime;
    public bool isTap = false;
    [SerializeField] private float forwardSpeed = 1.0f;
    public SpawnManager manager;
    private Rigidbody rb;
    public LayerMask groundLayer;
    public float rayCastDist;
    public bool isGrounded;
    public float drag;
    public float maxFallSpeed = 10.0f;
    [SerializeField] private float jumpForce;
    public bool isMovingLeft ;
    public bool isMovingRight;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleTouchInput();
        MoveForward();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayCastDist, groundLayer))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;

        }
        if(Input.touchCount==0)
        {
            isMovingLeft = false;
            isMovingRight = false;
        }
        if (isTap)
        {
            Jump();

        }
        
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.drag = drag;
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -maxFallSpeed, Mathf.Infinity), rb.velocity.z);

        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnTouchBegin(touch.position);
                    break;

                case TouchPhase.Moved:
                    OnTouchMove(touch.position);
                    break;

                case TouchPhase.Ended:
                    OnTouchEnd();
                    break;
            }
        }
        else
        {

            tapTime = 0;
            isTap = false;
        }
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);
    }


    void OnTouchBegin(Vector2 touchPosition)
    {
        initialTouchPos = touchPosition;
        isDragging = true;
        tapTime = Time.time;
    }

    void OnTouchMove(Vector2 touchPosition)
    {
        if (!isDragging)
            return;

        float dist = touchPosition.x - initialTouchPos.x;
        if(dist<0 )
        {
            isMovingLeft = true;
            isMovingRight = false;
        }
        else if(dist>0)
        {
            isMovingLeft = false;
            isMovingRight = true;
        }
        else
        {
            isMovingRight = false;
            isMovingLeft = false;
        }
        Vector3 movement = new Vector3(dist, 0, 0);
        Vector3 trgtpos = transform.position + movement;
        transform.position = Vector3.Lerp(transform.position, trgtpos, moveSpeed * Time.deltaTime);
        initialTouchPos = touchPosition;


        if (Time.time - tapTime > tapTimeThreshold)
        {
            isTap = false;
        }
    }

    void OnTouchEnd()
    {
        isDragging = false;


        if (Time.time - tapTime < tapTimeThreshold)
        {
            isTap = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnTrigger"))
        { manager.SpawnTriggerEnter(); }
        
    }
}