#include <iostream>
#include <vector>
#include <queue>
#include <climits>
using namespace std;

typedef pair<int, int> pii;
typedef vector<vector<pii>> Graph; 

vector<int> dijkstra(int n, const Graph& g, int start, const vector<bool>& traps) {
    vector<int> dist(n, INT_MAX);
    dist[start] = 0;
    priority_queue<pii, vector<pii>, greater<pii>> pq; 
    pq.push({0, start});

    while (!pq.empty()) {
        int u=pq.top().second;
        int d=pq.top().first;
        pq.pop();

        if(d > dist[u] || traps[u]){
            continue;
        }
        for(const auto& edge : g[u]){
            int v=edge.first;
            int weight=edge.second;

            if(dist[v]> dist[u]+weight){
                dist[v]=dist[u]+weight;
                pq.push({dist[v],v});
            }
        }

    }
    return dist;
}

int main(){
    int n,m,A,B,k;
    cin>>n>>m>>A>>B>>k;
    Graph g(n);
    for(int i=0;i<m;i++){
        int u,v,w;
        cin>>u>>v>>w;
        g[u].push_back({v,w});
    }
    vector<bool> traps(n,false);
    for(int i=0;i<k;i++){
        int trap;
        cin>>trap;
        traps[trap]=true;
    }

    vector<int> dist= dijkstra(n,g,A,traps);
    if(dist[B]== INT_MAX){
        cout<<"error"<<endl;
    }else{
        cout<<dist[B]<<endl;
    }
    return 0;
}