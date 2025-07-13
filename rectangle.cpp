#include <iostream>
using namespace std;

class Rectangle {
private:
    double width, height;  // Ширина и высота прямоугольника

public:
    // Конструктор по умолчанию
    Rectangle() : width(1), height(1) {
        cout << "Rectangle created: width = " << width << ", height = " << height << endl;
    }

    // Конструктор с параметрами
    Rectangle(double w, double h) : width(w), height(h) {
        cout << "Rectangle created: width = " << width << ", height = " << height << endl;
    }

    // Метод для вычисления площади
    double area() const {
        return width * height;
    }

    // Метод для вычисления периметра
    double perimeter() const {
        return 2 * (width + height);
    }

    // Деструктор
    ~Rectangle() {
        cout << "Rectangle destroyed: width = " << width << ", height = " << height << endl;
    }
};

int main() {
    // Создание объектов с разными конструкторами
    Rectangle r1;             // Конструктор по умолчанию
    Rectangle r2(5.0, 3.0);   // Конструктор с параметрами

    // Вывод площади и периметра
    cout << "Area of r1: " << r1.area() << endl;
    cout << "Perimeter of r1: " << r1.perimeter() << endl;

    cout << "Area of r2: " << r2.area() << endl;
    cout << "Perimeter of r2: " << r2.perimeter() << endl;

    // Массив объектов Rectangle
    Rectangle rectangles[2] = {
        Rectangle(4.0, 6.0),
        Rectangle(7.5, 2.5)
    };

    // Вывод площади и периметра для массива объектов
    for (int i = 0; i < 2; i++) {
        cout << "\nRectangle " << i + 1 << ":" << endl;
        cout << "Area: " << rectangles[i].area() << endl;
        cout << "Perimeter: " << rectangles[i].perimeter() << endl;
    }

    return 0;
}