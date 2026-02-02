using UnityEngine;

namespace Unity.FantasyKingdom
{
    public class SpawnObject : MonoBehaviour
    {
        [SerializeField] private Transform prefab;
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                Instantiate(prefab);
            }
        }
    }
}
