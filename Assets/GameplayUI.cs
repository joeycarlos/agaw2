using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    private static GameplayUI _instance;

    public static GameplayUI Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("GameplayUI");
                go.AddComponent<GameplayUI>();
            }

            return _instance;
        }
    }

    public Text speakerName;
    public Image speakerPortrait;
    public Text sentenceText;
    public Text itemTitle;
    public Text itemName;
    public Image itemImage;
    public Text goalTitle;
    public Text goal;
    public Text continueText;

    public Sprite basketball;
    public Sprite game;
    public Sprite alarmClock;
    public Sprite food;
    public Sprite drawing;

    void Awake() {
        _instance = this;
    }

    void Start() {
        UpdateHeldItem(0);
    }

    public void UpdateDialogue(string speaker, string sentence) {
        speakerName.text = speaker;
        sentenceText.text = sentence;
    }

    public void EnableDialogue() {
        speakerName.gameObject.SetActive(true);
        speakerPortrait.gameObject.SetActive(true);
        sentenceText.gameObject.SetActive(true);
        continueText.gameObject.SetActive(true);
    }

    public void DisableDialogue() {
        speakerName.gameObject.SetActive(false);
        speakerPortrait.gameObject.SetActive(false);
        sentenceText.gameObject.SetActive(false);
        continueText.gameObject.SetActive(false);
    }

    public void UpdateHeldItem(int itemID) {
        switch (itemID) {
            case 0:
                itemName.text = "";
                itemImage.gameObject.SetActive(false);
                break;
            case 1:
                itemImage.gameObject.SetActive(true);
                itemName.text = "Basketball";
                itemImage.sprite = basketball;
                break;
            case 2:
                itemImage.gameObject.SetActive(true);
                itemName.text = "Video Game";
                itemImage.sprite = game;
                break;
            case 3:
                itemImage.gameObject.SetActive(true);
                itemName.text = "Alarm Clock";
                itemImage.sprite = alarmClock;
                break;
            case 4:
                itemImage.gameObject.SetActive(true);
                itemName.text = "Drawing";
                itemImage.sprite = drawing;
                break;
            case 5:
                itemImage.gameObject.SetActive(true);
                itemName.text = "Food";
                itemImage.sprite = food;
                break;
        }
    }
}
