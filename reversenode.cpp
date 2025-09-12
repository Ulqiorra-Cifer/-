#include <iostream>

struct ListNode {
    int val;
    ListNode* next;
    ListNode(int x) : val(x), next(nullptr) {}
};

ListNode* reverseList(ListNode* head) {
    ListNode* prev = nullptr; 
    ListNode* current = head;  
    ListNode* next = nullptr; 
    while (current != nullptr) {
        next = current->next; 
        current->next = prev;
        prev = current;        
        current = next;       
    }
    return prev;
}

void printList(ListNode* head) {
    ListNode* current = head;
    while (current != nullptr) {
        std::cout << current->val << " -> ";
        current = current->next;
    }
    std::cout << "nullptr" << std::endl;
}

ListNode* createList()

int main() {
    
}
