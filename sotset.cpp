#include <iostream>
#include <vector>
#include <climits>
#include <queue>
using namespace std;

int bfs(vector<vector<int>>& graph,int n,int target,int start){
    vector<int> dist(n,-1);
    queue<int> q;
    dist[start]=0;
    q.push(start);
    while (!q.empty()){
        int current =q.front();
        q.pop();

        for(int v: graph[current]){
            if(dist[v]==-1){
                dist[v]=dist[current]+1;
                if(v==target){
                    return dist[v];
                }
                q.push(v);
            }
        }
    }
    return -1;
}

int main(){
    int n,m;
    cout<<"quantity of users(n) and cconnections(m)"<<endl;
    cin>>n>>m;
    vector<vector<int>> graph(n);
    cout<<"connections between users(pairs)"<<endl;
    for(int i=0;i<m;i++){
        int u,v;
        cin>>u>>v;
        u--;v--;
        graph[u].push_back(v);
        graph[v].push_back(u);
    }

    int start,target;
    cout<<"Start user name and target user name"<<endl;
    cin>>start>>target;
    start--;target--;

    int result=bfs(graph,n,target,start);
    if(result != -1){
        cout<<"Minimal steps "<<endl;
    }else{
        cout<<"Target cannot be found"<<endl;
    }
    return 0;
}