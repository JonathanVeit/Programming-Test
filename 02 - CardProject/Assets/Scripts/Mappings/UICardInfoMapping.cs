using StratosphereGames.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StratosphereGames
{
    [Serializable]
    public class UICardInfo
    {
        public bool Sprite;
        public bool Level;
        public bool RarityColor;
        public bool Costs;
        public bool PartCost;
    }

    [Serializable]
    public class UICardInfoMappingElement : IHasEnumType<CardCategoryType>
    {
        [SerializeField]
        private CardCategoryType _Type;
        public CardCategoryType Type
        {
            get
            {
                return _Type;
            }
        }
        public UICardInfo Info;
    }

    [CreateAssetMenu(fileName = "UICardInfoMapping", menuName = "AssetMappings/UICardInfoMapping")]
    public class UICardInfoMapping : MappingAsset<UICardInfoMapping, CardCategoryType, UICardInfoMappingElement>
    {
        public UICardInfo GetCardInfoForType(CardCategoryType id)
        {
            var element = GetElementForType(id);
            if (element != null)
            {
                return element.Info;
            }
            return null;
        }
    }
}
