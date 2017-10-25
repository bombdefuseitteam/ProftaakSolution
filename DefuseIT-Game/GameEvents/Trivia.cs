using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefuseIT_Game.GameEvents
{
    class Trivia
    {
        //Wie dit leest vraag zich vast af waarom dit leeg is, nou dit is het class bestand waar ik de uiteindelijke versie van trivia in zal zetten om het wat netter te houden :) :C
        /// <summary>
        /// Randomizer van de vraag
        /// </summary>
        internal static Random Randomizer = new Random();

        /// <summary>
        /// Question Template: Vraag, A, B, C, D, CorrectAntwoord
        /// </summary>
       internal static string[] Question1 = new string[] {
            "Uit welke 2 cijfers bestaat binaire code?", //Vraag
            "1 en 2", //A
            "0 en 1", //B
            "3 en 4", //C
            "5 en 6", //D
            "0 en 1"  //Antwoord
        };

        /// <summary>
        /// Question Template: Vraag, A, B, C, D, CorrectAntwoord
        /// </summary>
        internal static string[] Question2 = new string[] {
            "Wat krijg je als je mais verhit in een pan?",
            "Ontplofte mais",
            "Chips",
            "Warme mais",
            "Popcorn",
            "Popcorn"
        };

        /// <summary>
        /// Question Template: Vraag, A, B, C, D, CorrectAntwoord
        /// </summary>
        internal static string[] Question3 = new string[] {
            "Wat is de kook temperatuur van water?",
            "100 graden celcius",
            "110 graden celcius",
            "80 graden celcius",
            "90 graden celcius",
            "100 graden celcius"
        };

        /// <summary>
        /// I heard you like arrays so we put an array inside of your array
        /// </summary>
        internal static string[][] QuestionList = new string[][] { Question1, Question2, Question3 };


        /// <summary>
        /// Bombs Array
        /// [0] = Bomb1
        /// [1] = Bomb2
        /// [2] = Bomb3
        /// </summary>
        internal static bool[] Bombs = new bool[] { false, false, false };
    }
}
