using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableManager : MonoBehaviour
{
    [SerializeField]
    private Text txt_Action;
    private bool feedbackMessage = false;
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
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1.0f))
        {
            if (hit.collider.CompareTag("Key"))
            {
                _selection = hit.transform;
                var selectionRenderer = _selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
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

                    txt_Action.text = "<b><Color=Lime>Parabéns, você encontrou a chave.</Color> \n" +
                        "<Color=Magenta>Vá até a porta para tentar abri-la.</Color></b>";
                    feedbackMessage = true;

                    var obj = hit.transform.gameObject;
                    var keyScript = obj.GetComponent<KeyItem>();

                    playerInventory.receiveKey(keyScript.KeyType);
                }
            }
            else if (hit.collider.CompareTag("Door"))
            {
                var obj = hit.transform.gameObject;
                var doorScript = obj.GetComponent<Locked_Door>();
                if (doorScript.Locked && playerInventory.TypeKeys().Count > 0)
                {
                    txt_Action.text = "<b><Color=Lime>A porta está trancada!</Color> \n" +
                    "<Color=Magenta>Aperte 'E' para destrancar a porta.</Color></b>";

                    if (Input.GetKeyDown("e"))
                    {
                        bool success = doorScript.AttemptUnlock(playerInventory.TypeKeys());
                    }
                }
                else if (doorScript.Locked)
                {
                    txt_Action.text = "<b><Color=Lime>A porta está trancada!</Color> \n" +
                    "<Color=Magenta>Desenvolva um script capaz de destrancar ela juntamente com uma chave, a chave está em cima de uma mesa em um dos cômodos. Pegue ela " +
                    "e crie a lógica para destrancar a porta com esta chave.</Color></b>";
                }
                else
                {
                    feedbackMessage = true;
                    txt_Action.text = "<b><Color=Lime>A porta foi destrancada!</Color> \n" +
                    "<Color=Magenta>Parabéns!, está livre agora.</Color></b>";
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
                if (feedbackMessage)
                {
                    Invoke("DesactivateLabel", 3);
                }
                else
                {
                    feedbackMessage = false;
                    DesactivateLabel();
                }
            }
        }
        else
        {
            if (feedbackMessage)
            {
                Invoke("DesactivateLabel", 3);
            }
            else
            {
                feedbackMessage = false;
                DesactivateLabel();
            }
        }
    }

    void DesactivateLabel()
    {
        txt_Action.text = "";
    }
}
