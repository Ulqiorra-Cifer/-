#include <iostream>
#include <unordered_set>
using namespace std;

struct listNode{
    int value;
    listNode* next;
    listNode(int a) : value(a), next(nullptr){}
};

void deleteDublicates(listNode* head){
    if(head == nullptr) return;
    unordered_set<int> seen;
    listNode* current=head;
    seen.insert(current->value);
    while(current != nullptr && current->next != nullptr){
        if(seen.find(current->next->value)!=seen.end()){
            current->next=current->next->next;
        }else{
            seen.insert(current->next->value);
            current=current->next;
        }
    }
}

void append(listNode*& head,int value){
    if(!head){
        head= new listNode(value);
        return;
    }
    listNode* temp=head;
    while(temp->next){
        temp=temp->next;
    }
    temp->next= new listNode(value);
}

void print(listNode* head){
    listNode* current=head;

    while(current!=nullptr)
    {
        cout<<current->value<<endl;
        current=current->next;
    }
}

int main(){
    listNode* head=nullptr;
    append(head,1);
    append(head,3);
    append(head,3);
    append(head,9);
    append(head,4);
    append(head,4);
    append(head,7);
    cout<<"after removing duplicate numbers:";
    deleteDublicates(head);
    print(head);
    return 0;
}
