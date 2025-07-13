#include <iostream>
#include <string>
using namespace std;

class Children{
    private:
    string name,lastname;
    int age;
    public:
    void enterInfo(){
        cout<<"Enter the first name of child "<<endl;
        cin>>name;
        cout<<"enter the last name of child"<<endl;
        cin>>lastname;
        cout<<"Enter the age of child"<<endl;
        cin>>age;
    }

    void showInfo()const{
        cout<<"Name: "<<name<<" Last name: "<<lastname<<" Age: "<<age<<endl;
    }

};

int main(){
    Children broski1,broski2;
    broski1.enterInfo();
    broski1.showInfo();
    broski2.enterInfo();
    broski2.showInfo();
    return 0;
}
