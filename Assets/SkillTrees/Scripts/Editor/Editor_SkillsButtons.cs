using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using System.Collections;

[CustomEditor(typeof(SkillsButtons))]
public class Editor_SkillsButtons : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SkillsButtons scriptTarget = target as SkillsButtons;

        // Call your custom function here
        // Exemple : scriptTarget.YourFunctionName();

        Skills.Skill scriptSkill = scriptTarget.skill;

        scriptTarget.Information();

        if (scriptSkill.Name != "")
        {
            scriptTarget.name = scriptSkill.Name.Replace(" ","");
        }
        else scriptTarget.name = "Button_Skill";

        if(GUILayout.Button("Create Script"))
            CreateScript(scriptTarget);
    }

    private void CreateScript(SkillsButtons _script)
    {
        // Get the Path
        MonoScript ms = MonoScript.FromMonoBehaviour(_script);
        string scriptFilePath = AssetDatabase.GetAssetPath(ms);
        FileInfo fi = new FileInfo(scriptFilePath);
        string scriptFolder = fi.Directory.ToString();
        scriptFolder.Replace('\\', '/');

        GameObject selected = _script.gameObject;

        if (selected == null || selected.name.Length <= 0)
        {
            Debug.Log("Selected object not Valid");
            return;
        }

        // remove whitespace and minus
        string name = selected.name.Replace(" ", "");
        name = name.Replace("-", "_");
        string copyPath = scriptFolder + "/SkillEffects/" + name + ".cs";
        if (File.Exists(copyPath) == false)
        { // do not overwrite
            Debug.Log("Creating Classfile: " + copyPath);
            using (StreamWriter outfile =
                new StreamWriter(copyPath))
            {
                outfile.WriteLine("using System;");
                outfile.WriteLine("using System.Collections;");
                outfile.WriteLine("using System.Collections.Generic;");
                outfile.WriteLine("using UnityEngine;");
                outfile.WriteLine("using UnityEngine.Events;");
                outfile.WriteLine("");
                outfile.WriteLine("public class " + name + " : MonoBehaviour");
                outfile.WriteLine("{");
                outfile.WriteLine("");
                outfile.WriteLine(" public SkillsButtons SkillScript;");
                outfile.WriteLine("");
                outfile.WriteLine(" [Header('Activate')]");
                outfile.WriteLine(" public UnityEvent OnActivate;");
                outfile.WriteLine("");
                outfile.WriteLine(" void Start()");
                outfile.WriteLine(" {");
                outfile.WriteLine("     ");
                outfile.WriteLine(" }");
                outfile.WriteLine("");
                outfile.WriteLine("");
                outfile.WriteLine(" void Update()");
                outfile.WriteLine(" {");
                outfile.WriteLine("     ");
                outfile.WriteLine(" }");
                outfile.WriteLine("}");
            }//File written
        }
        else Debug.Log("File Exist");

        /*AssetDatabase.Refresh();
        Type myType = GetAssemblyType(name);
        if (!selected.GetComponent(myType))
            selected.AddComponent(myType);
        else Debug.Log("Have already the component");*/
    }

    public static Type GetAssemblyType(string typeName)
    {
        Type type = Type.GetType(typeName);
        if (type != null) return type;
        foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
        {
            type = a.GetType(typeName);
            if (type != null) return type;
        }
        return null;
    }
}
