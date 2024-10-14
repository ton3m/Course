using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyInstaller _enemyInstaller;
    [SerializeField] private EnemySpawnPoint[] _spawnPoints;

    public void SpawnAll()
    {
        foreach (EnemySpawnPoint spawnPoint in _spawnPoints)
        {
            var installer = SpawnEnemy(spawnPoint.transform.position, spawnPoint.transform.rotation);
    
            installer.Init(spawnPoint.ReactionBehaviour, spawnPoint.RegularBehaviour);
        }
    }

    private EnemyInstaller SpawnEnemy(Vector3 position, Quaternion rotation)
    {
        EnemyInstaller installer = Instantiate(_enemyInstaller);
        
        installer.transform.position = position;
        installer.transform.rotation = rotation; 

        installer.gameObject.SetActive(true);

        return installer;
    }
}
