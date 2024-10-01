using UnityEngine;

namespace ItemsGame.Code.New
{
    public class Entry : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private EffectsItem _item;

        private Game _game;

        private void Awake()
        {
            _game = new(_character, _item);
            _game.Start();
        }

        private void Update() => _game.Update();
    }
}