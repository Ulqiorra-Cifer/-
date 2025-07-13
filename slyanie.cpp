#include <iostream>

struct Node{
    int data;
    Node* next;
    Node(int val) : data(val), next(nullptr) {}
};

Node* mergeSortedLists(Node* l1, Node* l2){

    if(!l1) return l2;
    if(!l2) return l1;

    Node dummy(0);
    Node* tail = &dummy;

    while(l1 && l2){
        if (l1->data < l2->data){
            tail->next = l1;
            l1 = l1 -> next;
        }else{
            tail->next = l2;
            l2 = l2->next;
        }
        tail = tail->next;
    }

    tail->next = l1 ? l1 : l2;

    return dummy.next;
}

void append(Node*& head, int value){
    if(!head){
        head = new Node(value);
        return;
    }

    Node* temp = head;
    while(temp->next){
        temp = temp->next;
    }
    temp->next = new Node(value);
}

void printList(Node* head){
    while(head){
        std::cout << head->data << " -> ";
        head = head->next;
    }
    std::cout << "nullptr" << std::endl;
}

int main(){
    Node* list1 = nullptr;

    Node* list2 = nullptr;

    append(list1, 1);
    append(list1, 3);
    append(list1, 5);

    append(list2, 2);
    append(list2, 4);
    append(list2, 6);

    std::cout << "Список 1: ";
    printList(list1);
    std::cout << "Список 2: ";
    printList(list2);

    Node* mergedList = mergeSortedLists(list1, list2);

    std::cout << "Слияние списков: ";
    printList(mergedList);

    return 0;
}