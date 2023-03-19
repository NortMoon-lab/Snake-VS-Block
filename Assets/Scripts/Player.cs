using UnityEngine;

public class Player : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float Sensitivity = 10;
    public int Length = 4;

    private Camera mainCamera;
    private Rigidbody componentRigidbody;
    private PlayerTail compPlayerTail;

    private Vector3 touchLastPos;
    private float sidewaysSpeed;


    void Start()
    {
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody>();
        compPlayerTail = GetComponent<PlayerTail>();

        for (int i = 0; i < Length; i++)
        {
            compPlayerTail.AddTail();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * Sensitivity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            compPlayerTail.AddTail();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            compPlayerTail.RemoveTail();
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        componentRigidbody.velocity = new Vector3(sidewaysSpeed * 5, 0, ForwardSpeed);

        sidewaysSpeed = 0;
    }

    public void StopMovement()
    {
        componentRigidbody.velocity = Vector3.zero;
    }
}
