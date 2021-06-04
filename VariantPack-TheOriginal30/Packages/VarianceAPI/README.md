# Variance API

A complete continuation of Rob's Original MonsterVariants mod.


The API by itself currently doesnt do much, but theoretically all the ground work is done for the creation of custom variants.

It is not advised to replace your Variants mods with this API just yet, as its in early development.

Currently supports all *(i think)* the previous features of MonsterVariants, alongside a new MonsterVariantTier and a complete implementation of MonsterVariantsPlus' Rewards system.

## Todo's

	- Continue development of the API


## Changelog
'0.2.0'

* VariantInfo now contains VariantConfig scriptable object, VariantConfig is used to create the config entries for your Variants.

	- VariantConfig allows you to:
		
		- Set the spawn chance of a Variant.

		- Wether the variant is unique or not.

* Removed VariantRegisterBase

* Added VariantInfoHandler, use this now to register your variants, as it streamlines the process.

* Added Helpers for creating VariantConfig Scriptable Objects in code, one for Vanilla entities and another one for Modded entities.

'0.1.1'

* Forgot to call the method that makes the config, whoops.

'0.1.0'

* Added the VariantRewardHandler Component, officially porting a good chunk of MonsterVariantPlus' Features.

* Added VariantRegisterBase, a helper for easily register variants made in Thunderkit.

* Added Config file with a lot of config entries for the VariantRewardHandler and global settings.

* Started working on a helper for creating Variant's Spawn Chances via config

* Determination++ After learning rob likes what i'm doing.

'0.0.2'

* Added Github Link.

* Made changes to the scriptable objects, now they can be made in Thunderkit instead of on RunTime.

'0.0.1'

* Initial Release