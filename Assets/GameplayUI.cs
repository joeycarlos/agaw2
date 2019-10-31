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

    void Awake() {
        _instance = this;
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
}
