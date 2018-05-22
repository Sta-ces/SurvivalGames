using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Adnc.SkillTree
{
    [CustomEditor(typeof(SkillTree), true)]
    public class CustomSkillTreeEditor : Editor
    {
        EditorWindow window;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            SkillTree _skill = target as SkillTree;

            // Call your custom function here
            // Exemple : _skill.YourFunctionName();
            _skill.SkillPoints();
        }
    }
}
