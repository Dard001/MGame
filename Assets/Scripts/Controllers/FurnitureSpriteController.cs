//=======================================================================
// Copyright Martin "quill18" Glaude 2015.
//		http://quill18.com
//=======================================================================

using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class FurnitureSpriteController : MonoBehaviour {

    Dictionary<Furniture, GameObject> furnitureGameObjectMap;

    Dictionary<string, Sprite> furnitureSprites;

    World world {
        get { return WorldController.Instance.world; }
    }

    // Use this for initialization
    void Start() {
        LoadSprites();

        // Instantiate our dictionary that tracks which GameObject is rendering which Tile data.
        furnitureGameObjectMap = new Dictionary<Furniture, GameObject>();

        // Register our callback so that our GameObject gets updated whenever
        // the tile's type changes.
        world.RegisterFurnitureCreated(OnFurnitureCreated);

        // Go through any EXISTING furniture (i.e. from a save that was loaded OnEnable) and call the OnCreated event manually
        foreach (Furniture furn in world.furnitures) {
            OnFurnitureCreated(furn);
        }
    }

    void LoadSprites() {
        furnitureSprites = new Dictionary<string, Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Images/Furniture/");

        //Debug.Log("LOADED RESOURCE:");
        foreach (Sprite s in sprites) {
           //Debug.Log("furnitureSprites: " + s);
            furnitureSprites[s.name] = s;
        }
    }

    public void OnFurnitureCreated(Furniture furn) {
        //Debug.Log("OnFurnitureCreated");
        // Create a visual GameObject linked to this data.

        // FIXME: Does not consider multi-tile objects nor rotated objects

        // This creates a new GameObject and adds it to our scene.
        GameObject furn_go = new GameObject();

        // Add our tile/GO pair to the dictionary.
        furnitureGameObjectMap.Add(furn, furn_go);

        furn_go.name = furn.objectName + "_" + furn.tile.X + "_" + furn.tile.Y;
        furn_go.transform.position = new Vector3(furn.tile.X + ((furn.Width - 1) / 2f), furn.tile.Y + ((furn.Height - 1) / 2f), 0);
        furn_go.transform.SetParent(this.transform, true);

        // FIXME: This hardcoding is not ideal!
        if (furn.objectName == "Door") {
            // By default, the door graphic is meant for walls to the east & west
            // Check to see if we actually have a wall north/south, and if so
            // then rotate this GO by 90 degrees

            Tile northTile = world.GetTileAt(furn.tile.X, furn.tile.Y + 1);
            Tile southTile = world.GetTileAt(furn.tile.X, furn.tile.Y - 1);

            if (northTile != null && southTile != null && northTile.furniture != null && southTile.furniture != null &&
                northTile.furniture.Type == "Wall" && southTile.furniture.Type == "Wall") {
                furn_go.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }



        SpriteRenderer sr = furn_go.AddComponent<SpriteRenderer>();
        sr.sprite = GetSpriteForFurniture(furn);
        sr.sortingLayerName = "Furniture";
        sr.color = furn.tint;

        // Register our callback so that our GameObject gets updated whenever
        // the object's into changes.
        furn.RegisterOnChangedCallback(OnFurnitureChanged);
        furn.RegisterOnRemovedCallback(OnFurnitureRemoved);

    }

    void OnFurnitureRemoved(Furniture furn) {
        if (furnitureGameObjectMap.ContainsKey(furn) == false) {
            Debug.LogError("OnFurnitureRemoved -- trying to change visuals for furniture not in our map.");
            return;
        }

        GameObject furn_go = furnitureGameObjectMap[furn];
        Destroy(furn_go);
        furnitureGameObjectMap.Remove(furn);
    }

    void OnFurnitureChanged(Furniture furn) {
        //Debug.Log("OnFurnitureChanged");
        // Make sure the furniture's graphics are correct.

        if (furnitureGameObjectMap.ContainsKey(furn) == false) {
            Debug.LogError("OnFurnitureChanged -- trying to change visuals for furniture not in our map.");
            return;
        }

        GameObject furn_go = furnitureGameObjectMap[furn];
        //Debug.Log(furn_go);
        //Debug.Log(furn_go.GetComponent<SpriteRenderer>());

        furn_go.GetComponent<SpriteRenderer>().sprite = GetSpriteForFurniture(furn);
        furn_go.GetComponent<SpriteRenderer>().color = furn.tint;

    }




    public Sprite GetSpriteForFurniture(Furniture furn) {
        string spriteName = furn.objectName + "_";

        int x = furn.tile.X;
        int y = furn.tile.Y;

        Tile tile;

        bool N = false;
        bool E = false;
        bool S = false;
        bool W = false;

        if (furn.linksToNeighbour == false) {
            return furnitureSprites[furn.objectName];
        }
        if (furn.Type == "Door") {

            tile = world.GetTileAt(x, y - 1);
            if (tile != null && tile.furniture != null && tile.furniture.Type == "Wall") {
                N = true;
            }
            tile = world.GetTileAt(x, y + 1);
            if (tile != null && tile.furniture != null && tile.furniture.Type == "Wall") {
                S = true;
            }

            if (N && S) {
                spriteName += "NS";
            } else {
                spriteName += "EW";
            }


            // If this is a DOOR, let's check OPENNESS and update the sprite.
            // FIXME: All this hardcoding needs to be generalized later.
            if (furn.GetParameter("openness") < 0.1f) {
                // Door is closed
                spriteName += "_0";
            } else if (furn.GetParameter("openness") < 0.2f) {
                // Door is a bit open
                spriteName += "_1";
            } else if (furn.GetParameter("openness") < 0.3f) {
                // Door is a lot open
                spriteName += "_2";
            } else if (furn.GetParameter("openness") < 0.4f) {
                // Door is a lot open
                spriteName += "_3";
            } else if (furn.GetParameter("openness") < 0.5f) {
                // Door is a lot open
                spriteName += "_4";
            } else if (furn.GetParameter("openness") < 0.6f) {
                // Door is a lot open
                spriteName += "_5";
            } else if (furn.GetParameter("openness") < 0.7f) {
                // Door is a lot open
                spriteName += "_6";
            } else if (furn.GetParameter("openness") < 0.8f) {
                // Door is a lot open
                spriteName += "_7";
            } else if (furn.GetParameter("openness") < 0.9f) {
                // Door is a lot open
                spriteName += "_8";
            } else {
                // Door is a fully open
                spriteName = "Door_EW_8";
            }
            Debug.Log("--------------calling---------- " + spriteName);

            return furnitureSprites[spriteName];
        }

        

        // Check for neighbours North, East, South, West

        tile = world.GetTileAt(furn.tile.X, furn.tile.Y + 1);
        if (tile != null && tile.furniture != null && tile.furniture.objectName == furn.objectName) {
            N = true;
            spriteName += "N";
        }

        tile = world.GetTileAt(furn.tile.X + 1, furn.tile.Y);
        if (tile != null && tile.furniture != null && tile.furniture.objectName == furn.objectName) {
            E = true;
            spriteName += "E";
        }

        tile = world.GetTileAt(furn.tile.X, furn.tile.Y - 1);
        if (tile != null && tile.furniture != null && tile.furniture.objectName == furn.objectName) {
            S = true;
            spriteName += "S";
        }

        tile = world.GetTileAt(furn.tile.X - 1, furn.tile.Y);
        if (tile != null && tile.furniture != null && tile.furniture.objectName == furn.objectName) {
            W = true;
            spriteName += "W";
        }
        if (furn.Type == "Wall") {
            tile = world.GetTileAt(furn.tile.X + 1, furn.tile.Y + 1);
            if (N && E && tile != null && tile.furniture != null && tile.furniture.objectName == furn.objectName) {
                spriteName += "M";
            }

            tile = world.GetTileAt(furn.tile.X + 1, furn.tile.Y - 1);
            if (E && S && tile != null && tile.furniture != null && tile.furniture.objectName == furn.objectName) {
                spriteName += "R";
            }

            tile = world.GetTileAt(furn.tile.X - 1, furn.tile.Y - 1);
            if (S && W && tile != null && tile.furniture != null && tile.furniture.objectName == furn.objectName) {
                spriteName += "D";
            }

            tile = world.GetTileAt(furn.tile.X - 1, furn.tile.Y + 1);
            if (W && N && tile != null && tile.furniture != null && tile.furniture.objectName == furn.objectName) {
                spriteName += "T";
            }
        }
        // For example, if this object has all four neighbours of
        // the same type, then the string will look like:
        //       Wall_NESW

        Debug.Log("----------------Placing: " + spriteName);

        if (furnitureSprites.ContainsKey(spriteName) == false) {
            Debug.LogError("GetSpriteForInstalledObject -- No sprites with name: " + spriteName);
            return null;
        }


        return furnitureSprites[spriteName];

    }


    public Sprite GetSpriteForFurniture(string objectName) {
        if (furnitureSprites.ContainsKey(objectName)) {
            return furnitureSprites[objectName];
        }

        if (furnitureSprites.ContainsKey(objectName + "_")) {
            return furnitureSprites[objectName + "_"];
        }

        if(objectName == "Door"){
            return furnitureSprites["Door_EW_0"];
        }

        Debug.LogError("GetSpriteForFurniture -- No sprites with name: " + objectName);
        return null;
    }
}



/*
    Dictionary<Furniture, GameObject> furnitureGameObjectMap;

    Dictionary<string, Sprite> furnitureSprites;

    World world {
        get { return WorldController.Instance.world; }
    }

    void Start() {
        LoadSprites();

        // Instantiate our dictionary that tracks which GameObject is rendering which Tile data.
        furnitureGameObjectMap = new Dictionary<Furniture, GameObject>();

        // Register our callback so that our GameObject gets updated whenever
        // the tile's type changes.
        world.RegisterFurnitureCreated(OnFurnitureCreated);

        // Go through any EXISTING furniture (i.e. from a save that was loaded OnEnable) and call the OnCreated event manually
        foreach (Furniture furn in world.furnitures) {
            OnFurnitureCreated(furn);
        }
    }

    void LoadSprites() {
        furnitureSprites = new Dictionary<string, Sprite>();
        Sprite[] wallSprites = Resources.LoadAll<Sprite>(Gameplay.wallSpritesPath);
        Sprite[] objectSprites = Resources.LoadAll<Sprite>(Gameplay.objectSpritesPath);

        foreach (Sprite s in wallSprites) {
            furnitureSprites[s.name] = s;
        }
        foreach (Sprite s in objectSprites) {
            furnitureSprites[s.name] = s;
        }
    }

    //this is actually a callback
    public void OnFurnitureCreated(Furniture furn) {
        //Create a visual GameObject linked to this data
        GameObject furn_go = new GameObject();

        furnitureGameObjectMap.Add(furn, furn_go);

        furn_go.name = furn.objectType + "_" + furn.tile.X + "_" + furn.tile.Y;
        furn_go.transform.position = new Vector3(furn.tile.X + ((furn.Width - 1)/2f), furn.tile.Y + ((furn.Height - 1)/2f), 0);
        furn_go.transform.SetParent(this.transform, true);

        //Need to muck about with the code for this type of thing.
        /*
        if (furn.objectType == "slidingDoor") {
            Tile northTile = world.GetTileAt(furn.tile.X, furn.tile.Y + 1);
            Tile southTile = world.GetTileAt(furn.tile.X, furn.tile.Y - 1);

            if (northTile != null && southTile != null && northTile.furniture != null && southTile.furniture != null && northTile.furniture.objectType == "concreteWall" && southTile.furniture.objectType == "concreteWall") {
                furn_go.transform.rotation = Quaternion.Euler(0, 0, 90);
                furn_go.transform.Translate(1f, 0 ,0, Space.World);
            }
        }
        */

/*
    //must be a wall with this implementation
    SpriteRenderer sr = furn_go.AddComponent<SpriteRenderer>(); 
    sr.sprite = GetSpriteForFurniture(furn); //TODO fix this
    sr.sortingLayerName = "Furniture";
    sr.color = furn.tint;

    //Register our callback so that GameObject gets updated whenever objects's info changes
    furn.RegisterOnChangedCallback(OnFurnitureChanged);
    furn.RegisterOnRemovedCallback(OnFurnitureRemoved);
}

void OnFurnitureRemoved(Furniture furn) {
    if (furnitureGameObjectMap.ContainsKey(furn) == false) {
        Debug.LogError("FurnitureSpriteController:OnFurnitureChanged trying to change visuals furniture not in our map");
        return;
    }

    GameObject furn_go = furnitureGameObjectMap[furn];
    Destroy(furn_go);
    furnitureGameObjectMap.Remove(furn);
}

public void OnFurnitureChanged(Furniture furn) {
    if (furnitureGameObjectMap.ContainsKey(furn) == false) {
        Debug.LogError("FurnitureSpriteController:OnFurnitureChanged trying to change visuals furniture not in our map");
        return;
    }

    GameObject furn_go = furnitureGameObjectMap[furn];
    furn_go.GetComponent<SpriteRenderer>().sprite = GetSpriteForFurniture(furn); //TODO fix this
    //furn_go.GetComponent<SpriteRenderer>().sortingLayerName = "Furniture";
    furn_go.GetComponent<SpriteRenderer>().color = furn.tint;

}

public Sprite GetSpriteForFurniture(Furniture furn) {

    string spriteName = furn.objectType + "_";
    bool N = false;
    bool E = false;
    bool S = false;
    bool W = false;

    if (furn.linksToNeighbor == false) {
        return furnitureSprites[furn.objectType];
    }

    Tile tile;



    //TODO fix this hardcoded shit

    if (furn.objectType == "slidingDoor") {

        tile = world.GetTileAt(furn.tile.X, furn.tile.Y + 1);
        if (tile != null && tile.furniture != null && tile.furniture.objectType == "concreteWall") {
            N = true;
        }

        tile = world.GetTileAt(furn.tile.X, furn.tile.Y - 1);
        if (N == true && tile != null && tile.furniture != null && tile.furniture.objectType == "concreteWall") {
            S = true;
            spriteName += "NS";
        } else {
            spriteName += "EW";
        }



        if (furn.GetParameter("openness") < 0.1f) {
            //Door is closed
            spriteName += "_0";
        } else if (furn.GetParameter("openness") < 0.125f) {
            spriteName += "_1";
        } else if (furn.GetParameter("openness") < 0.25f) {
            spriteName += "_2";
        } else if (furn.GetParameter("openness") < 0.375f) {
            spriteName += "_3";
        } else if (furn.GetParameter("openness") < 0.4f) {
            spriteName += "_4";
        } else if (furn.GetParameter("openness") < 0.525f) {
            spriteName += "_5";
        } else if (furn.GetParameter("openness") < 0.65f) {
            spriteName += "_6";
        } else if (furn.GetParameter("openness") < 0.775) {
            spriteName += "_7";
        } else {
            spriteName += "_8";
        }

        return furnitureSprites[spriteName];
    }


    tile = world.GetTileAt(furn.tile.X, furn.tile.Y + 1);
    if (tile != null && tile.furniture != null && tile.furniture.objectType == furn.objectType) {
        N = true;
        spriteName += "N";
    }

    tile = world.GetTileAt(furn.tile.X + 1, furn.tile.Y);
    if (tile != null && tile.furniture != null && tile.furniture.objectType == furn.objectType) {
        E = true;
        spriteName += "E";
    }

    tile = world.GetTileAt(furn.tile.X, furn.tile.Y - 1);
    if (tile != null && tile.furniture != null && tile.furniture.objectType == furn.objectType) {
        S = true;
        spriteName += "S";
    }

    tile = world.GetTileAt(furn.tile.X - 1, furn.tile.Y);
    if (tile != null && tile.furniture != null && tile.furniture.objectType == furn.objectType) {
        W = true;
        spriteName += "W";
    }
    if (furn.objectType == "concreteWall") {
        tile = world.GetTileAt(furn.tile.X + 1, furn.tile.Y + 1);
        if (N && E && tile != null && tile.furniture != null && tile.furniture.objectType == furn.objectType) {
            spriteName += "M";
        }

        tile = world.GetTileAt(furn.tile.X + 1, furn.tile.Y - 1);
        if (E && S && tile != null && tile.furniture != null && tile.furniture.objectType == furn.objectType) {
            spriteName += "R";
        }

        tile = world.GetTileAt(furn.tile.X - 1, furn.tile.Y - 1);
        if (S && W && tile != null && tile.furniture != null && tile.furniture.objectType == furn.objectType) {
            spriteName += "D";
        }

        tile = world.GetTileAt(furn.tile.X - 1, furn.tile.Y + 1);
        if (W && N && tile != null && tile.furniture != null && tile.furniture.objectType == furn.objectType) {
            spriteName += "T";
        }
    }

    if (furnitureSprites.ContainsKey(spriteName) == false) {
        Debug.LogError("SpriteController:No sprites with name: " + spriteName);
        return null;
    }

    return furnitureSprites[spriteName];
}

public Sprite GetSpriteForFurniture(string objectType) {
    if (furnitureSprites.ContainsKey(objectType) != false) {

        return furnitureSprites[objectType];
    }

    /////////////////////////////////////////////////////////////////////////////////////BUG HERE FOR DOORS, NOT SHOWING UP AS A JOB GHOST

    if(furnitureSprites.ContainsKey(objectType + "_")) {
        return furnitureSprites[objectType + "_"];
    }

    Debug.LogError("FurnitureSpriteController:GetSpriteForFurniture -- No sprites with name: " + objectType);
    return null;
}
*/
