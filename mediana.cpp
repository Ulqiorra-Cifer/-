#include <iostream>
#include <vector>
#include <queue>
#include <functional>

class MedianFinder{
private:
    std::priority_queue<int> maxHeap;
    std::priority_queue<int,std::vector<int>,std::greater<int>> minHeap;

public:
    void addNum(int num){
        if(maxHeap.empty() || num<=maxHeap.top()){
            maxHeap.push(num);
        }else{
            minHeap.push(num);
        }
        if(maxHeap.size()>minHeap.size()+1){
            minHeap.push(maxHeap.top());
            maxHeap.pop();
        }else{
            maxHeap.push(minHeap.top());
            minHeap.pop();
        }
    }
    double findMedian(){
        if(maxHeap.size()<minHeap.size()){
            return maxHeap.top();
        }else{
            return (maxHeap.top() + minHeap.top()/2.0);
        }
    }
};

int main(){
    MedianFinder mf;
    std::vector<int> v={1,5,3,2,9,6};
    for(int num : v){
        mf.addNum(num);
        std::cout<<num<<mf.findMedian()<<std::endl;
    }
    return 0;
}