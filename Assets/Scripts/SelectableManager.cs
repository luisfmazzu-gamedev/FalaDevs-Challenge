using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableManager : MonoBehaviour
{
    [SerializeField]
    private Material highlightMaterial; // Material that will be applied to selectable objects
    private Material currentObjectMaterial; // Stores the material of the object in order to return its material when unselected

    private Transform _selection;
    bool anyObjectBeingSelected = false;

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1f))
        {
            if (hit.collider.CompareTag("Key"))
            {
                _selection = hit.transform;
                var selectionRenderer = _selection.GetComponent<Renderer>();
                if(selectionRenderer != null)
                {
                    if (!anyObjectBeingSelected)
                    {
                        // Updates the current object material only upon selection
                        currentObjectMaterial = selectionRenderer.material;
                    }
                    anyObjectBeingSelected = true;
                    selectionRenderer.material = highlightMaterial;
                }
            }
            else
            {
                if (_selection != null)
                {
                    var selectionRenderer = _selection.GetComponent<Renderer>();
                    selectionRenderer.material = currentObjectMaterial;
                    _selection = null;
                    anyObjectBeingSelected = false;
                }
            }
        }
    }
}
