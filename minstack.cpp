#include <iostream>
#include <stack>
using namespace std;

class Stack{
    public:
    stack<int> s;
    stack<int> mins;
    void push(int x){
        if(mins.empty() || x<mins.top()){
            mins.push(x);
        }
    }

    void pop(){
        if(s.top()==mins.top()){
            mins.pop();
        }
        s.pop();
    }

    int top(){
        return mins.top();
    }

    int getMin(){
        return mins.top();
    }
};

int main(){
    Stack solve;
    solve.push(4);
    solve.push(9);
    solve.push(3);
    cout<<solve.getMin()<<endl;
    solve.pop();
}