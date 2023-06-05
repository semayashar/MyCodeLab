import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        List<Client> clients = new ArrayList<>();
        List<Company> companies = new ArrayList<>();
        List<Product> products = new ArrayList<>();

        int clientIdCounter = 1;
        int companyIdCounter = 1;
        int productIdCounter = 1;

        Scanner scanner = new Scanner(System.in);

        while (true) {
            System.out.println("Select an option:");
            System.out.println("1. Add a client");
            System.out.println("2. Add a company");
            System.out.println("3. Add a product");
            System.out.println("4. Search for a client by ID");
            System.out.println("5. Search for a company by ID");
            System.out.println("6. Search for a product by ID");
            System.out.println("7. Print all clients");
            System.out.println("8. Print all companies");
            System.out.println("9. Print all products");
            System.out.println("0. Exit");

            System.out.print("Enter an option: ");
            int option = scanner.nextInt();
            scanner.nextLine();

            if (option == 0) {
                System.out.println("Exiting...");
                break;
            }

            switch (option) {
                case 1:
                    Client client = Client.create();
                    clients.add(client);
                    System.out.println("Client added successfully.");
                    break;
                case 2:
                    Company company = Company.create();
                    companies.add(company);
                    System.out.println("Company added successfully.");
                    break;
                case 3:
                    System.out.print("Enter the company ID for the product: ");
                    String companyId = scanner.nextLine();
                    Company selectedCompany = searchCompanyById(companyId, companies);
                    if (selectedCompany != null) {
                        Product product = Product.create(selectedCompany);
                        products.add(product);
                        selectedCompany.addProduct(product);
                        System.out.println("Product added successfully.");
                    } else {
                        System.out.println("Company not found.");
                    }
                    break;
                case 4:
                    System.out.print("Enter the client ID: ");
                    String clientId = scanner.nextLine();
                    Client selectedClient = searchClientById(clientId, clients);
                    if (selectedClient != null) {
                        selectedClient.showInformation();
                    } else {
                        System.out.println("Client not found.");
                    }
                    break;
                case 5:
                    System.out.print("Enter the company ID: ");
                    String selectedCompanyId = scanner.nextLine();
                    Company selectedCompanyById = searchCompanyById(selectedCompanyId, companies);
                    if (selectedCompanyById != null) {
                        selectedCompanyById.showInformation();
                    } else {
                        System.out.println("Company not found.");
                    }
                    break;
                case 6:
                    System.out.print("Enter the product ID: ");
                    String productId = scanner.nextLine();
                    Product selectedProduct = searchProductById(productId, products);
                    if (selectedProduct != null) {
                        selectedProduct.showInformation();
                    } else {
                        System.out.println("Product not found.");
                    }
                    break;
                case 7:
                    printAllClients(clients);
                    break;
                case 8:
                    printAllCompanies(companies);
                    break;
                case 9:
                    printAllProducts(products);
                    break;
                default:
                    System.out.println("Invalid option. Please try again.");
                    break;
            }

            System.out.println();
        }
    }

    private static Client searchClientById(String id, List<Client> clients) {
        for (Client client : clients) {
            if (client.getId().equals(id)) {
                return client;
            }
        }
        return null;
    }

    private static Company searchCompanyById(String id, List<Company> companies) {
        for (Company company : companies) {
            if (company.getId().equals(id)) {
                return company;
            }
        }
        return null;
    }

    private static Product searchProductById(String id, List<Product> products) {
        for (Product product : products) {
            if (product.getNumber().equals(id)) {
                return product;
            }
        }
        return null;
    }

    private static void printAllClients(List<Client> clients) {
        System.out.println("All Clients:");
        for (Client client : clients) {
            client.showInformation();
            System.out.println();
        }
    }

    private static void printAllCompanies(List<Company> companies) {
        System.out.println("All Companies:");
        for (Company company : companies) {
            company.showInformation();
            System.out.println();
        }
    }

    private static void printAllProducts(List<Product> products) {
        System.out.println("All Products:");
        for (Product product : products) {
            product.showInformation();
            System.out.println();
        }
    }
}
