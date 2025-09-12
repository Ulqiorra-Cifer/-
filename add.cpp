#include <iostream>
using namespace std;

int main(){
    int size;
    cout<<"chose size of array"<<endl;
    cin>>size;
    int array[size];
    for(int i=0;i<size;i++){
        cin>>array[i];
    }
    for(int i=0;i<size;i++){
        cout<<array[i]<<endl;
    }
    return 0;
}