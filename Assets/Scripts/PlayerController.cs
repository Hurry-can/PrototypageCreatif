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

        // 1. Calcul du mouvement horizontal
        Vector3 move = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized * speedMultiplier;

        // 2. Gestion de la gravité
        if (characterController.isGrounded && verticalVelocity < 0)
        {
            // On plaque le personnage au sol
            verticalVelocity = -2f;
        }
        else
        {
            // Le personnage tombe
            verticalVelocity += gravity * Time.deltaTime;
        }

        // 3. Application de la vélocité verticale au mouvement
        move.y = verticalVelocity;

        // 4. Déplacement final
        characterController.Move(move * Time.deltaTime);
    }
}