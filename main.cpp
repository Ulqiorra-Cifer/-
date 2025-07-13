//main.cpp

#include <iostream>

using namespace std;

void sort(int array[],int size){
    int temp;
    for(int i=0;i<size-1;i++){
        for (int j=0;j<size-i-1;j++){
            if (array[j]<array[j + 1]){
                temp=array[j];
                array[j]=array[j + 1];
                array[j + 1]=temp;
                for(int i=0;i<size;i++){
                }
                cout<<array[i]<<endl;
            }
        }
    }
}

int main(){
    
    return 0;
}