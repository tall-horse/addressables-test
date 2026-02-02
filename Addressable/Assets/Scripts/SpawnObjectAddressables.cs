using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Unity.FantasyKingdom
{
    public class SpawnObjectAddressables : MonoBehaviour
    {
        [SerializeField] private AssetReference assetReference;
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                assetReference.LoadAssetAsync<GameObject>().Completed += OnWorldLoadCompleted;
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
