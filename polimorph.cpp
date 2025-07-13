#include <iostream>
#include <string>
#include <vector>

class Dad {
public:
    int hands, legs, head;
    std::string name;

    virtual void showinfo() const {
        std::cout << "have hands, legs, head. Name: " << name << std::endl;
    }
    virtual ~Dad() = default;
};

class Son_1 : public Dad {
public:
    Son_1() { name = "Itan"; }
    void showinfo() const override {
        std::cout << "have hands, legs, head. Name: " << name << std::endl;
    }
};

class Son_2 : public Dad {
public:
    Son_2() { name = "Volodya"; }
    void showinfo() const override {
        std::cout << "have hands, legs, head. Name: " << name << std::endl;
    }
};

class Son_3 : public Dad {
public:
    Son_3() { name = "Pasha"; }
    void showinfo() const override {
        std::cout << "have hands, legs, head. Name: " << name << std::endl;
    }
};

int main() {
    std::vector<Dad*> sons;
    sons.push_back(new Son_1());
    sons.push_back(new Son_2());
    sons.push_back(new Son_3());
    for (const Dad* son : sons) {
        son->showinfo();
    }
    for (Dad* son : sons) {
        delete son;
    }
    return 0;
}