using Assets.Scripts.Communication.Controllers;
using Assets.Scripts.Communication.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float speed;
    public BaseCharacter currentlySelected;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.parent.GetComponent<HeroCharacter>() != null)
                {
                    currentlySelected = hit.transform.parent.GetComponent<BaseCharacter>();
                    Communicator.SendMessage(CommonUIEvents.ShowCardSelectPanel);
                }
                if (hit.transform.parent.GetComponent<BaseCharacter>() != null)
                {
                    currentlySelected = hit.transform.parent.GetComponent<BaseCharacter>();
                }
                else
                {
                    currentlySelected = null;
                }
                Debug.Log("You selected the " + hit.transform.name); 
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.GetComponent<BaseBlock>() != null && currentlySelected != null)
                {
                    HandleMovement(currentlySelected, hit.transform.GetComponent<BaseBlock>());
                }
                else if (hit.transform.parent.GetComponent<BaseCharacter>() != null&&currentlySelected!=null)
                {
                    HandleAttack(currentlySelected, hit.transform.parent.GetComponent<BaseCharacter>());
                }
                else
                {
                    currentlySelected = null;
                }
                Debug.Log("You selected the " + hit.transform.name); 
            }
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            this.transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")*speed*Time.deltaTime));
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            this.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
        }
	}

    private void HandleMovement(BaseCharacter currentlySelected, BaseBlock baseBlock)
    {
        if (currentlySelected.PlayerController == this)
        {
            currentlySelected.TryToMove(baseBlock);
        }
    }

    
    private void HandleAttack(BaseCharacter attacker,BaseCharacter target)
    {
        if (currentlySelected.PlayerController == this)
        {
            attacker.Attack(target);
        }
    }


}
