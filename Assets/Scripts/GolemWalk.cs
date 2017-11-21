using UnityEngine;

public class GolemWalk : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    private float rotateY;
    private GolemAnimation playerAnim;
    private float h, v;

    void Awake()
    {
        playerAnim = GetComponent<GolemAnimation>();
    }

    void Update()
    {
        CheckMovement();
        AnimatePlayer();
        CheckForAttack();
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
}