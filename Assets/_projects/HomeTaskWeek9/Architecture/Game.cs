public class Game
{
    private readonly CharacterSpawner _characterSpawner;
    private readonly EnemySpawner _enemySpawner;

    public Game(CharacterSpawner characterSpawner, EnemySpawner enemySpawner)
    {
        _characterSpawner = characterSpawner;
        _enemySpawner = enemySpawner;
    }

    public void Start()
    {
        CharacterInstaller characterInstaller = _characterSpawner.Spawn();
        characterInstaller.Init(new ItemsGame.PlayerInput());

        EnemyInstaller enemyInstaller = _enemySpawner.SpawnAll();
        enemyInstaller.Init();
    }

    public void Update()
    {
    }
}
