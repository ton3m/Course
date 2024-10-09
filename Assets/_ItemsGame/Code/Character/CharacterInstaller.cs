using ItemsGame.ItemsHandlers;
using UnityEngine;

namespace ItemsGame
{
    [RequireComponent(typeof(ShootPointHolder))]
    [RequireComponent(typeof(EffectsPointHolder))]
    public class CharacterInstaller : MonoBehaviour, IHealthIncreaser, ISpeedIncreaser
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private Rotater _rotater;
        
        [SerializeField] private ItemsCollector _itemsCollector;
        [SerializeField] private Transform _inventoryViewPoint;
        
        private IInventory _inventory;
        private IItemUser _itemUser;
        private Health _health;
        private PlayerInput _input;

        private Character _character;

        public Character Init(PlayerInput input, float health, float maxHealth)
        {
            DependenciesHolder holder = new(gameObject);
            _input = input;

            _itemUser = new ItemUser(holder, holder.Container.name);

            InventoryView inventoryView = new InventoryView(_inventoryViewPoint);
            
            _inventory = new Inventory(_itemUser, inventoryView);
            _health = new Health(maxHealth, health);
            
            _itemsCollector.Init(_inventory);
            _mover.Init(input);

            _character = new Character(_mover, _health, _inventory, _itemUser);

            return _character;
        }

        public void IncreaseSpeed(float value) => _mover.Increase(value);

        public void IncreaseHealth(float value) => _health.Increase(value);

        private void Update()
        {
            if (_input.UseItemKeyDown) 
                _character.OnUseItemInput();

            if (_mover.Direction.magnitude > 0) 
                _rotater.SetDirection(_mover.Direction);
        }
    }
}