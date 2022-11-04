using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject KeypadOB;
    public GameObject HUD;
    public GameObject inventory;

    public GameObject animateOB;
    public Animator ANI;

    public Text textOB;
    public string answer = "1234";

    public bool animate;

    public GameObject openObject;

    void Start()
    {
        KeypadOB.SetActive(true);
    }

    public void Number(int number)
    {
        textOB.text += number.ToString();
    }

    public void back ()
    {
        if (textOB.text.Length == 0) return;

        textOB.text = textOB.text.Remove(textOB.text.Length - 1);
    }

    public void enter()
    {
        if (textOB.text ==  answer)
        {
            textOB.text = "Correct";
            openObject.SetActive(false);
        }
        else
        {
            textOB.text = "WRONG";
        }
    }

    public void clear()
    {
        textOB.text = "";
    }

    public void Exit()
    {
        KeypadOB.SetActive(false);
        inventory.SetActive(false);
        HUD.SetActive(true);

        Camera.main.GetComponent<PlayerCam>().toggleMouse = false;
    }

    public void Open()
    {
        KeypadOB.SetActive(true);
        inventory.SetActive(false);
        HUD.SetActive(false);

        Camera.main.GetComponent<PlayerCam>().toggleMouse = true;

        FirstPersonController fpc = player.GetComponent<FirstPersonController>();

        if (fpc)
        {
            fpc.enabled = false;
        }
    }


    void Update()
    {
        if(textOB.text == "correct" && animate)
        {
            ANI.SetBool("animate", true);
            Debug.Log("door open");
        }

        if (KeypadOB.activeInHierarchy)
        {
            /*
            HUD.SetActive(false);
            inventory.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;*/
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
