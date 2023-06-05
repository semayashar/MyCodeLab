import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Client {
    private String id;
    private String firstName;
    private String lastName;
    private String dateOfBirth;
    private String personalId;
    private String passportNumber;
    private String placeOfBirth;
    private String currentResidence;
    private List<Product> purchasedProducts;

    public Client() {
        this.id = "-1";
        this.firstName = "";
        this.lastName = "";
        this.dateOfBirth = "";
        this.personalId = "";
        this.passportNumber = "";
        this.placeOfBirth = "";
        this.currentResidence = "";
        this.purchasedProducts = new ArrayList<>();
    }

    public Client(String id, String firstName, String lastName, String dateOfBirth, String personalId,
                    String passportNumber, String placeOfBirth, String currentResidence) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.personalId = personalId;
        this.passportNumber = passportNumber;
        this.placeOfBirth = placeOfBirth;
        this.currentResidence = currentResidence;
        this.purchasedProducts = new ArrayList<>();
    }

    public static Client create() {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Client ID: ");
        String id = scanner.nextLine();
        System.out.print("First Name: ");
        String firstName = scanner.nextLine();
        System.out.print("Last Name: ");
        String lastName = scanner.nextLine();
        System.out.print("Date of Birth: ");
        String dateOfBirth = scanner.nextLine();
        System.out.print("Personal ID: ");
        String personalId = scanner.nextLine();
        System.out.print("Passport Number: ");
        String passportNumber = scanner.nextLine();
        System.out.print("Place of Birth: ");
        String placeOfBirth = scanner.nextLine();
        System.out.print("Current Residence: ");
        String currentResidence = scanner.nextLine();

        return new Client(id, firstName, lastName, dateOfBirth, personalId, passportNumber, placeOfBirth, currentResidence);
    }

    public void addPurchasedProduct(Product product) {
        purchasedProducts.add(product);
    }

    public void showInformation() {
        System.out.println("Client ID: " + id);
        System.out.println("Name: " + firstName + " " + lastName);
        System.out.println("Date of Birth: " + dateOfBirth);
        System.out.println("Personal ID: " + personalId);
        System.out.println("Passport Number: " + passportNumber);
        System.out.println("Place of Birth: " + placeOfBirth);
        System.out.println("Current Residence: " + currentResidence);
        System.out.println("Purchased Products: ");
        for (Product product : purchasedProducts) {
            System.out.println("- " + product.getName() + ", Count: " + product.getCount() + ", Price: " + product.getPrice());
        }
    }
    public static void searchById(String id, List<Client> clients) {
        for (Client client : clients) {
            if (client.id.equals(id)) {
                client.showInformation();
                return;
            }
        }
        System.out.println("Client with ID " + id + " not found.");
    }
}
