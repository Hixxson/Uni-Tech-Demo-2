using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item Item;

    public override void Interact()
    {                  
        base.Interact();
        InventoryManager.Instance.Add(Item); 
        Destroy(gameObject);
    }

}
