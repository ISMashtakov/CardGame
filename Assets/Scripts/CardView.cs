using CardGame.Game.Cards.Weapons;
using CardGame.Game.Cards.Types;
using UnityEngine;
using TMPro;

namespace CardGame.Game.Cards {
    [RequireComponent(typeof(CardPresenter))]
    public class CardView : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _weaponSprite;
        [SerializeField] TMP_Text _name;
        [SerializeField] TMP_Text _text;
        [SerializeField] Canvas _canvas;
        SpriteRenderer _spriteRenderer;
        
        CardPresenter _cardPresenter;
        Card _card;

        WeaponsStorage _weaponsStorage;
        CardTypeStorage _cardTypeStorage;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _cardPresenter = GetComponent<CardPresenter>();
            _cardPresenter.OnLayerChangedEvent.AddListener(SetLayer);
            _weaponsStorage = WeaponsStorage.GetInstanse();
            _cardTypeStorage = CardTypeStorage.GetInstanse();
        }

        private void Start()
        {
            _card = _cardPresenter.Card;
            SetText(_card.Text);
            SetName(_card.Name);
            SetWeapon(_card.Weapon);
            SetType(_card.CardType);
        }

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void SetName(string name)
        {
            _name.name = name;
        }

        public void SetWeapon(Weapon weapon)
        {
            switch (weapon)
            {
                case Weapon.Mace:
                    _weaponSprite.sprite = _weaponsStorage.MaceWeaponSprite;
                    break;
            }
        }

        public void SetType(CardType type)
        {
            switch (type)
            {
                case CardType.ATTACK:
                    _spriteRenderer.sprite = _cardTypeStorage.AttackCardBack;
                    break;
            }
        }

        public void SetLayer(int layer)
        {
            _spriteRenderer.sortingOrder = layer;
            _canvas.sortingOrder = layer + 1;
            _weaponSprite.sortingOrder = layer + 1;
        }
    }
}
