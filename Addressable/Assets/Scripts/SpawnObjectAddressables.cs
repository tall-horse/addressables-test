using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Unity.FantasyKingdom
{
    public class SpawnObjectAddressables : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Heavy Asset.prefab");

                asyncOperationHandle.Completed += OnWorldLoadCompleted;
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
