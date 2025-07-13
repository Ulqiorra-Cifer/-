#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>

using namespace std;

struct Tasks{
    int profit,deadline;
};

bool compare(const Tasks& a,const Tasks& b){
    return a.profit>b.profit;
}

int maxProf(vector<Tasks>& tas){
    sort(tas.begin(),tas.end(),compare);
    int maxDeadLine=0;
    for(const Tasks& task : tas){
        maxDeadLine=max(maxDeadLine,task.deadline);
    }


    vector<bool> timeslots(maxDeadLine,false);
    int totalProfit=0;
    for(const Tasks& task : tas){
        for(int t = task.deadline-1;t>=0;t--){
            if(!timeslots[t]){
                timeslots[t]=true;
                totalProfit += task.profit;
                break;
            }
        }
    }
    return totalProfit;
}

int main(){
    vector<Tasks> tas={{20,3},{15,6},{17,4},{5,3}};
    int n = maxProf(tas);
    cout<<"Max Profit is: "<<n<<endl;
    return 0;
}