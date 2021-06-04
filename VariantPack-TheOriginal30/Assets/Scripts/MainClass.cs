using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BepInEx;
using VarianceAPI;
using VarianceAPI.Modules;
using System.Security;
using System.Security.Permissions;
using System.Reflection;
using System.IO;
using RoR2.ContentManagement;
using EntityStates;

[module: UnverifiableCode]
#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618 // Type or member is obsolete
namespace TheOriginal30
{
    [BepInPlugin("com.Nebby.TheOriginal30", "VP - The Original 30", "0.1.0")]
    [BepInDependency("com.Nebby.VarianceAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class MainClass : BaseUnityPlugin
    {
        public static MainClass instance;
        public static AssetBundle theOriginal30Assets = null;
        internal static string assetBundleName = "TheOriginal30Assets";

        public void Awake()
        {
            instance = this;
            LoadAssetsAndRegisterContentPack();
            Init();
        }

        public void Init()
        {
            var VR = new VariantRegister();
            VR.RegisterConfigs(theOriginal30Assets, Config);
			foreach (var entityState in TheOriginal30.VariantEntityStates.TO30EntityStates.EntityStates)
            {
				var state = new SerializableEntityStateType(typeof(VariantEntityStates.Beetle.HeavyHeadbutt));
				Debug.Log(state.typeName);
            }
        }
        public void LoadAssetsAndRegisterContentPack()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            theOriginal30Assets = AssetBundle.LoadFromFile(Path.Combine(path, assetBundleName));
			FixMaterials();
            ContentPackProvider.serializedContentPack = theOriginal30Assets.LoadAsset<SerializableContentPack>(ContentPackProvider.contentPackName);
        }
		private void FixMaterials()
        {
			var Materials = theOriginal30Assets.LoadAllAssets<Material>();
			foreach (Material material in Materials)
            {
				if(material.shader.name.StartsWith("StubbedShader"))
                {
					material.shader = Resources.Load<Shader>("shaders" + material.shader.name.Substring(13));
                }
            }
        }
    }
	public class ContentPackProvider : IContentPackProvider
	{
		public static SerializableContentPack serializedContentPack;
		public static ContentPack contentPack;
		//Should be the same names as your SerializableContentPack in the asset bundle
		public static string contentPackName = "TheOriginal30Content";

		public string identifier
		{
			get
			{
				//If I see this name while loading a mod I will make fun of you
				return "TheOriginal30";
			}
		}

		internal static void Initialize()
		{
			contentPack = serializedContentPack.CreateContentPack();
			ContentManager.collectContentPackProviders += AddCustomContent;
		}

		private static void AddCustomContent(ContentManager.AddContentPackProviderDelegate addContentPackProvider)
		{
			addContentPackProvider(new ContentPackProvider());
		}

		public IEnumerator LoadStaticContentAsync(LoadStaticContentAsyncArgs args)
		{
			args.ReportProgress(1f);
			yield break;
		}

		public IEnumerator GenerateContentPackAsync(GetContentPackAsyncArgs args)
		{
			ContentPack.Copy(contentPack, args.output);
			args.ReportProgress(1f);
			yield break;
		}

		public IEnumerator FinalizeAsync(FinalizeAsyncArgs args)
		{
			args.ReportProgress(1f);
			yield break;
		}
	}
}