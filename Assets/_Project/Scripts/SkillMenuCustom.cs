using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Adnc.SkillTree.Example.MultiCategory
{
    public class SkillMenuCustom : MonoBehaviour {

        [Tooltip("Specify the Skill Tree")]
        public SkillTreeBase SkillTreePlayer;

        [Header("List All Skills")]
        [Tooltip("The GameObject parent")]
        public Transform SkillsContainer;
        [Tooltip("The GameObject who will be Instantiate in the SkillContainer (parent)")]
        public GameObject SkillsButtonPrefabs;

        void Awake() {
            if (SkillTreePlayer != null)
            {
                CreateSkills();
            }
            else Debug.LogError("We need a Skill Tree");
        }

        public void CreateSkills()
        {
            foreach(SkillCategoryBase category in SkillTreePlayer.GetCategories())
            {
                foreach(SkillCollectionGridItem collection in SkillTreePlayer.GetGrid(category).GetAllCollections())
                {
                    GameObject node = Instantiate(SkillsButtonPrefabs, SkillsContainer);
                }
            }
        }
    }
}
