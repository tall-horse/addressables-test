using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Unity.FantasyKingdom
{
    public class SpawnObjectAddressables : MonoBehaviour
    {
        [SerializeField] private AssetReference assetReference;
        [SerializeField] private AssetLabelReference assetLabelReference;
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                Addressables.LoadAssetAsync<GameObject>(assetLabelReference).Completed += OnWorldLoadCompleted;
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
