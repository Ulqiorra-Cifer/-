#include <iostream>

using namespace std;

bool isPalindrome(int x) {
    if (x < 0 || (x % 10 == 0 && x != 0)) {
        return false;
    }

    int reversed = 0;
    int original = x;

    while (x > 0) {
        int digit = x % 10;
        reversed = reversed * 10 + digit;
        x /= 10;
    }
    return original == reversed;
}

int main(){
    int x;
    cout<<"enter the number"<<endl;
    cin>>x;
    int a= isPalindrome(x);
    cout<<a<<endl;
}