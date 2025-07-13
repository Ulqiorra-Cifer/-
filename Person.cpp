#include <iostream>
#include <string>
using namespace std;

class Person {
  private: 
    string name;
    int age;
    string country;
  public:
    void setName(const string & n) {
      name = n;
    }
    void setAge(int a) { 
      age = a;
    }
    void setCountry(const string & c) { 
      country = c;
    }
    string getName() const {
      return name;
    }
    int getAge() const {
      return age;
    }
    string getCountry() const {
      return country;
    }
    virtual ~Person() = default;
};

int main() {
    Person dude;
    dude.setName("Saveli Sujatha");
    dude.setAge(25);
    dude.setCountry("England");
    cout << "Name: " << dude.getName() << endl;
    cout << "Age: " << dude.getAge() << endl;
    cout << "Country: " << dude.getCountry() << endl;
    return 0;
}

