﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private BoxCollider2D bc;

    private bool inTeleporter;
    private GameObject targetExit;

    public bool dialogueInProgress;
    public bool dialoguePossible;
    private Dialogue targetDialogue;
    public int targetNPC;

    private bool pickupPossible;
    private GameObject targetPickup;
    private int pickupID;

    public GameObject arrowIndicator;
    private GameObject iArrowIndicator;

    void Start() {
        bc = GetComponent<BoxCollider2D>();
        inTeleporter = false;
        targetNPC = 5; // some random number

        DialogueManager.Instance.StartDialogue(DialogueManager.Instance.introDialogue);
        dialogueInProgress = true;
    }

    void FixedUpdate() {
        if (dialogueInProgress == false) ProcessMovementInput();
    }

   void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && inTeleporter == true) {
            Teleport(targetExit);
        } else if (Input.GetKeyDown(KeyCode.Space) && dialoguePossible == true && dialogueInProgress == false) {
            DialogueManager.Instance.StartDialogue(targetDialogue);
            dialogueInProgress = true;
        } else if (Input.GetKeyDown(KeyCode.Space) && dialogueInProgress == true) {
            DialogueManager.Instance.DisplayNextSentence();
        } else if (Input.GetKeyDown(KeyCode.Space) && pickupPossible == true) {
            if (GameManager.Instance.heldItem == 0) {
                GameManager.Instance.heldItem = pickupID;
                GameManager.Instance.UpdateAdrian(pickupID);
                GameplayUI.Instance.UpdateHeldItem(pickupID);
                Destroy(targetPickup);
            } 

        }
    }

    void ProcessMovementInput() {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Mathf.Sign(horizontalInput) * Vector2.right, (bc.bounds.size.x / 2.0f + 0.5f), LayerMask.GetMask("Wall"));
            if (hit.collider == null) {
                Move(horizontalInput, moveSpeed);
            }
        }
    }

    void Move(float horizontalInput, float moveSpeed) {
        Vector3 moveVector = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(moveVector);
    }

    public void Teleport(GameObject destination) {

        RaycastHit2D hit = Physics2D.Raycast(destination.transform.position, -Vector2.up, 15.0f, LayerMask.GetMask("Floor"));

        Vector3 verticalOffset = new Vector3(0, -(hit.distance - bc.bounds.size.y / 2.0f), 0);

        transform.position = destination.transform.position + verticalOffset;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Teleporter")) {
            if (inTeleporter == false) {
                targetExit = collision.GetComponent<Teleporter>().exit;
                if (iArrowIndicator == null)
                    iArrowIndicator = Instantiate(arrowIndicator, collision.gameObject.transform.position + new Vector3(0, 12.0f, 0), Quaternion.identity);
            }
            inTeleporter = true;
            
        } else if (collision.gameObject.layer == LayerMask.NameToLayer("NPC")) {
            if (dialoguePossible == false) {
                targetDialogue = collision.GetComponent<DialogueTrigger>().dialogue;
                targetNPC = collision.GetComponent<DialogueTrigger>().npcID;
                if (iArrowIndicator == null)
                    iArrowIndicator = Instantiate(arrowIndicator, collision.gameObject.transform.position + new Vector3(0, 12.0f, 0), Quaternion.identity);
            }
                
            dialoguePossible = true;
                
        } else if (collision.gameObject.layer == LayerMask.NameToLayer("Pickup")) {
            if (pickupPossible == false) {
                targetPickup = collision.gameObject;
                pickupID = targetPickup.GetComponent<Pickup>().pickupID;
                if (iArrowIndicator == null)
                    iArrowIndicator = Instantiate(arrowIndicator, collision.gameObject.transform.position + new Vector3(0, 12.0f, 0), Quaternion.identity);
            }
                
            pickupPossible = true;
                
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Teleporter")) {
            inTeleporter = false;
            targetExit = collision.GetComponent<Teleporter>().exit;
            Destroy(iArrowIndicator);
        } else if (collision.gameObject.layer == LayerMask.NameToLayer("NPC")) {
            dialoguePossible = false;
            Destroy(iArrowIndicator);
        } else if (collision.gameObject.layer == LayerMask.NameToLayer("Pickup")) {
            pickupPossible = false;
            Destroy(iArrowIndicator);
        }
    }
}
