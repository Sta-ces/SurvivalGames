﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Adnc.SkillTree {
	[AddComponentMenu("")]
	public class SkillCategory : SkillCategoryBase {
        public int SkillLevels()
        {
            return skillLv = Score.Instance.GetHighscore;
        }
    }
}
