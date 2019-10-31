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

    void Awake() {
        _instance = this;
    }

    public void UpdateDialogue(string speaker, string sentence) {
        speakerName.text = speaker;
        sentenceText.text = sentence;
    }
}
