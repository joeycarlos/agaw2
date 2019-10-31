using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public int npcID;

    public Dialogue dialogue;

    /*
    public void TriggerDialogue() {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            DialogueManager.Instance.StartDialogue(dialogue);
    }
    */
}
