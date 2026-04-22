using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    public float speedMultiplier = 5f;
   

    private float verticalVelocity;

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Déplacement horizontal
        Vector3 move = (transform.forward * moveVertical + transform.right * moveHorizontal) * speedMultiplier;

        // Vérifie si le joueur touche le sol


       

        // Applique le déplacement total
        move.y = verticalVelocity;

        characterController.Move(move * Time.deltaTime);
    }
}