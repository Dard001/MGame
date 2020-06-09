﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//TODO WTF is this?
[CustomEditor(typeof (AutomaticVerticalSize))]
public class AutomaticVerticalSizeEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

       if( GUILayout.Button("Recalc Size")) {
            AutomaticVerticalSize myScript = ((AutomaticVerticalSize)target);
            myScript.AdjustSize();
        }
    }
}
