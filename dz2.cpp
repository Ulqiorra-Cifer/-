#include <iostream>
#include <vector>
#include <unordered_map>
using namespace std;

typedef vector<vector<int>> Graph;

unordered_map<string, int> memo;

int dfs(const Graph& g, int A, int B, int k) {
    if (k == 0) return A == B ? 1 : 0;
    string key = to_string(A) + "," + to_string(k);
    if (memo.find(key) != memo.end()) return memo[key];
    int count = 0;
    for (int neighbor : g[A]) {
        count += dfs(g, neighbor, B, k - 1);
    } 
    memo[key] = count;
    return count;
}

int main() {
    int n, m, A, B, k;
    cin >> n >> m >> A >> B >> k;
    Graph g(n);
    for (int i = 0; i < m; ++i) {
        int u, v;
        cin >> u >> v;
        g[u].push_back(v);
    }
    cout << dfs(g, A, B, k) << endl;
    return 0;
}
