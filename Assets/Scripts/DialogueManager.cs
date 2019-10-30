using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;

    public static DialogueManager Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("DialogueManager");
                go.AddComponent<DialogueManager>();
            }

            return _instance;
        }
    }

    private Queue<string> sentences;
    private Queue<string> speakers;
    private GameObject player;

    void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        speakers = new Queue<string>();
        sentences = new Queue<string>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartDialogue(Dialogue dialogue) {
        Debug.Log("Starting conversation with " + dialogue.name);
        speakers.Clear();
        sentences.Clear();

        foreach (string speaker in dialogue.speakers) {
            speakers.Enqueue(speaker);
        }

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string speaker = speakers.Dequeue();
        string sentence = sentences.Dequeue();
        Debug.Log(speaker + ": " + sentence);
    }

    void EndDialogue() {
        Debug.Log("End conversation");
        player.GetComponent<PlayerController>().dialogueInProgress = false;
    }
}
