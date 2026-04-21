using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float sensitivity = 200f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        // Bloque la souris au centre et la cache
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. Récupérer le mouvement de la souris
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // 2. Rotation verticale (lever/baisser les yeux)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f); // Limite pour pas faire de salto

        // 3. Appliquer les rotations
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // La caméra pivote verticalement
        playerBody.Rotate(Vector3.up * mouseX); // Le joueur pivote horizontalement
    }
}