#include <iostream>
#include <vector>
#include <cstdlib>


int partition(std::vector<int>& nums, int left, int right){
    int pivot = nums[right];
    int i = left;

    for(int j = left; j < right; j++){
        if(nums[j] >= pivot){
            std::swap(nums[i], nums[j]);
        }
    }
    std::swap(nums[i], nums[right]);
    return i;
}

int quickselect(std::vector<int>& nums, int left, int right, int k){
    if(left == right) return nums[left];

    int pivotIndex = partition(nums, left, right);

    if( pivotIndex == k){
        return nums[pivotIndex];
    }
    else if(pivotIndex < k){
        return quickselect(nums, pivotIndex + 1, right, k);
    }
    else{
        return quickselect(nums, left, pivotIndex - 1, k);
    }
}

int findKthLargest(std::vector<int>& nums, int k) {
    return quickselect(nums, 0, nums.size() - 1, k - 1);
}

int main() {

    std::vector<int> scores = {3, 2, 9, 5, 6, 4};
    int k = 2;
    std::cout << "K-я наибольшая оценка: " << findKthLargest(scores, k) << std::endl;
    return 0;
}