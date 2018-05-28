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
        public Behaviour Script;
    }
    public Skill[] skill;
}
