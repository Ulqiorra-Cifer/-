#include <iostream>
#include <vector>
#include <algorithm>
#include <climits>
using namespace std;

int closestSum(vector<int>& nums,int target){
    sort(nums.begin(),nums.end());
    int closest=INT_MAX;
    for(int i=0;i<nums.size();i++){
        if(i>0 && nums[i]==nums[i+1]){
            continue;
        }
        int left=i+1;
        int right=nums.size()-1;
        while(left<right){
            int sum=nums[i]+nums[left]+nums[right];
            if(abs(sum-target)<abs(closest-target)){
                closest=sum;
            }
            if(sum<target){
                ++left;
            }
            else if(sum>target){
                --right;
            }else{
                return sum;
            }
        }
    }
    return closest;
}

int main(){
    vector<int> nums1={-1,2,1,-4};
    int target1 = 1;
    cout<<closestSum(nums1,target1)<<endl;
    vector<int> nums2 = {0,0,0};
    int target2 = 1;
    cout<<closestSum(nums2,target2)<<endl;
    return 0;
}