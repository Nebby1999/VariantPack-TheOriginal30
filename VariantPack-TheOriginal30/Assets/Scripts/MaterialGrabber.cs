using BepInEx.Configuration;
using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VarianceAPI.Modules;
using VarianceAPI.Scriptables;

namespace TheOriginal30
{
    public class MaterialGrabber : VariantMaterialGrabber
    {
        internal static ItemDisplayRuleSet IDRS;
        public static VariantMaterialReplacement perforatorMaterial;
        public static VariantMaterialReplacement glandMaterial;

        public static List<VariantMaterialReplacement> variantMaterialReplacements;


        public void Init()
        {
            variantMaterialReplacements = GrabMaterials();
            GrabIncompleteMaterialReplacements(MainClass.theOriginal30Assets);
            FixMaterials(variantMaterialReplacements);
        }
        public static List<VariantMaterialReplacement> GrabMaterials()
        {
            IDRS = Resources.Load<GameObject>("Prefabs/CharacterBodies/CommandoBody").GetComponent<ModelLocator>().modelTransform.GetComponent<CharacterModel>().itemDisplayRuleSet;
            var listToReturn = new List<VariantMaterialReplacement>();

            var perforatorMat = UnityEngine.Object.Instantiate(IDRS.FindDisplayRuleGroup(RoR2Content.Items.FireballsOnHit).rules[0].followerPrefab.GetComponentInChildren<MeshRenderer>().material);
            perforatorMaterial = ScriptableObject.CreateInstance<VariantMaterialReplacement>();
            perforatorMaterial.material = perforatorMat;
            perforatorMaterial.varName = "perforatorMaterial";
            Debug.Log("Adding " + perforatorMaterial.varName + "to listToReturn");
            listToReturn.Add(perforatorMaterial);

            glandMaterial = ScriptableObject.CreateInstance<VariantMaterialReplacement>();
            glandMaterial.material = UnityEngine.Object.Instantiate(IDRS.FindDisplayRuleGroup(RoR2Content.Items.BeetleGland).rules[0].followerPrefab.GetComponentInChildren<Renderer>().material);
            glandMaterial.varName = "glandMaterial";
            Debug.Log("Adding " + glandMaterial.varName + "to listToReturn");
            listToReturn.Add(glandMaterial);

            Debug.Log("Returning list...");
            return listToReturn;
        }
    }
}