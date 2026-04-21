using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject lightSource;
    private bool isOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightSource.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            lightSource.SetActive(isOn);
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // La lumière et le modèle regardent l'endroit que vous visez
            lightSource.transform.LookAt(hit.point);
            // Optionnel : faites aussi pivoter le modèle 3D vers hit.point
        }
        else
        {
            // Si vous regardez le ciel vide, la lumière pointe droit devant à 100m
            lightSource.transform.LookAt(ray.GetPoint(100));
        }
    }
}
