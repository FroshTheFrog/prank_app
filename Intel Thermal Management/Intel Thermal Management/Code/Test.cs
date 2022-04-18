using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_Thermal_Management.Code
{
    public class Test
    {
        //A list of questions that the user will have to answer
        public List<Question> TheQuetions;


        public Test()
        {


            TheQuetions = new List<Question>();
            
            // TheQuetions.Add(new Question("Quetion", "a1", "a2", "a3", "answer"));

            TheQuetions.Add(new Question("What is 5!?", "25", "FIVE!", "15", "120"));

            TheQuetions.Add(new Question("Who said: \"I will say then that I am not, nor ever have been, in favor of " +
                "bringing about in any way the social and political equality of the white and black races\"?",
                "Martin Luther kings", "Malcolm X", "Thomas Jefferson", "Abraham Lincoln"));

            TheQuetions.Add(new Question("What is the world's biggest living thing?", "Blue Whale", "Elephant", "Blue People", "Honey Fungus"));

            TheQuetions.Add(new Question("Who is the prime minister of england?", "Justin Trudeau", "Sadiq Khan", "David Cameron", "Theresa May"));

            TheQuetions.Add(new Question("What number soliloquy in Hamlet started with the opening phrase: \"To be, or not to be...\"?", "1st", "3ed", "5th", "4th"));

            TheQuetions.Add(new Question("What year did Saudi Arabia outlaw slavery?", "1993", "1849", "1931", "1962"));

            TheQuetions.Add(new Question("Why is the sky blue?", "That's the color of air", "It's the ocean's reflect", "Blue People", "Blue light scatters much  more than other light waves"));

            TheQuetions.Add(new Question("Why do we have the seasons", "Blue People", "Global Warming", "The earth travels closer and further from the sun in an ellipss", "The earth's tilt"));

            TheQuetions.Add(new Question("What color does green and red light make?", "Purple", "Blue", "Red Green", "Yellow"));

            TheQuetions.Add(new Question("Is 0 even or odd?", "Both", "Neither", "Odd", "Even"));

            TheQuetions.Add(new Question("Is the AR-15 automatic?", "Yes", "Blue People", "No, but it's an assault rifle", "No"));

            TheQuetions.Add(new Question("What formula can be easily used to prove Sin^2 + Cos^2 = 1?", "The Law of Sines", "e^(i*pi) = -1", "The Law of Cosines", "The Pythagorean Theorem"));

            TheQuetions.Add(new Question("Who wrote Brave New World?", "Philip K. Dick", "Blue People", "George Orwell", "Aldous Huxley"));

            TheQuetions.Add(new Question("How did Ernest Hemingway die?", "Heart attack", "Leukemia", "Blue People", "Suicide by shotgun"));

            TheQuetions.Add(new Question("What book is this quote from? \"I could not become anything; neither good nor bad; neither a scoundrel nor an honest man; " +
                "neither a hero nor an insect. And now I am eking out my days in my corner, " +
                "taunting myself with the bitter and entirely useless consolation that an intelligent " +
                "man cannot seriously become anything, that only a fool can become something.\"?", "Beyond Good and Evil", "The Sun Also Rises", "Crime and Punishment", "Notes From the Underground"));

            TheQuetions.Add(new Question("According to Einstein, when an object is moving", "Time remains the same", 
                "It's time relative to the observer speeds up", "Time around it speeds up relative to it", "Time around it slows down relative to it"));

            TheQuetions.Add(new Question("Who was Trump's appointee to the supreme court?", "Ronny Jackson", "Steve Bannon", "Elena Kagan", "Neil Gorsuch"));

            TheQuetions.Add(new Question("What is the 4th Amendment?", "The right to trial by jury", "No quartering of soldiers", "Blue People", "No unlawful search and seizure"));

            TheQuetions.Add(new Question("FREE QUESTION!", "Not the answer", "Kind of the answer", "Blue People", "The answer"));

            TheQuetions.Add(new Question("Who owns Steam", "Activision", "Blizzard", "EA", "Valve"));

            TheQuetions.Add(new Question("What is 13^2", "156", "144", "420", "169"));

            TheQuetions.Add(new Question("Who said \"Your enemies are a reflection of yourself\"", "JFK", "Sun Tzu", "Martin Luther King", "No one. I made it up :)"));

            TheQuetions.Add(new Question("What day of the week is it?", DateTime.Now.AddDays(2).DayOfWeek.ToString(), DateTime.Now.AddDays(-1).DayOfWeek.ToString(), 
                DateTime.Now.AddDays(1).DayOfWeek.ToString(), DateTime.Now.DayOfWeek.ToString()));

            TheQuetions.Add(new Question("How many lines are here? (Not a trick question): |||||||||", "10", "11", "8", "9"));

            TheQuetions.Add(new Question("What color does mixing green and red PAINT make?", "Purple", "Blue", "Yellow", "Red Green"));

        }




    }
}
