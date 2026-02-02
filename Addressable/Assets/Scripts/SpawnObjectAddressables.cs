using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Unity.FantasyKingdom
{
    [Serializable]
    public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
    {
        public AssetReferenceAudioClip(string guid) : base(guid)
        {
        }
    }
    public class SpawnObjectAddressables : MonoBehaviour
    {
        [SerializeField] private AssetReference assetReference;
        [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;
        [SerializeField] private AssetReferenceAudioClip assetReferenceAudioClip;
        [SerializeField] private AssetLabelReference assetLabelReference;

        private GameObject spawnedGameObject;
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                assetReferenceGameObject.InstantiateAsync().Completed += (asyncOperation) => spawnedGameObject = asyncOperation.Result;
            }
            if(Input.GetKeyDown(KeyCode.U))
            {
                assetReferenceGameObject.ReleaseInstance(spawnedGameObject);
            }
        }
        private void OnWorldLoadCompleted(AsyncOperationHandle<GameObject> asyncOperationHandle)
        {
            if(asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(asyncOperationHandle.Result);
            }
            else
            {
                Debug.Log("Failed to load!");
            }
        }
    }
}
