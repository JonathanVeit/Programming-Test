using StratosphereGames;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class UICard : MonoBehaviour
{
    [SerializeField]
    private UIInfoElement imgSprite;
    [SerializeField]
    private UIInfoElement txtLevel;
    [SerializeField]
    private UIInfoElement imgRarity;
    [SerializeField]
    private UIInfoElement txtCost;
    [SerializeField]
    private UIInfoElement txtPartsCost;

    public void Initialize(CardInfo card, CardCategoryType type)
    {
        var cardMapping = UICardInfoMapping.GetMapping<UICardInfoMapping>();
        var spriteMapping = UISpriteMapping.GetMapping<UISpriteMapping>();

        // sprite
        DisplayInfo(cardMapping.GetCardInfoForType(type).Sprite, imgSprite, spriteMapping.GetSpriteForType(card.Sprite));

        // level
        DisplayInfo(cardMapping.GetCardInfoForType(type).Level, txtLevel, card.Level.ToString());

        // rarity color
        DisplayInfo(cardMapping.GetCardInfoForType(type).RarityColor, imgRarity, card.RarityColor);

        // cost
        DisplayInfo(cardMapping.GetCardInfoForType(type).Costs, txtCost, card.Costs.ToString());

        // part cost 
        DisplayInfo(cardMapping.GetCardInfoForType(type).PartCost, txtPartsCost, card.CollectedScraps.ToString(), card.ConstructionCosts.ToString());
    }

    void DisplayInfo(bool isActive, UIInfoElement element, string content) 
    {
        element.main.enabled = isActive;
        foreach (var c in element.subParts)
            c.enabled = isActive;

        (element.main as Text).text = content;
    }

    void DisplayInfo(bool isActive, UIInfoElement element, string contentNum, string contentDenom)
    {
        element.main.enabled = isActive;
        foreach (var c in element.subParts)
            c.enabled = isActive;

        (element.main as Text).text = contentNum + "/" + contentDenom; 
    }

    void DisplayInfo(bool isActive, UIInfoElement element , Sprite content)
    {
        element.main.enabled = isActive;
        foreach (var c in element.subParts)
            c.enabled = isActive;

        (element.main as Image).sprite = content;
    }

    void DisplayInfo(bool isActive, UIInfoElement element, Color content)
    {
        element.main.enabled = isActive;
        foreach (var c in element.subParts)
            c.enabled = isActive;

        (element.main as Image).color = content;
    }

    [System.Serializable]
    public struct UIInfoElement
    {
        public Behaviour main;
        public Behaviour[] subParts;
    }
}
