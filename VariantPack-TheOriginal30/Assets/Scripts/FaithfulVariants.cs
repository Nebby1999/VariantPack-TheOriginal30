using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VarianceAPI.Scriptables;

namespace TheOriginal30
{
    public class FaithfulVariants
    {
        public static List<VariantInfo> variantInfos = new List<VariantInfo>();
        public static void Init()
        {
            variantInfos = MainClass.theOriginal30Assets.LoadAllAssets<VariantInfo>().ToList();
            if(MainClass.enableFaithfulness.Value)
            {
                foreach(VariantInfo variantInfo in variantInfos)
                {
                    switch(variantInfo.identifierName)
                    {
                        case "TO30_FullAutoGolem":
                            variantInfo.attackSpeedMultiplier = 8.0f;
                            variantInfo.damageMultiplier = 0.8f;
                            variantInfo.armorBonus = -20;
                            break;
                        case "TO30_OverchargedGolem":
                            variantInfo.damageMultiplier = 10f;
                            variantInfo.armorBonus = 0;
                            break;
                        case "TO30_ToxicBeetle":
                            variantInfo.moveSpeedMultiplier = 1;
                            variantInfo.damageMultiplier = 1;
                            break;
                    }
                }
            }
        }
    }
}