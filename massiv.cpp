#include <iostream>
using namespace std;

void fillAndPrintArray(int arr[], int size) {
    cout << "Введите " << size << " элементов массива: ";
    for (int i = 0; i < size; i++) {
        cin >> arr[i];
    }

    cout << "Элементы массива: ";
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " "; 
    }
    cout << endl;
}

int main() {
    const int size1 = 5;
    const int size2 = 3;
    int array1[size1];
    int array2[size2];
    cout << "Работа с первым массивом:" << endl;
    fillAndPrintArray(array1, size1);
    cout << "Работа со вторым массивом:" << endl;
    fillAndPrintArray(array2, size2);
    return 0;
}