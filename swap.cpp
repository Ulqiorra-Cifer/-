#include <iostream>
using namespace std;

void fillArray(int array,int sizeofarray);
void showarray(int array,int sizeofarray);
void swap(int array,int sizeofarray); 

int main(){
    int sizeofarray=12;
    int arrayforswap = new  ;
    fillArray(array,sizeofarray);
    showarray(array,sizeofarray);
    swap(array,sizeofarray);
    showArray(array,sizeofarray);
    return 0;
}

void fillArray(int array,int sizeofarray){
    for(int i=0;i<sizeofarray;i++){
        cin>>array[i];
    }
}

void showArray(int array,int sizeofarray){
    for(int i=0;i<sizeofarray;i++){
        cout<<array[i];
    }
    cout<<endl;
}

void swap(int array,int sizeofarray){
    int buffer=0;
    for(int i=0;i<sizeofarray - 1;i++){
        buffer=array[i];
        array[i]=array[i+1];
        array[i+1]=buffer;
    }
}