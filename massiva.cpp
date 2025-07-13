#include <iostream>
using namespace std;

void minNum(int array[], int min){
    for(int i=0;i<3;i++){
        min=array[1];
        if(array[i]<min){
            min=array[i];
        }
    }
    cout<<min<<endl;
}

int main(){
    int array[3]{5,9,4};
    int min;
    minNum(array,min);
    return 0;
}