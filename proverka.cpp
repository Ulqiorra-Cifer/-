#include <iostream>
#include <vector>
#include <queue>
using namespace std;

bool isIT(int N, const vector<vector<int>>& abc){
    vector<int> col(N,-1);
    for(int i=0;i<N;i++){
        if(col[i]==-1){
            queue<int> q;
            q.push(i);
            col[i]=0;
            while(!q.empty()){
                int v=q.front();
                q.pop();
                for(int to : abc[v]){
                    if(col[to]== -1){
                        col[to]=1-col[v];
                        q.push(to);
                    }else if(col[to]==col[v]){
                        return false;
                    }
                }
            }
        }
    }
    return true;
}

int main(){
    int N,M;
    cin>>N>>M;
    vector<vector<int>> abc(N);
    for(int i=0;i<M;i++){
        int u,v;
        cin>>u>>v;
        abc[u-1].push_back(v-1);
    }
    if(isIT(N,abc)){
        cout<<"нечетной длинны нету"<<endl;
    }else{
        cout<<"четная длинна есть"<<endl;
    }
    return 0;
}