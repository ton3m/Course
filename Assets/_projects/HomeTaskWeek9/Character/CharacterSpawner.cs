using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private CharacterInstaller _characterInstaller;
    [SerializeField] private Transform _spawnPoint;

    public CharacterInstaller Spawn()
    {
        CharacterInstaller installer = Object.Instantiate(_characterInstaller);
        
        installer.transform.position = _spawnPoint.position;
        installer.gameObject.SetActive(true);

        return installer;
    }
}
