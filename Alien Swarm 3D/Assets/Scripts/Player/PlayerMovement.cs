using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;  // The speed that the player will move at.

    Vector3 movement;  // The vector to store the direction of the player's movement.
    Animator anim;  // Reference to the animator component.
    Rigidbody playerRigidBody;  // Reference to the player's rigidbody.
#if !MOBILE_INPUT
    int floorMask;  // Layer mask so that a ray can be cast just at gameobject on the floor layer.
    float camRayLength = 100f;  // The length of the ray from the camera into the scene.
#endif
    void Awake()
    {
#if !MOBILE_INPUT
        //Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");
#endif
        //Set up reference
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Store the input axes.
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

        // Move the player around the scene.
        Move (h, v);

        // Turn the player to face the mouse corner.
        Turning();

        // Animate the player
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        // Set the Movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to its current position plus the movement.
        playerRigidBody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
#if !MOBILE_INPUT
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

            playerRigidBody.MoveRotation (newRotation);
        }
#else
        Vector3 turnDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Mouse X"), 0f, CrossPlatformInputManager.GetAxisRaw("Mouse Y"));

        if (turnDir != Vector3.zero)
        {
            Vector3 playerToMouse = (transform.position + turnDir) - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

            playerRigidBody.MoveRotation (newRotation);
        }
#endif
    }

    void Animating(float h, float v)
    {
        //Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        //Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
