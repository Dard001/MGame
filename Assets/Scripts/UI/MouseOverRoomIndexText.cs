using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverTilesTypeText : MonoBehaviour
{
    //Every frame, this script checks to see which tile is under the mouse and updates the UI
    Text myText;
    MouseController mouseController;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();

        if(myText == null) {
            Debug.LogError("MouseOverTilesTypeText:Start -- No Text UI component on this object");

            //TODO WTF does this do exactly
            this.enabled = false;
        }
        mouseController = GameObject.FindObjectOfType<MouseController>();
        if(mouseController == null) {
            Debug.LogError("MouseOverTilesTypeText:Start -- Where did the mousecontroller go?");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Tile t = mouseController.GetMouseOverTile();

        string roomID = "N/A";

        if (t != null && t.room != null) {
            roomID = t.room.ID.ToString();
        }
        myText.text = "Room Index: " + roomID;
    }
}
