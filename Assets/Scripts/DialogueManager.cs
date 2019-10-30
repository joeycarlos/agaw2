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

    void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        Debug.Log("Able to start conversation with " + dialogue.name);
        sentences.Clear();

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

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    void EndDialogue() {
        Debug.Log("End conversation");
    }
}
