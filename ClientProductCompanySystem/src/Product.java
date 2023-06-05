import java.util.List;
import java.util.Scanner;

public class Product {
    private String number;
    private String name;
    private int count;
    private double price;
    private Company company;

    public Product() {
        this.number = "";
        this.name = "";
        this.count = 0;
        this.price = 0;
        this.company = new Company();
    }

    public Product(String number, String name, int count, double price, Company company) {
        this.number = number;
        this.name = name;
        this.count = count;
        this.price = price;
        this.company = company;
    }

    public static Product create(Company company) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Product Number: ");
        String number = scanner.nextLine();
        System.out.print("Product Name: ");
        String name = scanner.nextLine();
        System.out.print("Product Count: ");
        int count = scanner.nextInt();
        System.out.print("Product Price: ");
        double price = scanner.nextDouble();
        scanner.nextLine();

        return new Product(number, name, count, price, company);
    }

    public static void searchById(String id, List<Product> products) {
        for (Product product : products) {
            if (product.number.equals(id)) {
                System.out.println("Product Number: " + product.getNumber());
                System.out.println("Product Name: " + product.getName());
                System.out.println("Product Count: " + product.getCount());
                System.out.println("Product Price: " + product.getPrice());
                System.out.println("Company: " + product.getCompany().getName());
                return;
            }
        }
        System.out.println("Product with Number " + id + " not found.");
    }

    public String getNumber() {
        return number;
    }

    public String getName() {
        return name;
    }

    public int getCount() {
        return count;
    }

    public double getPrice() {
        return price;
    }

    public Company getCompany() {
        return company;
    }
}
