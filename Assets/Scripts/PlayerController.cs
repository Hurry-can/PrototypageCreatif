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


        //Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical) * speedMultiplier * Time.deltaTime;

        Vector3 moveDirection = (transform.forward * moveVertical + transform.right * moveHorizontal) * speedMultiplier * Time.deltaTime;

        characterController.Move(moveDirection);


        //Vector3 newPosition = transform.position + speed * Time.deltaTime;

        //transform.position = newPosition;

        //if (moveVertical > .5)
        //    transform.Translate(transform.forward * Time.deltaTime, Camera.main.transform);
        //else if (moveVertical < -.5)
        //    transform.Translate(-transform.forward * Time.deltaTime, Camera.main.transform);
        //if (moveHorizontal > .5)
        //    transform.Translate(transform.right * Time.deltaTime, Camera.main.transform);
        //else if (moveHorizontal < -.5)
        //    transform.Translate(-transform.right * Time.deltaTime, Camera.main.transform);
    }
}
