using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
 
    [SerializeField] protected string tipMessage;
    [SerializeField] protected UnityEvent onInteract;

    protected Outline outline;
    protected virtual void Start()
    {
        outline = GetComponent<Outline>();
    }

    public string toggleInteract(bool state)
    {
        if (state)
        {
            outline.OutlineWidth = 10;
            return tipMessage;
        }
        outline.OutlineWidth = 0;
        return "";
    }

    public virtual void Interact()
    {
        onInteract.Invoke();
    }

  
}
