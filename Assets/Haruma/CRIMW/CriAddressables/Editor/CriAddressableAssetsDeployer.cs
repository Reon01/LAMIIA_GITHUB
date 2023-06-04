/****************************************************************************
 *
 * Copyright (c) 2022 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

/**
 * \addtogroup CRIADDON_ADDRESSABLES_INTEGRATION
 * @{
 */

#if CRI_USE_ADDRESSABLES

using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Build;
using System.Linq;
using System.IO;
using System.Collections.Generic;

using UnityEditor.Build.Pipeline;
using UnityEditor.Build.Pipeline.Interfaces;

namespace CriWare.Assets
{
	/**
	 * <summary>CRI Addressables のデータデプロイを行うエディタクラス</summary>
	 */
	public static class CriAddressableAssetsDeployer
	{
		public static event System.Action OnComplete;

		[InitializeOnLoadMethod]
		static void RegisterHook()
		{

			BuildScript.buildCompleted += (AddressableAssetBuildResult result) => {
				if (EditorApplication.isPlayingOrWillChangePlaymode) return;
				Deploy();
			};

			ContentPipeline.BuildCallbacks.PostWritingCallback += (param, deps, data, result) => {
				// only addressable build.
				if (!(param is UnityEditor.AddressableAssets.Build.DataBuilders.AddressableAssetsBundleBuildParameters))
					return ReturnCode.Success;
				var buildResult = result as IBundleBuildResults;
				if (buildResult == null) return ReturnCode.Success;
				return DeployAsWriteBundle(buildResult);
			};
		}

		/**
		 * <summary>CRI Addressables 向けのデータデプロイ</summary>
		 * <remarks>
		 * <para header='説明'>CRI Addressables を利用したランタイムで必要になるリモート向けデータの書き出しを行います。<br/>
		 * DeployTypeとして"Addressables (Remote)"や"Addressables (Local)"を利用する場合のみ呼び出しが必要です。<br/>
		 * "Addressables"のみをご利用の場合は呼び出す必要はありません。<br/>
		 * データは CriAddressablesSettings で設定したビルドパス以下に書き出されます。<br/>
		 * <br/>
		 * Addressable Group Setting 上からバンドルビルドを行った場合は本メソッドが自動的に呼び出されます。<br/>
		 * スクリプトからバンドルビルドを行っている場合は必要に応じてバンドルビルド後に本メソッドを呼び出してください。<br/></para>
		 * </remarks>
		 */
		[MenuItem("CRIWARE/Deploy Cri Addressables")]
		public static void Deploy()
		{
			DeployLocalData();
#if !CRI_ADDRESSABLES_DISABLE_LEGACY_DEPLOY
			DeployRemoteData();
#endif
			OnComplete?.Invoke();
		}

		public static void DeployLocalData()
		{
			var addressablesBuildPath = CriAddressablesSetting.Instance.Local.buildPath.GetValue(AddressableAssetSettingsDefaultObject.Settings);

			try
			{
				EditorUtility.DisplayProgressBar("[CRIWARE][Addressables] Collectiong dependencies for local bundles", "", 0);

				var assets = CriAddressablesEditor.CollectDependentAssets<CriLocalAddressablesAssetImpl>().ToList();

				if (assets.Count <= 0) return;

				var count = 0;
				foreach (var asset in assets)
				{
					count++;
					EditorUtility.DisplayProgressBar("[CRIWARE][Addressables] Deploy data for local bundles", $"{count} / {assets.Count} assets", (float)count / assets.Count);
					var srcPath = AssetDatabase.GetAssetPath(asset);
					var dstPath = Path.Combine(addressablesBuildPath, (asset.Implementation as CriLocalAddressablesAssetImpl).InternalPath);
					CriAddressablesEditor.DeployData(srcPath, dstPath);
				}
				Debug.Log($"[CRIWARE] CriAddressableAssetsDeployer copied {assets.Count} files to {addressablesBuildPath}/{CriStreamingFolderAssetImplCreator.DirectoryName}.");
			}
			catch
			{
				throw;
			}
			finally
			{
				EditorUtility.ClearProgressBar();
			}

			CriLocalAddressableGroupGenerator.ValidateGroup();
		}

		static ReturnCode DeployAsWriteBundle(IBundleBuildResults buildResults)
		{
			var addressableReferences = CriAddressablesEditor.CollectDependentAssets<CriAddressableAssetImpl>().ToList();
			var groups = new List<UnityEditor.AddressableAssets.Settings.AddressableAssetGroup>();
			foreach(var asset in addressableReferences)
			{
				var entry = AddressableAssetSettingsDefaultObject.Settings.FindAssetEntry(AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath((asset.Implementation as CriAddressableAssetImpl).anchor)));
				
				// do not deploy for "CriData" group
				if (entry.parentGroup == CriRemoteAddressableGroupGenerator.Group.AddressableGroup) continue;

				groups.Add(entry.parentGroup);
				var bundleName = CriAddressablesEditor.CalclateBundleName(entry);
				var path = buildResults.BundleInfos.FirstOrDefault(info => Path.ChangeExtension(info.Key, null) == bundleName).Value.FileName;
				CriAddressablesEditor.DeployData(AssetDatabase.GetAssetPath(asset), path);
			}

			foreach (var g in groups.Distinct())
				CriAddressableGroupGenerator.ValidateGroup(g);

			Debug.Log($"[CRIWARE] CriAddressableAssetsDeployer copied {addressableReferences.Count} files.");
			return ReturnCode.Success;
		}

		public static void DeployRemoteData()
		{
			try
			{
				EditorUtility.DisplayProgressBar("[CRIWARE]  Collectiong dependencies for remote bundles", "", 0);
				var addressableReferences = CriAddressablesEditor.CollectDependentAssets<CriAddressableAssetImpl>()
					.Select(asset => new
					{
						asset = asset,
						entry = AddressableAssetSettingsDefaultObject.Settings.FindAssetEntry(AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath((asset.Implementation as CriAddressableAssetImpl).anchor)))
					})
					.Where(pair => pair.entry.parentGroup == CriRemoteAddressableGroupGenerator.Group.AddressableGroup).ToList();

				if (addressableReferences.Count <= 0) return;

				var count = 0;
				foreach (var pair in addressableReferences)
				{
					count++;
					EditorUtility.DisplayProgressBar("[CRIWARE] Deploy data for remote bundles", $"{count} / {addressableReferences.Count} assets", (float)count / addressableReferences.Count);
					CriRemoteAddressableGroupGenerator.DeployData(AssetDatabase.GetAssetPath(pair.asset), pair.entry);
				}

				Debug.Log($"[CRIWARE] Deploy Cri Addressable Assets : Complete, {addressableReferences.Count} Files.");
			}
			catch
			{
				throw;
			}
			finally
			{
				EditorUtility.ClearProgressBar();
			}

			CriRemoteAddressableGroupGenerator.ValidateGroup();
		}
	}
}

#endif

/** @} */
