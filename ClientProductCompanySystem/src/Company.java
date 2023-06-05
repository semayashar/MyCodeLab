import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Company {
    private static int nextId = 1;

    private String id;
    private String name;
    private int yearOfOpening;
    private String location;
    private List<Product> products;

    public Company() {
        this.id = generateId();
        this.name = "";
        this.yearOfOpening = -1;
        this.location = "";
        this.products = new ArrayList<>();
    }

    public Company(String name, int yearOfOpening, String location) {
        this.id = generateId();
        this.name = name;
        this.yearOfOpening = yearOfOpening;
        this.location = location;
        this.products = new ArrayList<>();
    }

    public static Company create() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Company Name: ");
        String name = scanner.nextLine();
        System.out.print("Year of Opening: ");
        int yearOfOpening = scanner.nextInt();
        scanner.nextLine();
        System.out.print("Location: ");
        String location = scanner.nextLine();

        return new Company(name, yearOfOpening, location);
    }

    public void addProduct(Product product) {
        products.add(product);
    }

    public void showInformation() {
        System.out.println("Company ID: " + this.id);
        System.out.println("Name: " + this.name);
        System.out.println("Year of Opening: " + this.yearOfOpening);
        System.out.println("Location: " + this.location);
        System.out.println("Products: ");
        for (Product product : products) {
            System.out.println("- " + product.getName() + ", Number: " + product.getNumber() + ", Price: " + product.getPrice());
        }
    }

    private static String generateId() {
        return String.valueOf(nextId++);
    }

    public String getId() {
        return id;
    }
}
