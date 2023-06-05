import java.util.Scanner;

public class Product {
    private static int nextId = 1;

    private String number;
    private String name;
    private int count;
    private double price;
    private Company company;

    public Product() {
        this.number = generateNumber();
        this.name = "";
        this.count = 0;
        this.price = 0;
        this.company = new Company();
    }

    public Product(String name, int count, double price, Company company) {
        this.number = generateNumber();
        this.name = name;
        this.count = count;
        this.price = price;
        this.company = company;
    }

    public void showInformation() {
        System.out.println("Product ID: " + getNumber());
        System.out.println("Product Name: " + getName());
        System.out.println("Product Price: " + getPrice());
        System.out.println("Product Count: " + getCount());
        System.out.println("Product Company: " + getCompany());
    }

    public static Product create(Company company) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Product Name: ");
        String name = scanner.nextLine();
        System.out.print("Product Count: ");
        int count = scanner.nextInt();
        System.out.print("Product Price: ");
        double price = scanner.nextDouble();
        scanner.nextLine();

        return new Product(name, count, price, company);
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

    private static String generateNumber() {
        return String.valueOf(nextId++);
    }
}
