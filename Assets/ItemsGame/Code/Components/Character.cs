using ItemsGame.Code.New.ItemsHandlers;
using UnityEngine;

namespace ItemsGame.Code.New
{
    public class Character : MonoBehaviour, IHealthHolder, IEffectApplierHolder
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private ItemsCollector _collector;
        
        private PlayerInput _input;
        private Health _health;
        private Inventory _inventory;
        
        private IEffectsApplier _effectsApplier;

        public void Init(PlayerInput input, float maxHp)
        {
            _input = input;
            _health = new Health(maxHp);

            DependenciesContainer container = new(gameObject);
            
            _effectsApplier = new EffectsApplier(container);
            ItemsUser user = new ItemsUser(container);
            
            _inventory = new Inventory();
            
            _mover.Init(_input);
            _collector.Init(_inventory);
        }
        
        public Health Health => _health;

        public IEffectsApplier EffectsApplier => _effectsApplier;

        private void Update()
        {
            if (_input.UseItemKeyDown)
                if (_inventory.HasItem == false) 
                    Debug.Log("No item to use");
        }
    }
}