#include <iostream>
#include <vector>
using namespace std;

void backtrack(vector<int>& candidates, int target, vector<int>& current, vector<vector<int>>& result, int start) {
    if (target == 0) {
        result.push_back(current);
        return;
    }
    for (int i = start; i < candidates.size(); i++) {
        if (candidates[i] > target) continue;
        current.push_back(candidates[i]);
        backtrack(candidates, target - candidates[i], current, result, i);
        current.pop_back();
    }
}

vector<vector<int>> Sum(vector<int>& candidates, int target) {
    vector<vector<int>> result;
    vector<int> current;
    backtrack(candidates, target, current, result, 0);
    return result;
}

int main() {
    vector<int> candidates1 = {2, 3, 6, 7};
    int target1 = 7;
    vector<vector<int>> result1 = Sum(candidates1, target1);
    cout << "Решение для первого примера:";
    for (const auto& combination : result1) {
        for (int num : combination) {
            cout << num << " ";
        }
        cout << endl;
    }

    vector<int> candidates2 = {2, 3, 5};
    int target2 = 8;
    vector<vector<int>> result2 = Sum(candidates2, target2);
    cout << "Решение для второго примера";
    for (const auto& combination : result2) {
        for (int num : combination) {
            cout << num << " ";
        }
        cout << endl;
    }

    vector<int> candidates3 = {2};
    int target3 = 1;
    vector<vector<int>> result3 = Sum(candidates3, target3);
    cout << "Решение для третьего примера:";
    if (result3.empty()) {
        cout << "Нет решений";
    } else {
        for (const auto& combination : result3) {
            for (int num : combination) {
                cout << num << " ";
            }
            cout <<endl;
        }
    }
    return 0;
}
