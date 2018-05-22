using UnityEngine;
using System;
using System.Collections;

namespace Adnc.SkillTree {
	public class Skill : SkillBase {

        [Header("Custom")]
        [Header("Enable / Disable")]
        [Tooltip("Enable the capacity or not")]
        [SerializeField]
        protected bool enable = false;
        public bool EnableSkill
        {
            get { return enable; }
            set { enable = value; }
        }
        
        public bool SetEnable(bool _enable)
        {
            return EnableSkill = _enable;
        }

	}
}
