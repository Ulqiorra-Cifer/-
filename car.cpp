#include <iostream>
#include <vector>
#include <string>

class Car {
private:
    std::string brand; 
    std::string model; 
    int year;           

public:
    Car(const std::string& brand, const std::string& model, int year) 
        : brand(brand), model(model), year(year) {}

    ~Car() {
        std::cout << "Car " << brand << " " << model << " destroyed." << std::endl;
    }

    void displayInfo() const {
        std::cout << "Brand: " << brand << ", Model: " << model << ", Year: " << year << std::endl;
    }
};

int main() {

    std::vector<Car*> cars;

    cars.push_back(new Car("Toyota", "Corolla", 2020));
    cars.push_back(new Car("Honda", "Civic", 2021));
    cars.push_back(new Car("Ford", "Focus", 2022));

    for (auto car : cars) {
        car->displayInfo();
    }

    for (auto car : cars) {
        delete car;
    }

    return 0;
}
