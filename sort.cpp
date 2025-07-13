#include <iostream>
using namespace std;

void sort(int array[]){
    int temp;
    for(int i=0;i<5;i++){
        for(int j=0;j<5-i;j++){
            if(array[j]>array[j + 1]){
            temp=array[j];
            array[j]=array[j + 1];
            array[j + 1]=temp;
            }
        }
    }
}

int main(){
    int array[5]{1,7,9,2,4};
    sort(array);
    for(int i=0;i<5;i++){
        cout<<array[i]<<endl;
    }
    return 0;
}