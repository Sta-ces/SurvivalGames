using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillMenuPlayer : MonoBehaviour {
    
    [Header("Skills")]
    [Tooltip("The GameObject parent")]
    public Transform SkillsContainer;
    [Tooltip("The GameObject who will be Instantiate in the SkillContainer (parent)")]
    public GameObject SkillsButtonPrefabs;

    [Header("When is created")]
    public UnityEvent IsCreated;


    public void CreateSkills()
    {
        if (SkillsContainer != null && SkillsButtonPrefabs != null)
        {
            Instantiate(SkillsButtonPrefabs, SkillsContainer);
            /*if (SkillsContainer.transform.childCount > 0)
                DestroyAllChildren(SkillsContainer.transform);*/

            /*for(int _skill = 0; _skill < PlayerSkillTree.GetSkills.Length; _skill++)
            {
                GameObject node = Instantiate(SkillsButtonPrefabs, SkillsContainer);
                node.GetComponent<SkillsButtons>().SkillID = _skill;
                node.GetComponent<SkillsButtons>().Information();
            }*/

            //IsCreated.Invoke();
        }
        else
        {
            if (SkillsContainer == null)
                Debug.LogError("We need a Skills Container");
            if (SkillsButtonPrefabs == null)
                Debug.LogError("We need a Skills Button Prefabs");
        }
    }

    public void SetFirstSelected(EventSystem _eventSystem)
    {
        GameObject _object = GetFirstChild(SkillsContainer).gameObject;
        _eventSystem.firstSelectedGameObject = _object;
        _eventSystem.SetSelectedGameObject(_object);
    }

    private void DestroyAllChildren(Transform _parent)
    {
        print("Destroy Children of " + _parent.name);
        while (_parent.childCount != 0)
        {
            DestroyImmediate(_parent.GetChild(0).gameObject);
        }
    }

    private Transform GetFirstChild(Transform _parent)
    {
        return _parent.GetChild(0);
    }
}
