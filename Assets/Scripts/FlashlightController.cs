using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject lightSource;
    public  bool isOn = false;
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

            lightSource.transform.LookAt(hit.point);

        }
        else
        {
            lightSource.transform.LookAt(ray.GetPoint(100));
        }
    }
}
