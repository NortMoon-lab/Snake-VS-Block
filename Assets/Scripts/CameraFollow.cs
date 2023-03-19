using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    
    private float a;

    private void Start()
    {
        a = transform.position.z - Target.position.z;
    }
    private void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.z = Target.position.z + a;
        transform.position = transformPosition;
    }
}
