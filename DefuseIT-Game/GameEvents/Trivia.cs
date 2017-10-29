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

        internal static string FixedSizeQuestion(string input)
        {
            string newline = input;
            string lines = string.Join(Environment.NewLine, newline.Split()
                .Select((word, index) => new { word, index })
                .GroupBy(x => x.index / 9)
                .Select(grp => string.Join(" ", grp.Select(x => x.word))));

            return newline.ToUpper();
        }

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

        internal static string[] Question4 = new string[] {
            "In welk gebouw bevind u zich?", //Vraag
            "R4", //A
            "R3", //B
            "R2", //C
            "R1", //D
            "R1"  //Antwoord
        };

        internal static string[] Question5 = new string[] {
            "Wat is de naam van deze robot?", //Vraag
            "Ontmantel Bot", //A
            "P1-Bot", //B
            "Defuse Bot", //C
            "R0b0t", //D
            "Defuse Bot"  //Antwoord
        };

        internal static string[] Question6 = new string[] {
            "Welke kleur krijg je als je rood en blauw mengt?", //Vraag
            "Groen", //A
            "Paars", //B
            "Oranje", //C
            "Zwart", //D
            "Paars"  //Antwoord
        };

        internal static string[] Question7 = new string[] {
            "Welke genre muziek wordt er normaal bij line-dancen gespeeld?", //Vraag
            "Country", //A
            "Rock", //B
            "Jazz", //C
            "Blues", //D
            "Country"  //Antwoord
        };

        internal static string[] Question8 = new string[] {
            "Waarvoor staat de F in de afkorting GFT?", //Vraag
            "Fluid", //A
            "Fruit", //B
            "Frisdrank", //C
            "Fax", //D
            "Fruit"  //Antwoord
        };

        internal static string[] Question9 = new string[] {
            "Met welke 2 cijfers begint een Nederlands mobiel telefoonnummer?", //Vraag
            "04", //A
            "05", //B
            "06", //C
            "07", //D
            "06"  //Antwoord
        };
       

        internal static string[] Question11 = new string[] {
            "Hoeveel dagen doet de aarde erover om 1 keer om de zon te draaien?", //Vraag
            "365", //A
            "364", //B
            "265", //C
            "264", //D
            "365"  //Antwoord
        };

        internal static string[] Question12 = new string[] {
            "Uit hoeveel semesters bestaat de opleiding 'HBO-ICT'", //Vraag
            "4", //A
            "8", //B
            "12", //C
            "6", //D
            "8"  //Antwoord
        };

        internal static string[] Question13 = new string[] {
            "Uit hoeveel velden bestaat een schaakbord?", //Vraag
            "42", //A
            "128", //B
            "64", //C
            "24", //D
            "64"  //Antwoord
        };

        internal static string[] Question14 = new string[] {
            "Waar ben je bang voor als je Arachnofobie hebt?", //Vraag
            "Naalden", //A
            "De dood", //B
            "Spinnen", //C
            "Hoogtes", //D
            "Spinnen"  //Antwoord
        };

        internal static string[] Question15 = new string[] {
            "Hoeveel versnellingen hebben de meeste auto's?", //Vraag
            "3", //A
            "6", //B
            "5", //C
            "0", //D
            "5"  //Antwoord
        };

        internal static string[] Question16 = new string[] {
            "Welk kleur is NIET te vinden in de vlag van Frankrijk?", //Vraag
            "Blauw", //A
            "Geel", //B
            "Wit", //C
            "Rood", //D
            "Geel"  //Antwoord
        };

        internal static string[] Question17 = new string[] {
            "Welk kleur is NIET te vinden in de vlag van Noorwegen?", //Vraag
            "Rood", //A
            "Blauw", //B
            "Wit", //C
            "Geel", //D
            "Geel"  //Antwoord
        };

        internal static string[] Question18 = new string[] {
            "Hoe wordt een tijdelijke stoornis van de hersenen genoemd?", //Vraag
            "Migraine", //A
            "Black-out", //B
            "Hoofdpijn", //C
            "Burnout", //D
            "Black-out"  //Antwoord
        };

        internal static string[] Question19 = new string[] {
            "Waarvoor zijn mensen bang met kynofobie?", //Vraag
            "Hoogtes", //A
            "Katten", //B
            "De dood", //C
            "Honden", //D
            "Honden"  //Antwoord
        };

        internal static string[] Question20 = new string[] {
            "Welke kleur heeft het poppetje in het logo van Android, //Vraag
            "Blauw", //A
            "Groen", //B
            "Rood", //C
            "Geel", //D
            "Groen"  //Antwoord
        };

        internal static string[] Question22 = new string[] {
            "Welk huishoudelijk apparaat is gemaakt om wind te genereren?", //Vraag
            "Afzuiging", //A
            "Airco", //B
            "Ventilator", //C
            "Stofzuiger", //D
            "Ventilator"  //Antwoord
        };

        internal static string[] Question23 = new string[] {
            "Hoe heet het houdige event waar DefuseIT zich begeeft?", //Vraag
            "P1-event", //A
            "P1-opdracht", //B
            "Event-P1", //C
            "Opdracht-P1", //D
            "P1-event"  //Antwoord
        };

       
        /// <summary>
        /// I heard you like arrays so we put an array inside of your array
        /// </summary>
        internal static string[][] QuestionList = new string[][] { Question1, Question2, Question3, Question4, Question5, Question6, Question7, Question8, Question9
        , Question11, Question12, Question13, Question14, Question15, Question16, Question17, Question18, Question19, Question20, Question22, Question23};

        internal static List<Array> PreviousQuestions = new List<Array>();


        /// <summary>
        /// Bombs Array
        /// [0] = Bomb1
        /// [1] = Bomb2
        /// [2] = Bomb3
        /// </summary>
        internal static bool[] Bombs = new bool[] { false, false, false };
    }
}
