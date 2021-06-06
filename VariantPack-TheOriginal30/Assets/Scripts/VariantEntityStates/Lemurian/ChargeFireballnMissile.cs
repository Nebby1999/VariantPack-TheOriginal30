﻿using EntityStates;
using EntityStates.LemurianMonster;
using RoR2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheOriginal30.VariantEntityStates.Lemurian
{
    public class ChargeFireballnMissile : BaseState
    {
		public static float baseDuration;

		public static GameObject chargeVfxPrefab;

		public static string attackString;

		private float duration;

		private GameObject chargeVfxInstance;

		public override void OnEnter()
		{
			chargeVfxPrefab = ChargeFireball.chargeVfxPrefab;
			attackString = ChargeFireball.attackString;
			baseDuration = ChargeFireball.baseDuration;
			base.OnEnter();
			duration = baseDuration / attackSpeedStat;
			GetModelAnimator();
			Transform modelTransform = GetModelTransform();
			Util.PlayAttackSpeedSound(attackString, base.gameObject, attackSpeedStat);
			if ((bool)modelTransform)
			{
				ChildLocator component = modelTransform.GetComponent<ChildLocator>();
				if ((bool)component)
				{
					Transform transform = component.FindChild("MuzzleMouth");
					if ((bool)transform && (bool)chargeVfxPrefab)
					{
						chargeVfxInstance = Object.Instantiate(chargeVfxPrefab, transform.position, transform.rotation);
						chargeVfxInstance.transform.parent = transform;
					}
				}
			}
			PlayAnimation("Gesture", "ChargeFireball", "ChargeFireball.playbackRate", duration);
		}

		public override void OnExit()
		{
			base.OnExit();
			if ((bool)chargeVfxInstance)
			{
				EntityState.Destroy(chargeVfxInstance);
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (base.fixedAge >= duration && base.isAuthority)
			{
				FireFireballnMissile nextState = new FireFireballnMissile();
				outer.SetNextState(nextState);
			}
		}

		public override InterruptPriority GetMinimumInterruptPriority()
		{
			return InterruptPriority.Skill;
		}
	}
}
