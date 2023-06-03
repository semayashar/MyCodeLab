#include <iostream>
#include <vector>
using namespace std;

// Constants
const int GRID_SIZE = 9;
const int SUBGRID_SIZE = 3;
const int EMPTY_CELL = 0;

// Function to print the Sudoku grid
void printGrid(const vector<vector<int>>& grid) {
    for (int i = 0; i < GRID_SIZE; ++i) {
        for (int j = 0; j < GRID_SIZE; ++j) {
            cout << grid[i][j] << " ";
            if ((j + 1) % SUBGRID_SIZE == 0 && j != GRID_SIZE - 1) {
                cout << "  ";
            }
        }
        cout << endl;
        if ((i + 1) % SUBGRID_SIZE == 0 && i != GRID_SIZE - 1) {
            cout << endl;
        }
    }
}

// Function to check if a value is safe to place in a cell
bool isSafe(const vector<vector<int>>& grid, int row, int col, int value) {
    // Check row
    for (int j = 0; j < GRID_SIZE; ++j) {
        if (grid[row][j] == value) {
            return false;
        }
    }

    // Check column
    for (int i = 0; i < GRID_SIZE; ++i) {
        if (grid[i][col] == value) {
            return false;
        }
    }

    // Check subgrid
    int subgridStartRow = (row / SUBGRID_SIZE) * SUBGRID_SIZE;
    int subgridStartCol = (col / SUBGRID_SIZE) * SUBGRID_SIZE;
    for (int i = 0; i < SUBGRID_SIZE; ++i) {
        for (int j = 0; j < SUBGRID_SIZE; ++j) {
            if (grid[subgridStartRow + i][subgridStartCol + j] == value) {
                return false;
            }
        }
    }

    return true;  // Value can be placed safely
}

// Function to solve the Sudoku grid using backtracking
bool solveSudoku(vector<vector<int>>& grid) {
    for (int row = 0; row < GRID_SIZE; ++row) {
        for (int col = 0; col < GRID_SIZE; ++col) {
            if (grid[row][col] == EMPTY_CELL) {
                for (int value = 1; value <= GRID_SIZE; ++value) {
                    if (isSafe(grid, row, col, value)) {
                        grid[row][col] = value;
                        if (solveSudoku(grid)) {
                            return true;  // Solution found
                        }
                        grid[row][col] = EMPTY_CELL;  // Backtrack
                    }
                }
                return false;  // No valid value found, backtrack
            }
        }
    }
    return true;  // Grid solved
}

// Function to input the Sudoku grid from the user
void inputGrid(vector<vector<int>>& grid) {
    cout << "Enter the Sudoku grid (" << GRID_SIZE << "x" << GRID_SIZE << "):" << endl;
    for (int i = 0; i < GRID_SIZE; ++i) {
        for (int j = 0; j < GRID_SIZE; ++j) {
            cin >> grid[i][j];
        }
    }
}

int main() {
    vector<vector<int>> grid(GRID_SIZE, vector<int>(GRID_SIZE));

    inputGrid(grid);

    system("cls");
    
    cout << "\tANSWERS\nSudoku Grid (Before solving):" << endl;
    printGrid(grid);
    cout << endl;

    if (solveSudoku(grid)) {
        cout << "Sudoku Grid (After solving):" << endl;
        printGrid(grid);
    }
    else {
        cout << "No solution exists for the Sudoku grid." << endl;
    }

    return 0;
}
