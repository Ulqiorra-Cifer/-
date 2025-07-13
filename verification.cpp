#include <iostream>
#include <string>
#include <unordered_map>
using namespace std;

class User{
    private:
    unordered_map<string,string> users;
    bool isExists(const string &username)const{
        return users.find(username) != users.end();
    }
    public:
    User(){
        users["user1"]="user12345";
        users["user"]="password";
    }
    
    void registration(){
        string username,password;
        cout<<"create user name"<<endl;
        cin>>username;
        if(isExists(username)){
            cout<<"this user name is taken"<<endl;\
            return;
        }
        cout<<"create the password"<<endl;
        cin>>password;
        users[username]=password;
        cout<<"registration succes"<<endl;
    }

    void loginToUser(){
        string username,password;
        cout<<"enter youre user name"<<endl;
        cin>>username;
        if(!isExists(username)){
            cout<<"user not founded"<<endl;
            return;
        }
        cout<<"enter the password"<<endl;
        cin>>password;
        if(users[username]==password){
            cout<<"succes welcome"<<endl;
        }else{
            cout<<"wrong password try again"<<endl;
        }
    }

};

int main(){
    User p1;
    int choise;
    do{
        cout<<"you want to registrate/login? 1/2"<<endl;
        cin>>choise;
        switch(choise){
            case 1:
            p1.registration();
            break;
            case 2:
            p1.loginToUser();
            break;
            default:
            cout<<"error wrong choise"<<endl;
        }
    }while(choise != 0);
    return 0;
}