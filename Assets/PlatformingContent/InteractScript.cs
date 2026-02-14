using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    bool inRange = false;

    bool interact = false;

    [SerializeField] Text interactText;

    public void SetText(string content)
    {
        interactText.text = content;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetText("");
        /*interactText.position.x = this.gameObject.position.x;
        interactText.position.y = this.gameObject.position.y + 2;
        interactText.position.z = this.gameObject.position.z;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true)
        {
            /*if (InputAction.Player.Interact)
            {
                interact = true;
            }*/
        }
        else
        {
            if(interactText.text != "")
            {
                    interactText.text = "";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
           inRange = true;
           interactText.text = "Press [E] to interact.";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Character")
        {
            inRange = false;

        }
    }
}
