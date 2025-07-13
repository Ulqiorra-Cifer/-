#include <iostream>
#include <stack>
#include <string>
using namespace std;

string reverse(const string& b){
    stack<char> s;
    string rev;
    for(char ch : b){
        s.push(ch);
    }
    while(!s.empty()){
        rev += s.top();
        s.pop();
    }
    return rev;

}

int main(){
    string a;
    cin>>a;
    string reversed=reverse(a);
    cout<<reversed<<endl;
    return 0;
}