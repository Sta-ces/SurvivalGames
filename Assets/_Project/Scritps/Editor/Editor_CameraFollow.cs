﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class Editor_CameraFollow : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CameraFollow cam = target as CameraFollow;
        cam.PositionCamera();
    }
}
