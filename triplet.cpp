#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

vector<vector<int>> treeSum(vector<int>& nums){
    vector<vector<int>> res;
    sort(nums.begin(),nums.end());

    for(int i=0;i<nums.size();i++){
        if(i>0 && nums[i]==nums[i-1]){
            continue;
        }
    
    int left=i+1;
    int right=nums.size()-1;

    while(left<right){
        int sum=nums[left]+nums[i]+nums[right];
        if(sum==0){
            res.push_back({nums[left],nums[i],nums[right]});

            while(left<right && nums[right]==nums[right-1]){
                --right;
            }
            while(left<right && nums[left]==nums[left + 1]){
                ++left;
            }
            ++left;
            --right;
        }else if(sum<0){
            ++left;
        }else{
            --right;
        }
    }
    }
    return res;
}

int main(){
    vector<int> nums1={-1,0,1,2,-1,-4};
    vector<vector<int>> res1=treeSum(nums1);
    cout<<" Solution 1:";
    for(const auto& triplet : res1){
        cout<<"[";
        for(int num : triplet){
            cout<<num<<" ";
        }
        cout<<endl;
    }

    vector<int> nums2={0,1,1};
    vector<vector<int>> res2=treeSum(nums2);
    cout<<" Solution 2:";
    if(res2.empty()){
        cout<<" there is no solutions ";
    }else{
        for(const auto& triplet : res2){
            cout<<"[";
            for(int num : triplet){
            cout<<num<<" ";
            }
            cout<<endl;
        }
    }
    return 0;
}