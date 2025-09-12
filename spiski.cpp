#include <iostream>
using namespace std;

struct ListNode {
    int val;
    ListNode* next;
    ListNode(int x) : val(x), next(nullptr) {}
};

ListNode* mergeArrays(ListNode* list1,ListNode* list2){
    ListNode* dummy= new ListNode(0);
    ListNode* current = dummy;
    while(list1 != nullptr && list2 != nullptr){
        if(list1->val <= list2->val){
            current->next=list1;
            list1=list1->next;
        }else{
            current->next=list2;
            list2=list2->next;
        }
        current=current->next;
    }
    if(list1 != nullptr){
        current -> next=list1;
    }else if(list2 != nullptr){
        current->next=list2;
    }
    ListNode* result = dummy->next;
    delete dummy;
    return result;
}

ListNode* createLists(int arr[],int size){
    if(size == 0) return nullptr;
    ListNode* head= new ListNode(arr[0]);
    ListNode* current=head;
    for(int i=0;i<size;i++){
        current->next= new ListNode(arr[i]);
        current=current->next;
    }
    return head;
}

void printList(ListNode* head){
    while(head !=nullptr){
        cout<<head->val<<" ";
        head=head->next;
    }
    cout<<endl;
}

int main(){
    int arr1[]={1,2,4};
    int arr2[]={1,3,4};
    ListNode* list1 = createLists(arr1,3);
    ListNode* list2 = createLists(arr2,3);
    ListNode* merged=mergeArrays(list1,list2);
    printList(merged);
    return 0;
}
