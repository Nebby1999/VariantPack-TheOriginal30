﻿using System;
using RoR2;
using EntityStates.ScavMonster;

namespace TheOriginal30.VariantEntityStates.Scavenger
{
    public class EnterLuckySit : BaseSitState
    {
        private float duration;

        public override void OnEnter()
        {
            base.OnEnter();
            this.duration = EnterSit.baseDuration / this.attackSpeedStat;

            Util.PlaySound(EnterSit.soundString, base.gameObject);
            base.PlayCrossfade("Body", "EnterSit", "Sit.playbackRate", this.duration, 0.1f);

            base.modelLocator.normalizeToFloor = true;
            base.modelLocator.modelTransform.GetComponent<AimAnimator>().enabled = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.fixedAge >= this.duration)
            {
                this.outer.SetNextState(new DreamLuck());
            }
        }
    }
}