using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private CharacterAnimations playerAnimations;
    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;

    // First function that is called
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    void Move()
    {
        // For W/Up key going forward
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
        // For S/Down key going backward
        else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
        // If we don't have any input idle state
        else
        {
            charController.Move(Vector3.zero);
        }
    }

    void Rotate()
    {
        // For A/Left Arrow key rotating Left
        Vector3 rotationDirection = Vector3.zero;
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.left);
        }
        // For D/Right Arrow key rotating Right
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.right);
        }

        if (rotationDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotationDirection), rotateDegreesPerSecond * Time.deltaTime);
        }
    }

    void AnimateWalk()
    {
        if (charController.velocity.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }
        else
        {
            playerAnimations.Walk(false);
        }
    }
}