using UnityEngine;

public class Entry : MonoBehaviour
{
    [SerializeField] private CharacterSpawner _characterSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;

    private Game _game;

    private void Start()
    {
        _game = new Game(_characterSpawner, _enemySpawner);
        _game.Start();
    }

    private void Update() => _game.Update();
}