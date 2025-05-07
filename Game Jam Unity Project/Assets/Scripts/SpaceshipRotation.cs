using UnityEngine;

public class SpaceshipRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second
    public GameObject target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the spaceship towards slowly around local X axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float rotationX = horizontalInput * rotationSpeed * Time.deltaTime;
        float rotationY = verticalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);
        
    }
}
