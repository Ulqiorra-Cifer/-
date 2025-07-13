#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int maxSum(int n,vector<int>& array,int S){
    int maxLenght=0;
    int currentSum=0;
    int stepLeft=0;
    for(int stepRight=0;stepRight<n;stepRight++){
        currentSum += array[stepRight];
        while(currentSum>S){
            currentSum -= array[stepLeft];
            stepLeft++;
        }
        maxLenght = max(maxLenght,stepRight-stepLeft+1);
    }
    return maxLenght;
}

int main(){
    int n,S;
    cin>>n>>S;
    vector<int> array(n);
    for(int i=0;i<n;i++){
        cin>>array[i];
    }
    cout<<maxSum(n,array,S)<<endl;
    return 0;
}
