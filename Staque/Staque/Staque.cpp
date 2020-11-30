#include "Staque.h"
#include <iostream>
using namespace std;

staque::staque()
{
    head = NULL;
    length = 0;
}
struct node* staque::newNode(int val) {

    struct node* temp;
    temp = new(struct node);
    temp->information = val;
    temp->next = NULL;
    return temp;

}

void staque::insertFront(int val) {

    struct node* temp, * point;
    temp = newNode(val);
    if (head == NULL) {
        head = temp;
        head->next = NULL;
    }

    else {
        point = head;
        head = temp;
        head->next = point;
    }
    cout << "\n\t\tElement was inserted at the front.";
    length++;

}
void staque::insertLast(int val) {

    struct node* temp, * p;
    temp = newNode(val);
    if (head == NULL) {
        head = temp;
        head->next = NULL;
    }
    else {
        p = head;
        while (p->next != NULL) {
            p = p->next;
        }
        temp->next = NULL;

        p->next = temp;
    }

    cout << "\n\t\tElement was inserted at the end.";
    length++;
}

void staque::deleteFront() {

    if (length == 0)
        return;
    struct node* p;
    p = head;
    if (head == NULL) {
        cout << "\n\t\tStaque is empty!";
        return;
    }

    if (!(p->information & 1)) {
        head = head->next;
        delete p;
        length--;
        cout << "\n\t\tEven element was deleted.";
        if (length == 0)
            head = NULL;
    }

}

void staque::deleteLast() {

    if (length == 0)
        return;
    struct node* p, * temp{};
    p = head;
    if (head == NULL) {
        cout << "\n\t\tStaque is Empty!";
        return;
    }

    while (p->next != NULL) {
        temp = p;
        p = p->next;
    }

    if (p->information & 1) {
        temp->next = NULL;
        delete p;
        length--;
        cout << "\n\t\tOdd element was deleted.";
        if (length == 0)
            head = NULL;

    }

}

void staque::display() {

    struct node* temp;
    if (head == NULL) {
        cout << "\n\t\tStaque is Empty";
        return;
    }
    temp = head;
    cout << "\n\t\tStaque elements : ";
    while (temp != NULL) {
        cout << temp->information << " ";
        temp = temp->next;
    }
    cout << "\n";
}

staque::~staque()
{

}

