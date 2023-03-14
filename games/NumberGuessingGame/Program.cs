// See https://aka.ms/new-console-template for more information
Random rand = new Random();
int answer = rand.Next(1,6);
int guess = 0;
int round = 3;
Console.WriteLine("Welcome to our Guessing Game!");
while(round > 0) {
    Console.WriteLine("Please guess a number between 1-5");
    Console.WriteLine($"Current round number is {round}");
    bool check = false;
    while(!check) {
        string temp = Console.ReadLine();
        check = int.TryParse(temp, out guess);
        if(!check) {
            Console.WriteLine("Please use a number, you just lost a round");
            round--;
            if (round == 0) {
                Console.WriteLine($"That was your last turn Game Over!");
                check = true;
                round = 0;
            }
        }
        else {
            if (guess > 5 || guess < 1) {
                Console.WriteLine($"Please chose another number between 1 and 5 you have lost 1 turn");
                guess = Convert.ToInt32(Console.ReadLine());
                round--;
            }
                Console.WriteLine($"Your guess is {guess}");
            if (answer == guess) {
                Console.WriteLine($"Your guess of {guess} was correct");
                round = 0;
            }
            else if (guess > answer) {
                Console.WriteLine($"Your guess of {guess} was too high");
                round--;
                if (round == 0) {
                    Console.WriteLine($"That was your last turn Game Over!");
                }
            }
            else {
                Console.WriteLine($"Your guess of {guess} was too low");
                round--;
                if (round == 0) {
                    Console.WriteLine($"That was your last turn Game Over!");
                }
            }
        }
    }

}
