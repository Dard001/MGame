using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapSizes {
    TEST, XSMALL, SMALL, MEDIUM, LARGE, XLARGE
}

public static class Gameplay
{
    public static bool DEBUG_ON = false;

    public static MapSizes Current_MapSize = MapSizes.TEST;

    public static int MAPSIZE_TEST_X = 15;
    public static int MAPSIZE_TEST_Y = 15;

    public static int MAPSIZE_XSMALL_X = 100;
    public static int MAPSIZE_XSMALL_Y = 100;

    public static int MAPSIZE_SMALL_X = 250;
    public static int MAPSIZE_SMALL_Y = 250;

    public static int MAPSIZE_MEDIUM_X = 500;
    public static int MAPSIZE_MEDIUM_Y = 500;

    public static int MAPSIZE_LARGE_X = 750;
    public static int MAPSIZE_LARGE_Y = 750;

    public static int MAPSIZE_XLARGE_X = 1000;
    public static int MAPSIZE_XLARGE_Y = 1000;

    public static string characterSpritesPath = "Images/Characters/";
    public static string inventorySpritesPath = "Images/Inventory/";
    public static string objectSpritesPath = "Tiles/Objects/";
    public static string floorSpritesPath = "Tiles/Floors/";
    public static string wallSpritesPath = "Tiles/Walls/";

    public static string furnitureDataFile = "Data/Furniture";

    public static int getMapSizeX(MapSizes size) {
        switch (size) {
            case MapSizes.TEST:
                return MAPSIZE_TEST_X;
            case MapSizes.XSMALL:
                return MAPSIZE_XSMALL_X;
            case MapSizes.SMALL:
                return MAPSIZE_SMALL_X;
            case MapSizes.MEDIUM:
                return MAPSIZE_MEDIUM_X;
            case MapSizes.LARGE:
                return MAPSIZE_LARGE_X;
            case MapSizes.XLARGE:
                return MAPSIZE_XLARGE_X;
            default:
                return MAPSIZE_TEST_X;
        }
    }

    public static int getMapSizeY(MapSizes size) {
        switch (size) {
            case MapSizes.TEST:
                return MAPSIZE_TEST_Y;
            case MapSizes.XSMALL:
                return MAPSIZE_XSMALL_Y;
            case MapSizes.SMALL:
                return MAPSIZE_SMALL_Y;
            case MapSizes.MEDIUM:
                return MAPSIZE_MEDIUM_Y;
            case MapSizes.LARGE:
                return MAPSIZE_LARGE_Y;
            case MapSizes.XLARGE:
                return MAPSIZE_XLARGE_Y;
            default:
                return MAPSIZE_TEST_Y;
        }
    }
}

//TODO LIST
/*
 * Job range overlay (change tint to show range of object, make it dynamic, take an int for range and color based on int)
 * 
 * Assign names to characters
 * 
 * XML script all the things
 * 
 * Item decay and maintenance
 * 
 * Character health, stamina, heat, thirst, hunger, happiness
 * 
 * Character skills, diseases, factions, friends, enemies
 * 
 * Prioritized job queues
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */