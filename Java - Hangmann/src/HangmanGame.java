import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class HangmanGame {
    private static final String[] WORDS = {"apple", "banana", "orange", "grape", "watermelon", "strawberry", "pineapple"};
    private static final int MAX_ATTEMPTS = 6;
    private static final char HIDDEN_CHAR = '_';

    private String word;
    private List<Character> guessedLetters;
    private int attempts;

    public HangmanGame() {
        Random random = new Random();
        word = WORDS[random.nextInt(WORDS.length)];
        guessedLetters = new ArrayList<>();
        attempts = 0;
    }

    public void play() {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Welcome to Hangman!");
        System.out.println("Guess the hidden word.");

        while (true) {
            System.out.println();
            System.out.println("Attempts remaining: " + (MAX_ATTEMPTS - attempts));
            displayWordProgress();

            System.out.print("Enter your guess: ");
            String input = scanner.nextLine().toLowerCase();

            if (input.length() != 1 || !Character.isLetter(input.charAt(0))) {
                System.out.println("Invalid input. Please enter a single letter.");
                continue;
            }

            char guess = input.charAt(0);

            if (guessedLetters.contains(guess)) {
                System.out.println("You already guessed that letter. Try again.");
                continue;
            }

            guessedLetters.add(guess);

            if (word.indexOf(guess) >= 0) {
                System.out.println("Correct guess!");
                if (isWordGuessed()) {
                    System.out.println("Congratulations! You guessed the word: " + word);
                    break;
                }
            } else {
                System.out.println("Incorrect guess.");
                attempts++;
                if (attempts >= MAX_ATTEMPTS) {
                    System.out.println("Game over! The word was: " + word);
                    break;
                }
            }
        }

        scanner.close();
    }

    private void displayWordProgress() {
        for (int i = 0; i < word.length(); i++) {
            char c = word.charAt(i);
            if (guessedLetters.contains(c)) {
                System.out.print(c);
            } else {
                System.out.print(HIDDEN_CHAR);
            }
            System.out.print(" ");
        }
        System.out.println();
    }

    private boolean isWordGuessed() {
        for (int i = 0; i < word.length(); i++) {
            char c = word.charAt(i);
            if (!guessedLetters.contains(c)) {
                return false;
            }
        }
        return true;
    }
}