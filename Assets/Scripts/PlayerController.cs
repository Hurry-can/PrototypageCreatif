using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    public float speedMultiplier = 5;


    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 speed = input * speedMultiplier;




        Vector3 moveDirection = (transform.forward * moveVertical + transform.right * moveHorizontal) * speedMultiplier * Time.deltaTime;

        characterController.Move(moveDirection);

    }
}
