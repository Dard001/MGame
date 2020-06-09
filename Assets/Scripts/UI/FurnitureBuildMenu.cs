using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class FurnitureBuildMenu : MonoBehaviour
{

    public GameObject buildFurnitureButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        BuildModeController bmc = GameObject.FindObjectOfType<BuildModeController>();

        //Add a button for building each type of furniture
       foreach (string s in World.current.furniturePrototypes.Keys) {
            GameObject go = (GameObject)Instantiate(buildFurnitureButtonPrefab);
            go.transform.SetParent(this.transform);

            string objectId = s;
            string objectName = World.current.furniturePrototypes[s].Type;

            go.name = "Button - " + s;
            go.transform.GetComponentInChildren<Text>().text = "Build " + objectName;

            UnityEngine.UI.Button b = go.GetComponent<UnityEngine.UI.Button>();

            

            b.onClick.AddListener(delegate { bmc.SetMode_BuildFurniture(s); });
        }
    }
}
