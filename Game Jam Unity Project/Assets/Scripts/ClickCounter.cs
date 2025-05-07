using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float maxInteractDistance = 5f;
    public bool showDebugRay = true;

    [Header("Highlight Settings")]
    public Material highlightMaterial; // Assign in Inspector

    private GameObject currentHover;
    private Material originalMaterial;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (showDebugRay)
        {
            Debug.DrawRay(ray.origin, ray.direction * maxInteractDistance, Color.green);
        }

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxInteractDistance))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Clickable"))
            {
                if (currentHover != hitObject)
                {
                    ClearHighlight();
                    currentHover = hitObject;

                    Renderer rend = currentHover.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        originalMaterial = rend.material;
                        rend.material = highlightMaterial;
                    }
                }

                if (Input.GetMouseButtonDown(0))
                {
                    GameManager.Instance.AddScore(1);

                    ConsoleLog clickable = hitObject.GetComponent<ConsoleLog>();
                    if (clickable != null)
                    {
                        clickable.OnClicked();
                    }
                }

            }
            else
            {
                ClearHighlight();
            }
        }
        else
        {
            ClearHighlight();
        }
    }

    void ClearHighlight()
    {
        if (currentHover != null)
        {
            Renderer rend = currentHover.GetComponent<Renderer>();
            if (rend != null && originalMaterial != null)
            {
                rend.material = originalMaterial;
            }
            currentHover = null;
        }
    }
}
