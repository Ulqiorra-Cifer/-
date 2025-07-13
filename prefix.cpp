#include <iostream>
#include <algorithm>
#include <string>
#include <vector>
using namespace std;

string longestCommonPrefix(vector<string>& strs) {
    if (strs.empty()) return "";
    string prefix = strs[0];

    for (int i = 1; i < strs.size(); ++i) {
        while (strs[i].find(prefix) != 0) {
            prefix = prefix.substr(0, prefix.length() - 1);
            if (prefix.empty()) return "";
        }
    }
    return prefix;
}

int main(){
    vector <string> strs1={"car","cat","coal"};
    cout<<longestCommonPrefix(strs1)<<endl;
    return 0;
}