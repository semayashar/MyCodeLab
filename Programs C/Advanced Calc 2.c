#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <string.h>

#define STACK_SIZE 100

typedef struct {
    double data[STACK_SIZE];
    int top;
} Stack;

void push(Stack *s, double val) {
    if (s->top == STACK_SIZE - 1) {
        printf("Stack overflow!\n");
        exit(1);
    }
    s->data[++(s->top)] = val;
}

double pop(Stack *s) {
    if (s->top == -1) {
        printf("Stack underflow!\n");
        exit(1);
    }
    return s->data[(s->top)--];
}

double evaluate(char *expr) {
    Stack num_stack;
    num_stack.top = -1;

    Stack op_stack;
    op_stack.top = -1;

    for (int i = 0; expr[i] != '\0'; i++) {
        if (expr[i] == '(') {
            push(&op_stack, '(');
        } else if (expr[i] == ')') {
            while (op_stack.top >= 0 && op_stack.data[op_stack.top] != '('){
                char op = (char)pop(&op_stack);
                double num2 = pop(&num_stack);
                double num1 = pop(&num_stack);

                switch (op) {
                    case '+':
                        push(&num_stack, num1 + num2);
                        break;
                    case '-':
                        push(&num_stack, num1 - num2);
                        break;
                    case '*':
                        push(&num_stack, num1 * num2);
                        break;
                    case '/':
                        if (num2 == 0) {
                            printf("Error: Division by zero\n");
                            exit(1);
                        } else {
                            push(&num_stack, num1 / num2);
                            break;
                        }
                    case '^':
                        push(&num_stack, pow(num1, num2));
                        break;
                    case 's':
                        push(&num_stack, sqrt(num2));
                        break;
                }
            }
            if (op_stack.top >= 0 && op_stack.data[op_stack.top] == '(') {
                pop(&op_stack);
            } else {
                printf("Error: Mismatched parentheses\n");
                exit(1);
            }
        } else if (expr[i] == '+' || expr[i] == '-' ||
                   expr[i] == '*' || expr[i] == '/' ||
                   expr[i] == '^' || expr[i] == 's') {
            while (op_stack.top >= 0 && ((op_stack.data[op_stack.top] != '(' && op_stack.data[op_stack.top] != 's') || (op_stack.data[op_stack.top] == 's' && expr[i] == 's'))) {
                char op = (char)pop(&op_stack);
                double num2 = pop(&num_stack);
                double num1 = pop(&num_stack);

                switch (op) {
                    case '+':
                        push(&num_stack, num1 + num2);
                        break;
                    case '-':
                        push(&num_stack, num1 - num2);
                        break;
                    case '*':
                        push(&num_stack, num1 * num2);
                        break;
                    case '/':
                        if (num2 == 0) {
                            printf("Error: Division by zero\n");
                            exit(1);
                        } else {
                            push(&num_stack, num1 / num2);
                            break;
                        }
                    case '^':
                        push(&num_stack, pow(num1, num2));
                        break;
                    case 's':
                        push(&num_stack, sqrt(num2));
                        break;
                }
            }
            if (expr[i] == 's') {
                push(&op_stack, 's');
            } else {
                push(&op_stack, expr[i]);
            }
        } else if (expr[i] >= '0' && expr[i] <= '9') {
            double num = 0.0;
            int decimal_places = 0;

            while (expr[i] >= '0' && expr[i] <= '9' || expr[i] == '.') {
                if (expr[i] == '.') {
                    decimal_places = 1;
                } else if (decimal_places > 0) {
                    num += (expr[i] - '0') / pow(10, decimal_places++);
                } else {
                    num = num * 10 + (expr[i] - '0');
                }
                i++;
            }
            push(&num_stack, num);
            i--;
        } else {
            printf("Error: Invalid character '%c'\n", expr[i]);
            exit(1);
        }
    }
    while (op_stack.top >= 0) {
        char op = (char)pop(&op_stack);
        double num2 = pop(&num_stack);
        double num1 = pop(&num_stack);

        switch (op) {
            case '+':
                push(&num_stack, num1 + num2);
                break;
            case '-':
                push(&num_stack, num1 - num2);
                break;
            case '*':
                push(&num_stack, num1 * num2);
                break;
            case '/':
                if (num2 == 0) {
                    printf("Error: Division by zero\n");
                    exit(1);
                } else {
                    push(&num_stack, num1 / num2);
                    break;
                }
            case '^':
                push(&num_stack, pow(num1, num2));
                break;
            case 's':
                push(&num_stack, sqrt(num2));
                break;
        }
    }
    return pop(&num_stack);
}

int main() {
    printf("Calculator Program\n");
    printf("Instructions:\n");
    printf("  - Enter an arithmetic expression using parentheses, addition, subtraction,\n");
    printf("    multiplication, division, exponentiation, and square root operations.\n");
    printf("  - Expressions should only contain digits, operators, parentheses, and spaces.\n");
    printf("  - Example: (2 * 3) / 2 + 4\n\n");
    printf("Enter an arithmetic expression: ");

    char expr[100];
    fgets(expr, 100, stdin);
    expr[strcspn(expr, "\n")] = '\0'; // remove newline character

    double result = evaluate(expr);
    printf("Result: %.2lf\n", result);

    return 0;
}
