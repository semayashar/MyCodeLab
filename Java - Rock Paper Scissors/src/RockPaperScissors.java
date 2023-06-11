import java.util.Random;
import java.util.Scanner;

public class RockPaperScissors {
    private static final int ROCK = 1;
    private static final int PAPER = 2;
    private static final int SCISSORS = 3;
    private static final String[] CHOICES = {"Rock", "Paper", "Scissors"};
    public static void playGame() {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        System.out.println("Welcome to Rock, Paper, Scissors!");
        System.out.println("1. Rock");
        System.out.println("2. Paper");
        System.out.println("3. Scissors");
        System.out.print("Enter your choice (1-3): ");
        int playerChoice = scanner.nextInt();

        if (playerChoice < 1 || playerChoice > 3) {
            System.out.println("Invalid choice. Please select a number between 1 and 3.");
            return;
        }

        int computerChoice = random.nextInt(3) + 1;

        System.out.println("You chose: " + CHOICES[playerChoice - 1]);
        System.out.println("Computer chose: " + CHOICES[computerChoice - 1]);

        if (playerChoice == computerChoice) {
            System.out.println("It's a tie!");
        } else if ((playerChoice == ROCK && computerChoice == SCISSORS)
                || (playerChoice == PAPER && computerChoice == ROCK)
                || (playerChoice == SCISSORS && computerChoice == PAPER)) {
            System.out.println("You win!");
        } else {
            System.out.println("Computer wins!");
        }

        scanner.close();
    }
}
