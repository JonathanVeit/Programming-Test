using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace StratosphereGames
{
    public enum CardCategoryType
    {
        None = 0,
        Shop = 1,
        Deck = 2,
        Factory = 3,
    }

    [Serializable]
    public struct ToggleButtonMapping {
        public CardCategoryType Type;
        public ToggleButton Button;
    }

    public class MainUI : MonoBehaviour
    {
        [SerializeField]
        private CardCategoryType StartCategory;
        [SerializeField]
        private List<ToggleButtonMapping> ButtonMapping;
        [SerializeField]
        private RectTransform CardRoot; // cards will be added here
        [SerializeField]
        private GameObject cardPrefab;

        private CardCategoryType CurrentCategory;

        private void Start()
        {
            SetCategory(StartCategory);
        }

        public void SetCategory(CardCategoryType type)
        {
            CurrentCategory = type;
            UpdateForCurrentCategory();
        }

        private void UpdateForCurrentCategory()
        {
            UpdateButtons();
            UpdateContent();
        }

        private void UpdateButtons()
        {
            foreach (var element in ButtonMapping)
            {
                bool newSetState = element.Type == CurrentCategory;
                element.Button.SetActivation(newSetState);
            }
        }

        public void HandleSetCategory(int category)
        {
            CardCategoryType newType = (CardCategoryType)category;
            SetCategory(newType);
        }

        private void UpdateContent()
        {
            // clean root 
            ClearRoot();

            foreach (var c in CardInfoMapping.GetMapping<CardInfoMapping>().Mapping)
                AddCard(c.Info);
        }

        private void ClearRoot() 
        {
            foreach (Transform c in CardRoot.transform)
                Destroy(c.gameObject);
        }

        private void AddCard(CardInfo card) 
        {
            var newCard = Instantiate(cardPrefab, CardRoot.position, CardRoot.rotation, CardRoot);

            newCard.GetComponent<UICard>().Initialize(card, CurrentCategory);
        }
    }

}