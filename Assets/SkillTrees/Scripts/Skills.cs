using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Skills : SimpleSingleton<Skills> {

    [Serializable]
    public struct Skill
    {
        public bool Unlock;
        public string Name;
        [TextArea]
        public string Description;
        public int RequiredLevel;
        public bool AlwaysEnable;
        public bool Enable;
    }
    public Skill skill;

    public virtual void EffectSkill() { }
    
    public void SaveInformation(Skill _skill, string _nameObject)
    {
        string _name = _nameObject.Replace(" ", "");
        _name = _name.Trim();

        PlayerPrefs.SetString(_name + "Unlock", _skill.Unlock.ToString().ToLower());
        PlayerPrefs.SetString(_name + "Enable", _skill.Enable.ToString().ToLower());
    }
}
