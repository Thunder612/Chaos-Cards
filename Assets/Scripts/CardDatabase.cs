using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();




    void Awake()
    {
        Console.Write("Awakened");
        cardList.Add(new Card(0, "None", 0, 0, "None", "None", "None", "None", null));
        cardList.Add(new Card(1, "Ace of Spades", 0, 1, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/Ace of Spades") ));
        cardList.Add(new Card(2, "2 of Spades", 0, 2, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/2 of Spades") ));
        cardList.Add(new Card(3, "3 of Spades", 0, 3, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/3 of Spades")));
        cardList.Add(new Card(4, "4 of Spades", 0, 4, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/4 of Spades")));
        cardList.Add(new Card(5, "5 of Spades", 0, 5, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/5 of Spades")));
        cardList.Add(new Card(6, "6 of Spades", 0, 6, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/6 of Spades")));
        cardList.Add(new Card(7, "7 of Spades", 0, 7, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/7 of Spades")));
        cardList.Add(new Card(8, "8 of Spades", 0, 8, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/8 of Spades")));
        cardList.Add(new Card(9, "9 of Spades", 0, 9, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/9 of Spades")));
        cardList.Add(new Card(10, "10 of Spades", 0, 10, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/10 of Spades")));
        cardList.Add(new Card(11, "Jack of Spades", 0, 11, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/Jack of Spades")));
        cardList.Add(new Card(12, "Queen of Spades", 0, 12, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/Queen of Spades")));
        cardList.Add(new Card(13, "King of Spades", 0, 13, "None", "Spades", "Dohker", "Black", Resources.Load<Sprite>("Spades/King of Spades")));

        cardList.Add(new Card(14, "Ace of Clubs", 0, 1, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/Ace of Clubs")));
        cardList.Add(new Card(15, "2 of Clubs", 0, 2, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/2 of Clubs")));
        cardList.Add(new Card(16, "3 of Clubs", 0, 3, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/3 of Clubs")));
        cardList.Add(new Card(17, "4 of Clubs", 0, 4, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/4 of Clubs")));
        cardList.Add(new Card(18, "5 of Clubs", 0, 5, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/5 of Clubs")));
        cardList.Add(new Card(19, "6 of Clubs", 0, 6, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/6 of Clubs")));
        cardList.Add(new Card(20, "7 of Clubs", 0, 7, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/7 of Clubs")));
        cardList.Add(new Card(21, "8 of Clubs", 0, 8, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/8 of Clubs")));
        cardList.Add(new Card(22, "9 of Clubs", 0, 9, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/9 of Clubs")));
        cardList.Add(new Card(23, "10 of Clubs", 0, 10, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/10 of Clubs")));
        cardList.Add(new Card(24, "Jack of Clubs", 0, 11, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/Jack of Clubs")));
        cardList.Add(new Card(25, "Queen of Clubs", 0, 12, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/Queen of Clubs")));
        cardList.Add(new Card(26, "King of Clubs", 0, 13, "None", "Clubs", "Dohker", "Black", Resources.Load<Sprite>("Clubs/King of Clubs")));

        cardList.Add(new Card(27, "Ace of Diamonds", 0, 1, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/Ace of Diamonds")));
        cardList.Add(new Card(28, "2 of Diamonds", 0, 2, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/2 of Diamonds")));
        cardList.Add(new Card(29, "3 of Diamonds", 0, 3, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/3 of Diamonds")));
        cardList.Add(new Card(30, "4 of Diamonds", 0, 4, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/4 of Diamonds")));
        cardList.Add(new Card(31, "5 of Diamonds", 0, 5, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/5 of Diamonds")));
        cardList.Add(new Card(32, "6 of Diamonds", 0, 6, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/6 of Diamonds")));
        cardList.Add(new Card(33, "7 of Diamonds", 0, 7, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/7 of Diamonds")));
        cardList.Add(new Card(34, "8 of Diamonds", 0, 8, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/8 of Diamonds")));
        cardList.Add(new Card(35, "9 of Diamonds", 0, 9, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/9 of Diamonds")));
        cardList.Add(new Card(36, "10 of Diamonds", 0, 10, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/10 of Diamonds")));
        cardList.Add(new Card(37, "Jack of Diamonds", 0, 11, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/Jack of Diamonds")));
        cardList.Add(new Card(38, "Queen of Diamonds", 0, 12, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/Queen of Diamonds")));
        cardList.Add(new Card(39, "King of Diamonds", 0, 13, "None", "Diamonds", "Dohker", "Red", Resources.Load<Sprite>("Diamonds/King of Diamonds")));

        cardList.Add(new Card(40, "Ace of Hearts", 0, 1, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/Ace of Hearts")));
        cardList.Add(new Card(41, "2 of Hearts", 0, 2, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/2 of Hearts")));
        cardList.Add(new Card(42, "3 of Hearts", 0, 3, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/3 of Hearts")));
        cardList.Add(new Card(43, "4 of Hearts", 0, 4, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/4 of Hearts")));
        cardList.Add(new Card(44, "5 of Hearts", 0, 5, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/5 of Hearts")));
        cardList.Add(new Card(45, "6 of Hearts", 0, 6, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/6 of Hearts")));
        cardList.Add(new Card(46, "7 of Hearts", 0, 7, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/7 of Hearts")));
        cardList.Add(new Card(47, "8 of Hearts", 0, 8, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/8 of Hearts")));
        cardList.Add(new Card(48, "9 of Hearts", 0, 9, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/9 of Hearts")));
        cardList.Add(new Card(49, "10 of Hearts", 0, 10, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/10 of Hearts")));
        cardList.Add(new Card(50, "Jack of Hearts", 0, 11, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/Jack of Hearts")));
        cardList.Add(new Card(51, "Queen of Hearts", 0, 12, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/Queen of Hearts")));
        cardList.Add(new Card(52, "King of Hearts", 0, 13, "None", "Hearts", "Dohker", "Red", Resources.Load<Sprite>("Hearts/King of Hearts")));
    }
}
