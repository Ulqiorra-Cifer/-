#include <iostream>
#include <queue>
#include <vector>

std::vector<int> mergeHeaps(std::vector<int> heap1,std::vector<int> heap2){
    std::priority_queue<int,std::vector<int>,std::greater<int>>minHeap;

    for(int val:heap1)minHeap.push(val);
    for(int val:heap2)minHeap.push(val);

    std::vector<int> mergedHeap;
    while(!minHeap.empty()){
        mergedHeap.push_back(minHeap.top());
        minHeap.pop();
    }
    return mergedHeap;
}

int main(){
    std::vector<int> heap1={1,9,3,7};
    std::vector<int> heap2={2,6,5,8};
    std::vector<int> heap3 = mergeHeaps(heap1,heap2);

    std::cout<<"Merget heap "<<" ";
    for(int val : heap3){
        std::cout<<val<<" ";
    }
    return 0;
}