using TMPro;
using UnityEngine;

namespace ItemsGame
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _hpText;
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private TMP_Text _itemText;

        private Character _character;

        public void Init(Character character)
        {
            _character = character;
        }

        public void UpdateView()
        {
            _hpText.text = $"HP: {_character.Health}";
            _speedText.text = $"Speed: {_character.Speed}";
            UpdateItemView(_character.HoldingItem);
        }

        private void UpdateItemView(IItem item)
        {
            _itemText.text = item is null ? "Item: no" : $"Item: {item.Name}";
        }
    }
}