#include <iostream>
#include <stack>
#include <string>
using namespace std;

void check(const string& b){
    char ch;
    stack<char> s;
    for(char ch: s){
        s.push(ch);
        if(s.push()==s.top()){
            s.pop();
        }else{
            s.push(ch);
        }
    }
    string result;
    while(!s.empty()){
        
    }
}

int main(){
    string a;
    cin>>a;



}