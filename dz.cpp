#include <iostream>
#include <vector>
#include <unordered_map>
#include <queue>

using namespace std;
struct Compare {
    bool operator()(pair<int, int>& a, pair<int, int>& b) {
        if (a.second == b.second) {
            return a.first < b.first;
        }
        return a.second < b.second;
    }
};

vector<int> frequencySort(vector<int>& nums) {
    unordered_map<int, int> freqMap;
    for (int num : nums) {
        freqMap[num]++;
    }

    priority_queue<pair<int, int>, vector<pair<int, int>>, Compare> maxHeap;
    
    for (auto& entry : freqMap) {
        maxHeap.push(entry);
    }

    vector<int> result;
    while (!maxHeap.empty()) {
        int num = maxHeap.top().first;
        int count = maxHeap.top().second;
        maxHeap.pop();
        for (int i = 0; i < count; ++i) {
            result.push_back(num);
        }
    }

    return result;
}

int main() {
    vector<int> nums = {4,5,4,7,9,7,4};
    vector<int> sorted = frequencySort(nums);
    for (int num : sorted) {
        cout << num << " ";
    }
    return 0;
}
