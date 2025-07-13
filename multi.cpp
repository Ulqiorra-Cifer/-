#include <iostream>
#include <vector>
#include <thread>
#include <mutex>

const int SIZE = 100;
std::vector<int> arr(SIZE);
std::mutex mtx;

void processData(int startIdx, int endIdx) {
    for (int i = startIdx; i < endIdx; ++i) {
        arr[i] += 1; 
    }

    std::lock_guard<std::mutex> lock(mtx);
    std::cout << "Thread processed range [" << startIdx << ", " << endIdx << ")\n";
}

void printData() {
    for (int i = 0; i < SIZE; ++i) {
        std::cout << arr[i] << " ";
    }
    std::cout << std::endl;
}

int main() {
    for (int i = 0; i < SIZE; ++i) {
        arr[i] = i;
    }

    int numThreads = 4;
    std::vector<std::thread> threads;

    int chunkSize = SIZE / numThreads;

    for (int i = 0; i < numThreads; ++i) {
        int startIdx = i * chunkSize;
        int endIdx = (i == numThreads - 1) ? SIZE : (i + 1) * chunkSize;

        threads.push_back(std::thread(processData, startIdx, endIdx));
    }

    for (auto& t : threads) {
        t.join();
    }

    std::cout << "Processed array: ";
    printData();

    return 0;
}
