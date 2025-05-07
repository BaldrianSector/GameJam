using UnityEngine;

public class ConsoleLog : MonoBehaviour
{
    public void OnClicked()
    {
        Debug.Log(gameObject.name + " was clicked!");
        // Add more behavior here

        // Destroy the object after clicking
        Destroy(gameObject);
    }
}
