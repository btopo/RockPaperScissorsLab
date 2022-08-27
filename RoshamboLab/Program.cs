namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors the game where you throw what you know! ");
            HumanPlayer humanPlayer = new HumanPlayer();
            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.WriteLine(" Would you like to play against RockLee or MarlonRando?");
                string opponent = Console.ReadLine().ToLower().Trim();

                if (opponent == "RockLee" || opponent == "r")
                {
                    RockPlayer rockoppenent = new RockPlayer();
                    humanPlayer.PlayerRockPlayer(humanPlayer, rockoppenent);

                }
                else if (opponent == "MarlonRando" || opponent == "m" || opponent.Contains("marlon"))
                {
                    RandomPlayer randomOpponent = new RandomPlayer();
                    humanPlayer.PlayRandomPlayer(humanPlayer, randomOpponent);
                }
                else
                {
                    Console.WriteLine("not an option");
                }
                Console.WriteLine("You won" + humanPlayer.Wins + "time(s)");
                Console.WriteLine("You lost" + humanPlayer.Loses + "time(s)");

                Console.WriteLine(" would you like to play again? Enter yes or no");
                string getContinue = Console.ReadLine();
                if (getContinue == "yes" || getContinue == "y")
                {
                    keepPlaying = true;
                }
                else if (getContinue == "no" || getContinue == "n")
                {
                    break;
                }
            }
            

        }
        public enum Roshambo
        {
            rock,
            paper,
            scissors
        }
        public abstract class Player
        {
            public string Name { get; set; }
            public Roshambo RPS { get; set; }
            public int Wins { get; set; }
            public int Loses { get; set; }

            public abstract Roshambo GenerateRoshambo();


        }

        public class RockPlayer : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                return Roshambo.rock;
            }
        }
        public class RandomPlayer : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                Random rnd = new Random();
                int number = rnd.Next(3);
                RPS = (Roshambo)number;
                return RPS;

            }
        }

        public class HumanPlayer : Player
        {
            public HumanPlayer()
            {
                Console.WriteLine(" Enter your name");
                Name = Console.ReadLine();
            }
            public override Roshambo GenerateRoshambo()
            {
                Console.WriteLine("Enter your roshambo choice");
                string input = Console.ReadLine();

                if (input.ToLower().Trim() == "rock" || input.ToLower().Trim() == "r")
                {
                    RPS = Roshambo.rock;
                    return RPS;
                }
                else if (input.ToLower().Trim() == "paper" || input.ToLower().Trim() == "p")
                {
                    RPS = Roshambo.paper;
                }
                else if (input.ToLower().Trim() == "scissors" || input.ToLower().Trim() == "s")
                {
                    RPS = Roshambo.scissors;
                }
                else
                {
                    Console.WriteLine("Exception: Wrong input");
                }
                return RPS;
            }
            public void PlayRandomPlayer(HumanPlayer humanPlayer, RandomPlayer opponent)
            {
                string yourRPS = humanPlayer.GenerateRoshambo().ToString();
                string opponentRPS = opponent.GenerateRoshambo().ToString();
                if (yourRPS == opponentRPS)
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($" Opponent Played {opponentRPS}");
                    Console.WriteLine("draw!");
                }
                else if (yourRPS == "rock" && opponentRPS == "scissors" || yourRPS == "scissors" && opponentRPS == "paper" || yourRPS == "paper" && opponentRPS == "rock")
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($" Opponent Played {opponentRPS}");
                    Console.WriteLine("You Win!");
                    humanPlayer.Wins++;
                }
                else
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($" Opponent Played {opponentRPS}");
                    Console.WriteLine("You lose!");
                    humanPlayer.Loses++;
                }
            }

            public void PlayerRockPlayer(HumanPlayer humanPlayer, RockPlayer RockLee)
            {
                string yourRPS = humanPlayer.GenerateRoshambo().ToString();
                string opponentRPS = RockLee.GenerateRoshambo().ToString();
                if (yourRPS == opponentRPS)
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($" Opponent Played {opponentRPS}");
                    Console.WriteLine("Draw!");
                }
                else if (yourRPS == "paper")
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($" Opponent Played {opponentRPS}");
                    Console.WriteLine("You win!");
                    humanPlayer.Wins++;
                }
                else if (yourRPS == "scissors")
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($" Opponent Played {opponentRPS}");
                    Console.WriteLine("You lose!");
                    humanPlayer.Loses++;
                }

                

            }
        }
    }
}













