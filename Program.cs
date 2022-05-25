using System;
using System.Collections.Generic;

namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
             // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
                1) John
                2) Paul
                3) George
                4) Ringo
            ",
                        4, 20
                    );

            Challenge phineasAndFerb = new Challenge(
                @"What is the name of Phineas's brother?
                1)Pherb
                2)Fern
                3)Ferb
                4)Milo Murphy
            ",3,20);

            Challenge bridgeOfDoom = new Challenge(
                @"What is your favorite color?
                1)Blue
                2)Blue..No, YELLOW!!!!
                3)5
            ",1,30);

            List<Challenge> allChallenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                phineasAndFerb,
                bridgeOfDoom
            };

            List<int> GetQuest(){
                List<int> selectedChallengeIndexes = new List<int>();
                while(selectedChallengeIndexes.Count < 5){
                    int random = new Random().Next(0, allChallenges.Count);
                    if(!selectedChallengeIndexes.Contains(random)){
                        selectedChallengeIndexes.Add(random);
                    }
                }
                return selectedChallengeIndexes;
            }

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            //Make a robe for the adventurer
            Robe adventurersRobe = new Robe(){
                Colors = new List<string>{"red", "blue", "green"},
                Length = 52
            };

            Hat adventurersHat = new Hat(){
                ShininessLevel = 10
            };


            // Make a new "Adventurer" object using the "Adventurer" class
            Console.WriteLine("What is your name Adventurer:");
            string advName = Console.ReadLine();
            Adventurer theAdventurer = new Adventurer(advName, adventurersRobe, adventurersHat);
            string userDescription = theAdventurer.GetDescription();
            Console.WriteLine(userDescription);

            //Initialze the Prize here after the Adventurer is created
            Prize questPrize = new Prize("One Gold Coin");

            bool doYouWantToContinue = true;
            while(doYouWantToContinue){
                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<int> selectedChallengeIndex = GetQuest();



                // Loop through all the challenges and subject the Adventurer to them
                foreach (int challengeIndex in selectedChallengeIndex)
                {
                    allChallenges[challengeIndex].RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                //This is where the Prize is displayed
                questPrize.ShowPrize(theAdventurer);

                //This section asks the adventurer if they want to play again
                Console.WriteLine("Do you want to Continue(y/n)");
                string contAnswer = Console.ReadLine();
                if(contAnswer == "n"){
                    doYouWantToContinue = false;
                }
            }
        }
    }
        
    
}
