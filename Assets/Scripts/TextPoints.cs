using UnityEngine;

public class TextPoints : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        transform.LookAt(mainCamera.transform);
        transform.rotation = mainCamera.transform.rotation;
    }
}
