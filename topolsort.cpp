#include <iostream>
#include <vector>
#include <queue>
using namespace std;

bool topologicalSort(vector<vector<int>>& graph,int num){
    vector<int> inDegree(num,0);
    for(int i=0;i<num;i++){
        for(int neighbor:graph[i]){
            inDegree[neighbor]++;
        }
    }

    queue<int> q;
    for(int i=0;i<num;i++){
        if(inDegree[i]==0){
            q.push(i);
        }
    }

    vector<int> sorted;
    while(!q.empty()){
        int task=q.front();
        q.pop();
        sorted.push_back(task);

        for(int depentTask:graph[task]){
            inDegree[depentTask]--;
            if(inDegree[depentTask]==0){
                q.push(depentTask);
            }
        }
    }
    cout<<"Sorted ";
    for(int task:sorted){
        cout<<task<<" ";
    }
    cout<<endl;
    return true;
}



int main(){
    int num;
    cout<<"enter how many tasks "<<endl;
    cin>>num;
    vector<vector<int>> graph(num);
    topologicalSort(graph,num);
    return 0;
}