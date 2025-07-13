#include <iostream>
#include <vector>
#include <string>
using namespace std;

class Atm {
private:
    int balance;
    int password;
    int counter;
    bool block;
public:
    Atm(int initialBalance, int pinCode)
        : balance(initialBalance), password(pinCode), counter(0), block(false) {}

    bool enter(int enteredPassword) {
        if (block) {
            cout << "ATM is locked!" << endl;
            return false;
        }

        if (enteredPassword == password) {
            cout << "Entered successfully!" << endl;
            return true;
        } else {
            cout << "Error: Incorrect password!" << endl;
            counter++;
            if (counter == 3) {
                block = true;
                cout << "Card is blocked due to too many wrong attempts." << endl;
            }
            return false;
        }
    }

    void checkBalance() {
        if (block) {
            cout << "Card is blocked!" << endl;
        } else {
            cout << "Balance is: " << balance << endl;
        }
    }

    void withdraw() {
        if (block) {
            cout << "Card is blocked!" << endl;
        } else {
            int amount;
            cout << "How much money do you want to withdraw?" << endl;
            cin >> amount;
            if (amount > balance) {
                cout << "You don't have enough money in your account!" << endl;
            } else {
                balance -= amount;
                cout << "You have withdrawn " << amount << ". New balance: " << balance << endl;
            }
        }
    }

    void deposit() {
        if (block) {
            cout << "Card is blocked!" << endl;
        } else {
            int amount;
            cout << "Enter the amount of money to deposit:" << endl;
            cin >> amount;
            if (amount > 0) {
                balance += amount;
                cout << "You have deposited " << amount << ". New balance: " << balance << endl;
            } else {
                cout << "Invalid deposit amount!" << endl;
            }
        }
    }
};

int main() {
    int otvet;
    cout << "Enter your Pin-code:" << endl;
    cin >> otvet;

    Atm acc(5000, 1234);

    if (acc.enter(otvet)) {  
        int choise;
        do {
            cout << "1 - Check balance" << endl;
            cout << "2 - Withdraw money" << endl;
            cout << "3 - Deposit money" << endl;
            cout << "4 - Exit" << endl;
            cout << "Enter 1/2/3/4: ";
            cin >> choise;

            switch (choise) {
                case 1:
                    acc.checkBalance();
                    break;
                case 2:
                    acc.withdraw();
                    break;
                case 3:
                    acc.deposit();
                    break;
                case 4:
                    cout << "Exiting..." << endl;
                    break;
                default:
                    cout << "Invalid choice. Try again." << endl;
            }
        } while (choise != 4);
    } else {
        cout << "Exiting..." << endl;
    }
    return 0;
}
