#include <iostream>
using namespace std;

struct Node{
    int data;
    Node* next;
    Node(int value): data(value),next(nullptr){}
};

Node* findMiddle(Node* head) {
    Node* slow = head;
    Node* fast = head;
    while (fast && fast->next) {
        slow = slow->next;  
        fast = fast->next->next;  
    }
    return slow;
}

Node* reverseList(Node* head) {
    Node* prev = nullptr; 
    Node* current = head;  
    Node* next = nullptr; 
    while (current != nullptr) {
        next = current->next; 
        current->next = prev;
        prev = current;        
        current = next;       
    }
    return prev;
}

bool Palindrome(Node* head){
    if(!head|| !head->next){
        return true;
    }
    Node* middle=findMiddle(head);
    Node* half1=head;
    Node* half2=reverseList(head);
    bool isP=true;
    while(half2){
        if(half1->data!=half2->data){
            return false;
            break;
        }
        half1=half1->next;
        half2=half2->next;
    }
    reverseList(half2);
    return isP;
}

void append(Node*& head,int value){
    if(!head){
        head= new Node(value);
        return;
    }
    Node* temp=head;
    while(temp->next){
        temp=temp->next;
    }
    temp->next= new Node(value);
}

void printList(Node* head){
    while(head){
        cout << head->data << " -> ";
        head = head->next;
    }
    cout<< "nullptr" <<endl;
}

int main (){
    Node* head =nullptr;
    append(head,1);
    append(head,2);
    append(head,3);
    append(head,2);
    append(head,1);
    bool res=Palindrome(head);
    return res;
    return 0;
}