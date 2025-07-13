#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>

struct Task{
    int profit;
    int deadline;
};

bool compareTasks(const Task& a, const Task& b) {
    return a.profit > b.profit;
}

int maxProfit(std::vector<Task>& tasks){
    std::sort(tasks.begin(), tasks.end(), compareTasks);

    int maxDeadline = 0;
    for (const Task& task : tasks) {
        maxDeadline = std::max(maxDeadline, task.deadline);
    }

    std::vector<bool> timeSlots(maxDeadline, false);

    int totalProfit = 0;

    for (const Task& task : tasks) {

        for (int t = task.deadline - 1; t >= 0; --t) {
            if (!timeSlots[t]) {
                timeSlots[t] = true;
                totalProfit += task.profit;
                break;
            }
        }
    }

    return totalProfit;
}

int main(){
    std::vector<Task> tasks = {
        {100, 2}, {19, 1}, {27, 2}, {25, 1}, {15, 3}
    };

    int result = maxProfit(tasks);

    std::cout << "Максимальная прибыль: " << result << std::endl;

    return 0;

}