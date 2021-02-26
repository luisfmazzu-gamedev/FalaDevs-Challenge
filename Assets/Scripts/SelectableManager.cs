using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableManager : MonoBehaviour
{
    [SerializeField]
    private Text txt_Action;
    [SerializeField]
    private Material highlightMaterial; // Material that will be applied to selectable objects
    private Material currentObjectMaterial; // Stores the material of the object in order to return its material when unselected

    private Transform _selection;
    bool anyObjectBeingSelected = false;

    [SerializeField]
    private PlayerInventory playerInventory; // Reference to the player inventory

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

                // Player may pick up the key
                CancelInvoke("DesactivateLabel");
                txt_Action.text = "<b><Color=Lime>Chave!</Color> \n" +
                "<Color=Magenta>Aperte 'E' para pegar a chave.</Color></b>";

                if (Input.GetKeyDown("e"))
                {
                    Destroy(hit.transform.gameObject);
                    playerInventory.HasKey = true;

                    txt_Action.text = "<b><Color=Lime>Parabéns, você encontrou a chave.</Color> \n" +
                        "<Color=Magenta>Vá até a porta para tentar abri-la.</Color></b>";

                }
            }
            else if (hit.collider.CompareTag("Door"))
            {
                /*var obj = hit.collider.gameObject;
                var doorObject = obj.TryGetComponent<Locked_Door>();
                if (hit.locked && haveKey)
                {
                    txt_DoorState.text = "<b><Color=Lime>A porta está trancada!</Color> \n" +
                    "<Color=Magenta>Aperte 'E' para destrancar a porta.</Color></b>";

                    if (Input.GetKeyDown("e"))
                    {
                        locked = false;
                        haveKey = true;

                        txt_DoorState.text = "<b><Color=Lime>Parabéns, você encontrou a chave.</Color> \n" +
                            "<Color=Magenta>Vá até a porta para tentar abri-la.</Color></b>";

                    }
                }
                else if (locked)
                {
                    txt_DoorState.text = "<b><Color=Lime>A porta está trancada!</Color> \n" +
                    "<Color=Magenta>Desenvolva um script capaz de destrancar ela juntamente com uma chave, a chave está em cima de uma mesa em um dos cômodos. Pegue ela " +
                    "e crie a lógica para destrancar a porta com esta chave.</Color></b>";
                }
                else
                {
                    txt_DoorState.text = "<b><Color=Lime>A porta foi destrancada!</Color> \n" +
                    "<Color=Magenta>Parabéns!, está livre agora.</Color></b>";
                }*/
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

                DesactivateLabel();
            }
        }
    }

    void DesactivateLabel()
    {
        txt_Action.text = "";
    }
}
