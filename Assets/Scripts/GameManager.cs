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

    public int itemsGiven;
    public int heldItem;

    void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        heldItem = 0;
        itemsGiven = 0;
    }

    void GiveItem() {
        heldItem = 0;
        itemsGiven++;
    }
}
