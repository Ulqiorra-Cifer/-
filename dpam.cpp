#include <iostream>
using namespace std;

int main(){
    int size;
    cout<<"razmer massiva"<<endl;
    cin>>size;
    int* array=new int[size];
    for(int i=0;i<size;i++){
        cin>>array[i];
    }

    for(int i=0;i<size;i++){
        cout<<array[i]<<endl;
    }

    delete[] array;
    return 0;
}