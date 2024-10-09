using UnityEngine;

namespace ItemsGame
{
    public class Entry : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private CharacterView _characterView;
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(_spawner, _characterView);
            _game.Start();
        }

        private void Update() => _game?.Update();
    }
}