#include <iostream>
#include <vector>
#include <queue>
using namespace std;

const int INF = 1e9;
vector<int> pairU,pairV,dist;
bool isB(int n,vector<vector<int>>& graph,vector<int>& color){
    queue<int> q;

    for(int i=0;i<n;i++){
        if(color[i]==-1){
            color[i]=0;
            q.push(i);

            while(!q.empty()){
                int u=q.front();
                q.pop();

                for(int v: graph[u]){
                    if(color[v]==-1){
                        color[v]=1-color[u];
                        q.push(v);
                    }else if(color[v]==color[u]){
                        return false;
                    }
                }
            }
        }
    }
    return true; 
}

bool bfs(int U,vector<vector<int>>& adj){
    queue<int> q;
    for(int u=0;u<U;u++){
        if(pairU[u]==-1){
            dist[u]=0;
            q.push(u);
        }else{
            dist[u]=INF;
        }
    }
    int fakenode=U;
    dist[fakenode]=INF;

    while(!q.empty()){
        int u=q.front();
        q.pop();
        if(dist[u]<dist[-1]){
            for(int v: adj[u]){
                if(dist[pairV[v]]==INF){
                    dist[pairV[v]]=dist[u]+1;
                    q.push(pairV[v]);
                }
            }
        }
    }
    return dist[-1]!=INF;
}

bool dfs(int u,vector<vector<int>>& adj){
    if(u!=-1){
        for(int v:adj[u]){
            if(dist[pairV[v]]==dist[u]+1 && dfs(pairV[v],adj)){
                pairV[v]=u;
                pairU[u]=v;
            }
        }
        dist[u]=INF;
        return false;
    }
    return true;
}

int hop(int U,int V,vector<vector<int>>& adj){
    pairU.assign(U,-1);
    pairV.assign(V,-1);
    dist.assign(U + 1,INF);

    int matching=0;
    while(bfs(U,adj)){
        for(int u;u<U;u++){
            if(pairU[u]==-1 && dfs(u,adj)){
                matching++;
            }
        }
    }
    return matching;
}

int main() {
    int n, m;
    cin >>n>>m;
    vector<vector<int>> graph;
    for (int i=0;i<m;++i) {
        int u, v;
        cin >>u>>v;
        u--; v--;
        graph[u].push_back(v);
        graph[v].push_back(u);
    }

    vector<int> color(n,-1);
    if(!isB(n,graph,color)){
        cout<<"graph not right"<<endl;
        return 0;
    }

    int U=0,V=0;
    vector<vector<int>> adj(n);
    for(int u=0;u<n;u++){
        if(color[u]==0){
            U++;
            for(int v:graph[u]){
                adj[u].push_back(v);
            }
        }else{
            V++;
        }
    }
    adj.resize(U);
    int minBuses=hop(U,V,adj);
    cout<<minBuses<<endl;
    return 0;
}
