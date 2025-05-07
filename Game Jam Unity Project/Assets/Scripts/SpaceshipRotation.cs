using UnityEngine;

public class SlowRotate : MonoBehaviour
{
    public float rotationSpeedX = 0f;
    public float rotationSpeedY = 0f;
    public float rotationSpeedZ = -0.6f;

    void Update()
    {
        float rotX = rotationSpeedX * Time.deltaTime;
        float rotY = rotationSpeedY * Time.deltaTime;
        float rotZ = rotationSpeedZ * Time.deltaTime;

        transform.Rotate(rotX, rotY, rotZ);
    }
}
