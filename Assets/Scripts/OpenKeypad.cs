using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeypad : MonoBehaviour
{
    public GameObject keypad1;
    private Interactable currentInteractable;

    void Start()
    {
       
            keypad1.SetActive(false);
       
    }
}
