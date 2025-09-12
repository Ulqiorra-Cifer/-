#include <iostream>

struct ListNode {
    int val;
    ListNode* next;
    ListNode(int x) : val(x), next(nullptr) {}
};

int findMiddle(ListNode* head) {
    if (head == nullptr) return -1;
    ListNode* slow = head;
    ListNode* fast = head;
    while (fast != nullptr && fast->next != nullptr) {
        slow = slow->next;  
        fast = fast->next->next;  
    }
    return slow->val;
}

void printList(ListNode* head) {
    ListNode* current = head;
    while (current != nullptr) {
        std::cout << current->val << " -> ";
        current = current->next;
    }
    std::cout << "nullptr" << std::endl;
}

ListNode* createList(const std::initializer_list<int>& values) {
    ListNode* head = nullptr;
    ListNode* current = nullptr;

    for (int val : values) {
        ListNode* newNode = new ListNode(val);
        if (!head) {
            head = newNode;
            current = head;
        } else {
            current->next = newNode;
            current = current->next;
        }
    }
    return head;
}

int main() {
    ListNode* head = createList({1, 2, 3, 4, 5});
    int middle = findMiddle(head);
    std::cout << "Middle element: " << middle << std::endl;
    return 0;
}
