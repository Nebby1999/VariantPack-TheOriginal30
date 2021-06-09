﻿using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VarianceAPI.Components;

namespace TheOriginal30.VariantComponents
{
    public class AddGunToVulture : VariantComponent
    {
        private CharacterModel model;
        private ChildLocator childLocator;

        private void Start()
        {
            this.model = base.GetComponent<CharacterModel>();
            this.childLocator = base.GetComponentInChildren<ChildLocator>();

            this.AddGun();
        }

        private void AddGun()
        {
            if(this.model)
            {
                GameObject gun = UnityEngine.Object.Instantiate<GameObject>(MainClass.theOriginal30Assets.LoadAsset<GameObject>("VulturePistol"), childLocator.FindChild("Head"));
                gun.transform.localPosition = new Vector3(0, 3.5f, 0.5f);
                gun.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 180));
                gun.transform.localScale = Vector3.one * 16f;
            }
        }
    }
}
