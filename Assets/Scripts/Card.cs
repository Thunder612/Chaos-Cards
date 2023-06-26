using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card// : MonoBehaviour
{
    public int id;
    public string cardName;
    public int cost;
    public int value;
    public string cardDescription;
    public string suit;
    public string game;
    public string color;
    public Sprite spriteImage;




    public Card()
    {

    }

    public Card(int Id, string CardName, int Cost, int Value, string CardDescription, string Suit, string Game, string Color, Sprite SpriteImage)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        value = Value;
        cardDescription = CardDescription;
        suit = Suit;
        game = Game;
        color = Color;
        spriteImage = SpriteImage;
    }
}
