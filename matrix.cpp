#include <iostream>
#include <vector>
#include <queue>
using namespace std;

struct Element {
    int value;
    int row;
    int col;
    Element(int val, int r, int c) : value(val), row(r), col(c) {}
    
    bool operator>(const Element& other) const {
        return value > other.value;
    }
};

int kthSmallest(const vector<vector<int>>& matrix, int K) {
    int n = matrix.size();
    priority_queue<Element, vector<Element>, greater<Element>> minHeap;

    for (int i = 0; i < n; ++i) {
        minHeap.push(Element(matrix[i][0], i, 0));
    }

    int count = 0;
    while (!minHeap.empty()) {
        Element current = minHeap.top();
        minHeap.pop();
        count++;
        if (count == K) {
            return current.value;
        }
        if (current.col + 1 < n) {
            minHeap.push(Element(matrix[current.row][current.col + 1], current.row, current.col + 1));
        }
    }
    return -1;
}

int main() {
    vector<vector<int>> matrix = {
        {1, 5, 9},
        {10, 11, 13},
        {12, 13, 15}
    };
    int K = 8;

    int result = kthSmallest(matrix, K);
    cout << "The " << K << " smallest element: " << result << endl;

    return 0;
}
