using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public GameObject adriansRoomEntrance;

    public int itemsGiven;
    public int heldItem;

    void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        heldItem = 0;
        itemsGiven = 0;
        DialogueManager.Instance.LoadAdrianDialogue(6);
    }

    public void GiveItem() {
        heldItem = 0;
        itemsGiven++;
        if (itemsGiven == 5) {
            InitiateEndingSequence();
        }
    }

    public void UpdateAdrian(int itemID) {
        DialogueManager.Instance.LoadAdrianDialogue(itemID);
    }

    void InitiateEndingSequence() {
        Debug.Log("All items have been given");
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.Teleport(adriansRoomEntrance);
    }
}
