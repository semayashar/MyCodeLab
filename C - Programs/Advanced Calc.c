#include <stdio.h>
#include <math.h>

double add(double num1, double num2) {
    return num1 + num2;
}

double subtract(double num1, double num2) {
    return num1 - num2;
}

double multiply(double num1, double num2) {
    return num1 * num2;
}

double divide(double num1, double num2) {
    return num1 / num2;
}

double power(double base, double exponent) {
    return pow(base, exponent);
}

double logarithm(double num, double base) {
    return log(num) / log(base);
}

double sine(double num) {
    return sin(num);
}

double cosine(double num) {
    return cos(num);
}

double tangent(double num) {
    return tan(num);
}

int main() {
    int choice;
    double num1, num2;
    double result;

    printf("Advanced Calculator\n");
    printf("1. Addition\n");
    printf("2. Subtraction\n");
    printf("3. Multiplication\n");
    printf("4. Division\n");
    printf("5. Power\n");
    printf("6. Logarithm\n");
    printf("7. Sine\n");
    printf("8. Cosine\n");
    printf("9. Tangent\n");
    printf("Select an operation (1-9): ");
    scanf("%d", &choice);

    switch (choice) {
        case 1:
            printf("Enter two numbers: ");
            scanf("%lf %lf", &num1, &num2);
            result = add(num1, num2);
            printf("Result: %.2lf\n", result);
            break;
        case 2:
            printf("Enter two numbers: ");
            scanf("%lf %lf", &num1, &num2);
            result = subtract(num1, num2);
            printf("Result: %.2lf\n", result);
            break;
        case 3:
            printf("Enter two numbers: ");
            scanf("%lf %lf", &num1, &num2);
            result = multiply(num1, num2);
            printf("Result: %.2lf\n", result);
            break;
        case 4:
            printf("Enter two numbers: ");
            scanf("%lf %lf", &num1, &num2);
            if (num2 != 0) {
                result = divide(num1, num2);
                printf("Result: %.2lf\n", result);
            } else {
                printf("Error: Division by zero is not allowed.\n");
            }
            break;
        case 5:
            printf("Enter base and exponent: ");
            scanf("%lf %lf", &num1, &num2);
            result = power(num1, num2);
            printf("Result: %.2lf\n", result);
            break;
        case 6:
            printf("Enter a number and base: ");
            scanf("%lf %lf", &num1, &num2);
            if (num1 > 0 && num2 > 0) {
                result = logarithm(num1, num2);
                printf("Result: %.2lf\n", result);
            } else {
                printf("Error: Invalid input for logarithm.\n");
            }
            break;
        case 7:
            printf("Enter an angle in radians: ");
            scanf("%lf", &num1);
            result = sine(num1);
            printf("Result: %.2lf\n", result);
            break;
        case 8:
            printf("Enter an angle in radians: ");
            scanf("%lf", &num1);
            result = cosine(num1);
            printf("Result: %.2lf\n", result);
            break;
        case 9:
            printf("Enter an angle in radians: ");
            scanf("%lf", &num1);
            result = tangent(num1);
            printf("Result: %.2lf\n", result);
            break;
        default:
            printf("Error: Invalid choice.\n");
            break;
    }

    return 0;
}
