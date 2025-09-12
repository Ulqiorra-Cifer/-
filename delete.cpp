#include <iostream>
using namespace std;

struct listNode{
    int data;
    listNode* next;
    listNode(int value): data(value),next(nullptr){}
};

void deletenode(listNode* Node){
    listNode* temp= node->next;
    node->value=temp->value;
    node->next=temp->next;
    delete temp;
}

void append(listNode*& head,int value){
    if(!head){
        head= new Node(value);
        return;
    }
    listNode* temp=head;
    while(temp->next){
        temp=temp->next;
    }
    temp->next= new Node(value);
}

void printList(listNode* head){
    while(head){
        cout << head->data << " -> ";
        head = head->next;
    }
    cout<< "nullptr" <<endl;
}


int main(){
    listNode* head=nullptr;
    append(head,1);
    append(head,2);
    append(head,3);
    append(head,4);
    append(head,5);
    deletenode(head->next->next);
    printList(head);
    while(head != nullptr){
        head=head->next;
    }
    return 0;
}