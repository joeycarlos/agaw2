using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool mainGameplayHasEnded = false;
    public bool lastConversationPending = false;

    public GameObject[] pickups;

    void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        heldItem = 0;
        itemsGiven = 0;
        DialogueManager.Instance.LoadAdrianDialogue(6);
        GameplayUI.Instance.DisableGoal();
    }

    public void GiveItem() {
        heldItem = 0;
        GameplayUI.Instance.UpdateHeldItem(0);
        itemsGiven++;
    }

    public void UpdateAdrian(int itemID) {
        DialogueManager.Instance.LoadAdrianDialogue(itemID);
    }

    public void GoToAdriansRoom() {
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.Teleport(adriansRoomEntrance);
        lastConversationPending = true;
    }

    public void WinGame() {
        // load win game screen
        Debug.Log("YOU WIN. LOADING WIN SCREEN!");
        SceneManager.LoadScene(1);
    }

    public void EnablePickups() {
        foreach (GameObject pickup in pickups) {
            if (pickup != null)
                pickup.SetActive(true);
        }
    }
}
