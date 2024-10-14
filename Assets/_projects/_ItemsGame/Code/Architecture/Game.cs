namespace ItemsGame
{
    public class Game
    {
        private CharacterView _characterView;
        private Spawner _spawner;

        public Game(Spawner spawner, CharacterView characterView)
        {
            _spawner = spawner;
            _characterView = characterView;
        }

        public void Start()
        {
            PlayerInput input = new PlayerInput();
            
            float hp = 95f;
            float maxHp = 100f;

            CharacterInstaller characterInstaller = _spawner.SpawnCharacter();
            Character character = characterInstaller.Init(input, hp, maxHp);

            _characterView.Init(character);
            
            _spawner.SpawnItemHolders();
        }

        public void Update() => _characterView.UpdateView();
    }
}