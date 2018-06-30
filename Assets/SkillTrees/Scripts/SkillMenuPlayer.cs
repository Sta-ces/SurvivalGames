using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillMenuPlayer : SimpleSingleton<SkillMenuPlayer> {
    
    [Header("Skills")]
    [Tooltip("The GameObject parent")]
    public Transform SkillsContainer;
    [Tooltip("The GameObject who will be Instantiate in the SkillContainer (parent)")]
    public GameObject SkillsButtonPrefabs;

    [Header("Descriptions")]
    [Tooltip("Title of the Skill")]
    public Text DescriptionTitle;
    [Tooltip("Description text of the Skill")]
    public Text DescriptionText;

    [Header("Parameters")]
    [Tooltip("Max Number Active Skill [-1 = Infinity]")]
    public int MaxActiveSkill = -1;

    [Header("When is appear on screen")]
    public UnityEvent OnStart;


    public int MaxSkill
    {
        get { return MaxActiveSkill; }
    }
    
    public int SkillActivate
    {
        get {
            int skillActivate = 0;

            foreach (SkillsButtons skill in SkillsContainer.GetComponentsInChildren<SkillsButtons>())
                if (skill.skill.Enable) skillActivate++;

            return skillActivate;
        }
    }


    public void CreateSkills()
    {
        if (SkillsContainer != null && SkillsButtonPrefabs != null)
        {
            Instantiate(SkillsButtonPrefabs, SkillsContainer);
        }
        else
        {
            if (SkillsContainer == null)
                Debug.LogError("We need a Skills Container");
            if (SkillsButtonPrefabs == null)
                Debug.LogError("We need a Skills Button Prefabs");
        }
    }

    public void Description(SkillsButtons _button)
    {
        if (_button.skill.Unlock)
        {
            DescriptionTitle.text = _button.skill.Name;
            DescriptionText.text = _button.skill.Description;
        }
        else
        {
            DescriptionTitle.text = "";
            DescriptionText.text = "";
        }
    }

    public void SetFirstSelected(EventSystem _eventSystem)
    {
        GameObject _object = GetFirstChild(SkillsContainer).gameObject;
        _eventSystem.firstSelectedGameObject = _object;
        _eventSystem.SetSelectedGameObject(_object);
    }

    public void SetInformationChildren()
    {
        foreach(Transform child in SkillsContainer)
        {
            if(child.GetComponent<SkillsButtons>())
                child.GetComponent<SkillsButtons>().Information();
        }
    }

    
    private void OnEnable()
    {
        OnStart.Invoke();
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
