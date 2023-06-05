import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Client> clients = new ArrayList<>();
        List<Product> products = new ArrayList<>();
        List<Company> companies = new ArrayList<>();

        System.out.println("Welcome to the Program!");

        while (true) {
            System.out.println("\nWhat would you like to do?");
            System.out.println("1. Create a Client");
            System.out.println("2. Create a Product");
            System.out.println("3. Create a Company");
            System.out.println("4. Search for a Client by ID");
            System.out.println("5. Search for a Product by Number");
            System.out.println("6. Search for a Company by ID");
            System.out.println("0. Exit");

            System.out.print("Enter your choice: ");
            int choice = scanner.nextInt();
            scanner.nextLine(); // Consume newline character

            switch (choice) {
                case 1:
                    System.out.println("\nCreating a Client:");
                    Client client = Client.create();
                    clients.add(client);
                    System.out.println("Client created successfully!");
                    break;
                case 2:
                    System.out.println("\nCreating a Product:");
                    if (companies.isEmpty()) {
                        System.out.println("No companies available. Please create a company first.");
                        break;
                    }
                    Product product = Product.create(companies.get(0)); // Assume the first company in the list
                    products.add(product);
                    System.out.println("Product created successfully!");
                    break;
                case 3:
                    System.out.println("\nCreating a Company:");
                    Company company = Company.create();
                    companies.add(company);
                    System.out.println("Company created successfully!");
                    break;
                case 4:
                    System.out.println("\nSearching for a Client:");
                    System.out.print("Enter the Client ID: ");
                    String clientId = scanner.nextLine();
                    Client.searchById(clientId, clients);
                    break;
                case 5:
                    System.out.println("\nSearching for a Product:");
                    System.out.print("Enter the Product Number: ");
                    String productNumber = scanner.nextLine();
                    Product.searchById(productNumber, products);
                    break;
                case 6:
                    System.out.println("\nSearching for a Company:");
                    System.out.print("Enter the Company ID: ");
                    String companyId = scanner.nextLine();
                    Company.searchById(companyId, companies);
                    break;
                case 0:
                    System.out.println("Exiting the program...");
                    scanner.close();
                    System.exit(0);
                default:
                    System.out.println("Invalid choice. Please try again.");
            }
        }
    }
}
