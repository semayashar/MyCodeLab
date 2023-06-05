import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Company {
    private String id;
    private String name;
    private int yearOfOpening;
    private String location;
    private List<Product> products;

    public Company() {
        this.id = "";
        this.name = "";
        this.yearOfOpening = -1;
        this.location = "";
        this.products = new ArrayList<>();
    }

    public Company(String id, String name, int yearOfOpening, String location) {
        this.id = id;
        this.name = name;
        this.yearOfOpening = yearOfOpening;
        this.location = location;
        this.products = new ArrayList<>();
    }

    public static Company create() {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Company ID: ");
        String id = scanner.nextLine();
        System.out.print("Company Name: ");
        String name = scanner.nextLine();
        System.out.print("Year of Opening: ");
        int yearOfOpening = scanner.nextInt();
        scanner.nextLine();
        System.out.print("Location: ");
        String location = scanner.nextLine();

        return new Company(id, name, yearOfOpening, location);
    }

    public static void searchById(String id, List<Company> companies) {
        for (Company company : companies) {
            if (company.id.equals(id)) {
                company.showInformation();
                return;
            }
        }
        System.out.println("Company with ID " + id + " not found.");
    }
    public void addProduct(Product product) {
        products.add(product);
    }

    public void showInformation() {
        System.out.println("Company ID: " + id);
        System.out.println("Name: " + name);
        System.out.println("Year of Opening: " + yearOfOpening);
        System.out.println("Location: " + location);
        System.out.println("Products: ");
        for (Product product : products) {
            System.out.println("- " + product.getName() + ", Number: " + product.getNumber() + ", Price: " + product.getPrice());
        }
    }
    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public int getYearOfOpening() {
        return yearOfOpening;
    }

    public String getLocation() {
        return location;
    }

    public List<Product> getProducts() {
        return products;
    }
}
