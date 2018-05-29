using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FollowObject))]
public class Editor_FollowObject : Editor {

	public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FollowObject scriptTarget = target as FollowObject;

        // Call your custom function here
        // Exemple : scriptTarget.YourFunctionName();
        scriptTarget.Follow();
    }
}
