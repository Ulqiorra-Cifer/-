#include <iostream>
#include <string>
using namespace std;

class Student{
    public:
    int age,grade;
    string name;
    Student(string n,int a,int g):name(n),age(a),grade(g){}

    void info()const{
        cout<<"Name: "<<name<<" grade: "<<grade<<" age: "<<age<<endl;
    }
};

int main(){
    Student s1("Danya",19,4);
    s1.info();
    return 0;
}