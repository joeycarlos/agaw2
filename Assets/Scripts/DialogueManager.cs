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

    public GameObject adrian;

    public Dialogue adrianIntroDialogue;
    public Dialogue noItemDialogue;
    public Dialogue basketballDialogue;
    public Dialogue gameDialogue;
    public Dialogue clockDialogue;
    public Dialogue drawingDialogue;
    public Dialogue foodDialogue;

    public Dialogue introDialogue;

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
        if (player.GetComponent<PlayerController>().targetNPC == 0) {
            LoadAdrianDialogue(0);
        }
        if (player.GetComponent<PlayerController>().targetNPC == 0 && GameManager.Instance.heldItem != 0) {
            Debug.Log("Giving Adrian item: " + GameManager.Instance.heldItem);
            GameManager.Instance.GiveItem();
        }
        player.GetComponent<PlayerController>().dialoguePossible = false;
    }

    public void LoadAdrianDialogue(int itemID) {
        switch (itemID) {
            case 0:
                adrian.GetComponent<DialogueTrigger>().dialogue = noItemDialogue;
                break;
            case 1:
                adrian.GetComponent<DialogueTrigger>().dialogue = basketballDialogue;
                break;
            case 2:
                adrian.GetComponent<DialogueTrigger>().dialogue = gameDialogue;
                break;
            case 3:
                adrian.GetComponent<DialogueTrigger>().dialogue = clockDialogue;
                break;
            case 4:
                adrian.GetComponent<DialogueTrigger>().dialogue = drawingDialogue;
                break;
            case 5:
                adrian.GetComponent<DialogueTrigger>().dialogue = foodDialogue;
                break;
            case 6:
                adrian.GetComponent<DialogueTrigger>().dialogue = adrianIntroDialogue;
                break;

        }
        
    }
}
