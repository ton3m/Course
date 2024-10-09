using UnityEngine;

namespace ItemsGame
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private CharacterInstaller _characterPrefab;
        [SerializeField] private Transform _characterSpawnPoint;

        [SerializeField] private ItemHolder[] _itemHoldersPrefabs;
        [SerializeField] private Transform[] _itemHoldersSpawnPoints;

        public CharacterInstaller SpawnCharacter()
        {
            Vector3 position = _characterSpawnPoint.position;
                
            return Instantiate(_characterPrefab, position, Quaternion.identity);
        }

        public void SpawnItemHolders()
        {
            if (_itemHoldersPrefabs.Length < 1)
            {
                Debug.LogError("No items prefabs to spawn.");
                return;
            }

            for (var i = 0; i < _itemHoldersSpawnPoints.Length; i++)
            {
                int prefabsCount = _itemHoldersPrefabs.Length;
                int prefabIndex = i < prefabsCount ? i : i - prefabsCount;
                
                ItemHolder prefab = _itemHoldersPrefabs[prefabIndex];
                Vector3 position = _itemHoldersSpawnPoints[i].position;

                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
}