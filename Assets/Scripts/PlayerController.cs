using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    public float speedMultiplier = 5f;
    public float gravity = -9.81f; 

    private float verticalVelocity;

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");


        Vector3 move = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized * speedMultiplier;


        if (characterController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        move.y = verticalVelocity;
        characterController.Move(move * Time.deltaTime);
    }
}