#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int bagwhitlimits(int n, int W, vector<tuple<int, int, int>>& items) {
    vector<int> dp(W + 1, 0);
    for (int i = 0; i < n; ++i) {
        int c, w, k;
        tie(c, w, k) = items[i];
        for (int count = 1; count <= k; ++count) {
            for (int weight = W; weight >= w * count; --weight) {
                dp[weight] = max(dp[weight], dp[weight - w * count] + c * count);
            }
        }
    } 
    return dp[W];
}

int main() {
    int n, W;
    cin >> n >> W;
    vector<tuple<int, int, int>> items(n);
    for (int i = 0; i < n; ++i) {
        int c, w, k;
        cin >> c >> w >> k;
        items[i] = make_tuple(c, w, k);
    }
    cout << bagwhitlimits(n, W, items) << endl;
    return 0;
}
