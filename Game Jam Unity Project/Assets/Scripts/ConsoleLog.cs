using UnityEngine;

public class ConsoleLog : MonoBehaviour
{
    public void OnClicked()
    {
        Debug.Log(gameObject.name + " was clicked!");

        // Disable sibling GameObjects with tag "Steam"
        Transform parent = transform.parent;
        if (parent != null)
        {
            foreach (Transform child in parent)
            {
                if (child.gameObject != this.gameObject && child.CompareTag("Steam"))
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogWarning(gameObject.name + " has no parent, so no siblings to check.");
        }

        // Find MeshRenderer in this object or its children
        MeshRenderer rend = GetComponent<MeshRenderer>();
        if (rend == null)
        {
            rend = GetComponentInChildren<MeshRenderer>();
        }

        if (rend != null)
        {
            Material[] materials = rend.materials;
            foreach (Material mat in materials)
            {
                if (mat.name.StartsWith("Lights"))
                {
                    mat.EnableKeyword("_EMISSION");
                    mat.SetColor("_EmissionColor", Color.green);
                    break;
                }
            }
        }
        else
        {
            Debug.LogWarning("No MeshRenderer found on " + gameObject.name + " or its children.");
        }

        // Remove clickable behavior
        this.enabled = false;

        // Optional: disable collider to prevent further clicks
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }
    }
}