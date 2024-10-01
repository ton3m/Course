using ItemsGame.Code.New.ItemsHandlers;
using UnityEngine;

namespace ItemsGame.Code.New
{
    public class Game
    {
        private readonly Character _characterPrefab;
        private EffectsItem _item;

        public Game(Character characterPrefab, EffectsItem item)
        {
            _item = item;
            _characterPrefab = characterPrefab;
        }

        public void Start()
        {
            Character instance = Object.Instantiate(_characterPrefab, Vector3.up, Quaternion.identity);

            DependenciesContainer dependenciesContainer = new(instance.gameObject);

            var input = new PlayerInput();
            var hp = 100f;
            
            instance.Init(input, hp);


            ItemsUser itemsUser = new(dependenciesContainer);
            itemsUser.Use(_item);


            IEffect increseHealth = new IncreaseHealthEffect(50f);
            IEffect increseSpeed = new IncreaseSpeedEffect(10f);
            IEffect shoot = new ShootEffect(null);

            //user.Apply(increseHealth);
            //user.Apply(increseSpeed);
            //user.Apply(shoot);
        }

        public void Update()
        {
        }
    }
}