using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverRoomDetails : MonoBehaviour {
    //Every frame, this script checks to see which tile is under the mouse and updates the UI
    Text myText;
    MouseController mouseController;

    // Start is called before the first frame update
    void Start() {
        myText = GetComponent<Text>();

        if (myText == null) {
            Debug.LogError("MouseOverTilesTypeText:Start -- No Text UI component on this object");

            //TODO WTF does this do exactly
            this.enabled = false;
        }
        mouseController = GameObject.FindObjectOfType<MouseController>();
        if (mouseController == null) {
            Debug.LogError("MouseOverTilesTypeText:Start -- Where did the mousecontroller go?");
            return;
        }
    }

    // Update is called once per frame
    void Update() {
        Tile t = mouseController.GetMouseOverTile();

        if (t == null || t.room == null) {
            myText.text = "";
            return;
        }

        string s = "";

        foreach (string g in t.room.GetGasNames()) {
            s += g + ": " + t.room.GetGasAmount(g) + " (" + (t.room.GetGasPercentage(g)*100) + "% ";
        }

        myText.text = s;
    }
}
