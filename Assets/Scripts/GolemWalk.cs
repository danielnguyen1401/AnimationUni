using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GolemWalk : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float radius = 0.3f;
    [SerializeField] private float jumpPower = 200f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPoint;
    private Rigidbody playerBody;
    private float rotateY;
    private GolemAnimation playerAnim;
    private float h, v;
    private bool isGrounded;
    private bool hasJumped;

    void Awake()
    {
        playerAnim = GetComponent<GolemAnimation>();
        playerBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckMovement();
        AnimatePlayer();
        CheckForAttack();
        CheckGroundCollisionAndJump();
    }

    void CheckMovement()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        rotateY -= h * rotationSpeed;
        transform.localRotation = Quaternion.AngleAxis(rotateY, Vector3.up);
    }

    void CheckForAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.Attack1();
        }
        if (Input.GetMouseButtonDown(1))
        {
            playerAnim.Attack2();
        }
    }

    void AnimatePlayer()
    {
        if (v > 0)
        {
            playerAnim.PlayWalk(true);
        }
        else
        {
            playerAnim.PlayWalk(false);
        }
    }

    void CheckGroundCollisionAndJump()
    {
        isGrounded = Physics.OverlapSphere(groundCheckPoint.position, radius, groundLayer).Length > 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerBody.AddForce(new Vector3(0, jumpPower, 0));
                hasJumped = true;
                playerAnim.PlayJump(true);
            }
        }
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.transform.tag == "Ground")
        {
            if (hasJumped)
            {
                hasJumped = false;
                playerAnim.PlayJump(false);
            }
        }
    }
}