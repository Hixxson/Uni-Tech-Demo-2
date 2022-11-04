using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractManager : MonoBehaviour
{

    public LayerMask interactableLayer;

    private Interactable currentInteractable;

    [SerializeField] private TextMeshProUGUI toolTip;

    void Start()
    {
        toolTip.text = "";
    }

    
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out RaycastHit Hit,10f, interactableLayer))
        {          

            if (Hit.transform.TryGetComponent<Interactable>(out Interactable interactable))
            {
                if(currentInteractable != null)
                {
                    if (interactable != currentInteractable)
                    {
                        // not text on ui 
                        toolTip.text = currentInteractable.toggleInteract(false);
                        currentInteractable = null;
                    }
                }
                // text on ui
                currentInteractable = interactable;
                toolTip.text = currentInteractable.toggleInteract(true);
                
            }
            else if (currentInteractable != null)
            {
                //not text on ui
                toolTip.text = currentInteractable.toggleInteract(false);
                currentInteractable = null;
            }
        }
        else if(currentInteractable != null)
        {
            // not text on ui
            toolTip.text = currentInteractable.toggleInteract(false);
            currentInteractable = null;
        }

        if (Input.GetButtonDown("Fire1") && currentInteractable != null)
        {
            currentInteractable.Interact();
            currentInteractable = null;
            toolTip.text = "";
        }
    }
}
