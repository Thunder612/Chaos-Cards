using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{

    public bool isYourTurn;
    public int yourTurn;
    public int opponentsTurn;
    public Text turnText;

    public int maxEnergy;
    public int currentEnergy;
    public Text energyText;

    public static bool startTurn;
    public static bool oppStartTurn;

    public GameObject playerZone;
    public GameObject oppZone;
    public Text rankText;

    public bool countdown = false;
    public int lockInTurn;
    public GameObject lockInButton;

    public bool PlayerWins;
    public bool PlayerLoses;
    public GameObject endScreen;
    public Text endText;

    List<int> pairList = new List<int>();
    List<int> OpairList = new List<int>();

    int OhighestValue = 0;
    int OhighestPair = 0;
    int OhighestTrio = 0;
    int OhighestQuad = 0;
    int OhighestQuint = 0;
    int OhighestStraight = 0;
    bool Oflush = false;
    bool OfullHouse = false;




    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        opponentsTurn = 0;

        maxEnergy = 1;
        currentEnergy = 1;

        startTurn = false;
        oppStartTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn)
        {
            turnText.text = "Your Turn";
        } else
        {
            turnText.text = "Opponent's Turn";
        }

        energyText.text = currentEnergy + "/" + maxEnergy;
    }

    public void endYourTurn()
    {
        isYourTurn = false;
        opponentsTurn++;

        List<DisplayCard> playedCards = playerZone.GetComponent<PlayerZone>().GetPlayedCards();
        int highestValue = 0;
        int highestPair = 0;
        int highestTrio = 0;
        int highestQuad = 0;
        int highestQuint = 0;
        int highestStraight = 0;
        bool flush = false;
        bool fullHouse = false;

        foreach (DisplayCard card in playedCards) //Checks Highest Card
        {
            if (card.displayCard[0].value > highestValue)
            {
                highestValue = card.displayCard[0].value;
            }
        }

        foreach (DisplayCard card in playedCards) //Checks for pairs, trios, quads, and quints
        {
            int value = card.displayCard[0].value;
            int occurences = 0;
            {
                foreach (DisplayCard card2 in playedCards)
                {
                    if (card2.displayCard[0].value == value)
                    {
                        occurences++;
                    }
                }
            }

            if (value > highestPair && occurences >= 2)
            {
                highestPair = value;
                pairList.Add(value);
            }

            if (value > highestTrio && occurences >= 3)
            {
                highestTrio = value;
                foreach (int pair in pairList)
                {
                    if (value != pair)
                    {
                        fullHouse = true;
                    }
                }
            }

            if(value > highestQuad && occurences >= 4)
            {
                highestQuad = value;
            }

            if (value > highestQuint && occurences >= 5)
            {
                highestQuint = value;
            }

        }

        foreach(DisplayCard card in playedCards) //Checks for straight
        {
            int value = card.displayCard[0].value;
            bool value1 = false;
            bool value2 = false;
            bool value3 = false;
            bool value4 = false;
            foreach (DisplayCard card2 in playedCards)
            {
                if (card2.displayCard[0].value == value + 1)
                {
                    value1 = true;
                }
                if (card2.displayCard[0].value == value + 2)
                {
                    value2 = true;
                }
                if (card2.displayCard[0].value == value + 3)
                {
                    value3 = true;
                }
                if (card2.displayCard[0].value == value + 4)
                {
                    value4 = true;
                }
            }

            if (value > highestStraight && value1 && value2 && value3 && value4)
            {
                highestStraight = value + 4;
            }
        }

        foreach (DisplayCard card in playedCards) //Checks for Flush
        {
            string suit = card.displayCard[0].suit;
            int occurences = 0;
            foreach (DisplayCard card2 in playedCards)
            {
                if (card2.displayCard[0].suit == suit)
                {
                    occurences++;
                }
            }
            if (occurences >= 5)
            {
                flush = true;
            }
        }

        rankText.text = highestValue + " High";

        if (highestPair > 0)
        {
            rankText.text = "Two " + highestPair + "s";
        }

        if (highestTrio > 0)
        {
            rankText.text = "Three " + highestTrio + "s!";
        }

        if (highestStraight > 0)
        {
            rankText.text = highestStraight + " High Straight!";
        }

        if (flush)
        {
            rankText.text = "Flush!";
        }

        if (fullHouse)
        {
            rankText.text = "Full House!";
        }

        if (highestQuad > 0)
        {
            rankText.text = "Four of a Kind!";
        }

        if (flush && highestStraight > 0)
        {
            rankText.text = "Straight Flush!!";
        }

        if (highestQuint > 0)
        {
            rankText.text = "Five of a Kind!!!";
        }

        
        endOpponentsTurn();
    }

    public void endOpponentsTurn()
    {
        isYourTurn = true;
        yourTurn++;
        maxEnergy++;
        currentEnergy = maxEnergy;

        startTurn = true;
        oppStartTurn = true;


        List<OppDisplayCard> playedCards = oppZone.GetComponent<OppZone>().GetPlayedCards();

        foreach (OppDisplayCard card in playedCards) //Checks Highest Card
        {
            if (card.displayCard[0].value > OhighestValue)
            {
                OhighestValue = card.displayCard[0].value;
            }
        }

        foreach (OppDisplayCard card in playedCards) //Checks for pairs, trios, quads, and quints
        {
            int value = card.displayCard[0].value;
            int occurences = 0;
            {
                foreach (OppDisplayCard card2 in playedCards)
                {
                    if (card2.displayCard[0].value == value)
                    {
                        occurences++;
                    }
                }
            }

            if (value > OhighestPair && occurences >= 2)
            {
                OhighestPair = value;
                OpairList.Add(value);
            }

            if (value > OhighestTrio && occurences >= 3)
            {
                OhighestTrio = value;
                foreach (int pair in OpairList)
                {
                    if (value != pair)
                    {
                        OfullHouse = true;
                    }
                }
            }

            if (value > OhighestQuad && occurences >= 4)
            {
                OhighestQuad = value;
            }

            if (value > OhighestQuint && occurences >= 5)
            {
                OhighestQuint = value;
            }

        }

        foreach (OppDisplayCard card in playedCards) //Checks for straight
        {
            int value = card.displayCard[0].value;
            bool value1 = false;
            bool value2 = false;
            bool value3 = false;
            bool value4 = false;
            foreach (OppDisplayCard card2 in playedCards)
            {
                if (card2.displayCard[0].value == value + 1)
                {
                    value1 = true;
                }
                if (card2.displayCard[0].value == value + 2)
                {
                    value2 = true;
                }
                if (card2.displayCard[0].value == value + 3)
                {
                    value3 = true;
                }
                if (card2.displayCard[0].value == value + 4)
                {
                    value4 = true;
                }
            }

            if (value > OhighestStraight && value1 && value2 && value3 && value4)
            {
                OhighestStraight = value + 4;
            }
        }

        foreach (OppDisplayCard card in playedCards) //Checks for Flush
        {
            string suit = card.displayCard[0].suit;
            int occurences = 0;
            foreach (OppDisplayCard card2 in playedCards)
            {
                if (card2.displayCard[0].suit == suit)
                {
                    occurences++;
                }
            }
            if (occurences >= 5)
            {
                Oflush = true;
            }
        }

        if (OppDeck.oppDesiredHand.Equals("Straight") && OppDeck.oppDesiredValue <= OhighestStraight && !countdown)
        {
            LockIn();
        }

        if (countdown && lockInTurn < yourTurn - 5)
        {
            endGame();
        }
    }

    public void endGame()
    {

        //Calculates Player's Zone
        List<DisplayCard> playedCards = playerZone.GetComponent<PlayerZone>().GetPlayedCards();
        int highestValue = 0;
        int highestPair = 0;
        int highestTrio = 0;
        int highestQuad = 0;
        int highestQuint = 0;
        int highestStraight = 0;
        bool flush = false;
        bool fullHouse = false;

        foreach (DisplayCard card in playedCards) //Checks Highest Card
        {
            if (card.displayCard[0].value > highestValue)
            {
                highestValue = card.displayCard[0].value;
            }
        }

        foreach (DisplayCard card in playedCards) //Checks for pairs, trios, quads, and quints
        {
            int value = card.displayCard[0].value;
            int occurences = 0;
            {
                foreach (DisplayCard card2 in playedCards)
                {
                    if (card2.displayCard[0].value == value)
                    {
                        occurences++;
                    }
                }
            }

            if (value > highestPair && occurences >= 2)
            {
                highestPair = value;
                pairList.Add(value);
            }

            if (value > highestTrio && occurences >= 3)
            {
                highestTrio = value;
                foreach (int pair in pairList)
                {
                    if (value != pair)
                    {
                        fullHouse = true;
                    }
                }
            }

            if (value > highestQuad && occurences >= 4)
            {
                highestQuad = value;
            }

            if (value > highestQuint && occurences >= 5)
            {
                highestQuint = value;
            }

        }

        foreach (DisplayCard card in playedCards) //Checks for straight
        {
            int value = card.displayCard[0].value;
            bool value1 = false;
            bool value2 = false;
            bool value3 = false;
            bool value4 = false;
            foreach (DisplayCard card2 in playedCards)
            {
                if (card2.displayCard[0].value == value + 1)
                {
                    value1 = true;
                }
                if (card2.displayCard[0].value == value + 2)
                {
                    value2 = true;
                }
                if (card2.displayCard[0].value == value + 3)
                {
                    value3 = true;
                }
                if (card2.displayCard[0].value == value + 4)
                {
                    value4 = true;
                }
            }

            if (value > highestStraight && value1 && value2 && value3 && value4)
            {
                highestStraight = value + 4;
            }
        }

        foreach (DisplayCard card in playedCards) //Checks for Flush
        {
            string suit = card.displayCard[0].suit;
            int occurences = 0;
            foreach (DisplayCard card2 in playedCards)
            {
                if (card2.displayCard[0].suit == suit)
                {
                    occurences++;
                }
            }
            if (occurences >= 5)
            {
                flush = true;
            }
        }







        //Calculates Opponent's Zone
        List<OppDisplayCard> oppPlayedCards = oppZone.GetComponent<OppZone>().GetPlayedCards();

        foreach (OppDisplayCard card in oppPlayedCards) //Checks Highest Card
        {
            if (card.displayCard[0].value > OhighestValue)
            {
                OhighestValue = card.displayCard[0].value;
            }
        }

        foreach (OppDisplayCard card in oppPlayedCards) //Checks for pairs, trios, quads, and quints
        {
            int value = card.displayCard[0].value;
            int occurences = 0;
            {
                foreach (OppDisplayCard card2 in oppPlayedCards)
                {
                    if (card2.displayCard[0].value == value)
                    {
                        occurences++;
                    }
                }
            }

            if (value > OhighestPair && occurences >= 2)
            {
                OhighestPair = value;
                OpairList.Add(value);
            }

            if (value > OhighestTrio && occurences >= 3)
            {
                OhighestTrio = value;
                foreach (int pair in OpairList)
                {
                    if (value != pair)
                    {
                        OfullHouse = true;
                    }
                }
            }

            if (value > OhighestQuad && occurences >= 4)
            {
                OhighestQuad = value;
            }

            if (value > OhighestQuint && occurences >= 5)
            {
                OhighestQuint = value;
            }

        }

        foreach (OppDisplayCard card in oppPlayedCards) //Checks for straight
        {
            int value = card.displayCard[0].value;
            bool value1 = false;
            bool value2 = false;
            bool value3 = false;
            bool value4 = false;
            foreach (OppDisplayCard card2 in oppPlayedCards)
            {
                if (card2.displayCard[0].value == value + 1)
                {
                    value1 = true;
                }
                if (card2.displayCard[0].value == value + 2)
                {
                    value2 = true;
                }
                if (card2.displayCard[0].value == value + 3)
                {
                    value3 = true;
                }
                if (card2.displayCard[0].value == value + 4)
                {
                    value4 = true;
                }
            }

            if (value > OhighestStraight && value1 && value2 && value3 && value4)
            {
                OhighestStraight = value + 4;
            }
        }

        foreach (OppDisplayCard card in oppPlayedCards) //Checks for Flush
        {
            string suit = card.displayCard[0].suit;
            int occurences = 0;
            foreach (OppDisplayCard card2 in oppPlayedCards)
            {
                if (card2.displayCard[0].suit == suit)
                {
                    occurences++;
                }
            }
            if (occurences >= 5)
            {
                Oflush = true;
            }
        }






        if (highestQuint > OhighestQuint)
        {
            PlayerWins = true;
            endText.text = "You won with Five of a Kind!";
        } else if (flush && highestStraight > 0 && (!Oflush || highestStraight > OhighestStraight))
        {
            PlayerWins = true;

            endText.text = "You won with a Straight Flush!";
        } else if (highestQuad > OhighestQuad)
        {
            PlayerWins = true;

            endText.text = "You won with Four of a Kind!";
        } else if (fullHouse && (!OfullHouse || OhighestTrio < highestTrio))  {

            PlayerWins = true;

            endText.text = "You won with a Full House!";
        } else if (flush && (!Oflush || highestValue > OhighestValue))
        {
            PlayerWins = true;

            endText.text = "You won with a Flush!";
        } else if (highestStraight > OhighestStraight)
        {
            PlayerWins = true;

            endText.text = "You won with a Straight!";
        } else if (highestTrio > OhighestTrio)
        {
            PlayerWins = true;

            endText.text = "You won with Three of a Kind!";
        } else if (highestPair >  OhighestPair)
        {
            PlayerWins = true;

            endText.text = "You won with a Pair!";
        } else if (highestValue > OhighestValue)
        {
            PlayerWins = true;

            endText.text = "You won with a High Card!!";
        } else
        {
            PlayerWins = false;

            endText.text = "You lost ):";
        }

        endScreen.SetActive(true);
        if (PlayerWins) {
        }

    }

    public void LockIn()
    {
        lockInTurn = yourTurn;
        countdown = true;
        lockInButton.SetActive(false);
    }
}
