#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int timer=0;
vector<int> abc[1000];
bool visited[1000];
vector<pair<int,int>> bridges;
int in[1000],low[1000];

void DFS(int v, int p){
    visited[v]=true;
    in[v]=low[v]=timer++;
    for(int to : abc[v]){
        if(to == p) continue;
        if(visited[to]){
            low[v]=min(low[v],in[to]);
        }else{
            DFS(to,v);
            low[v]=min(low[v],low[to]);
            if(low[to]>in[v]){
                bridges.push_back({v,to});
            }
        }
    }

}



int main(){
    int N,M;
    cin>>N>>M;
    for(int i=0;i<M;i++){
        int u,v;
        cin>>u>>v;
        abc[u].push_back(v);
        abc[v].push_back(u);
    }
    for(int i=0;i<N;i++){
        visited[i]=false;
        in[i]=low[i]=-1;
    }
    for(int i=0;i<N;i++){
        if(!visited[i]){
            DFS(i,-1);
        }
    }
    cout<<"bridges: ";
    for(auto& bridge:bridges){
        cout<<bridge.first<<" "<<bridge.second<<endl;
    }
    return 0;
}