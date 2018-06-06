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

        PlayerPrefs.SetString(ChangeText.DeleteSpace(_nameObject) + "Unlock", _skill.Unlock.ToString().ToLower());
        PlayerPrefs.SetString(ChangeText.DeleteSpace(_nameObject) + "Enable", _skill.Enable.ToString().ToLower());
    }
}
