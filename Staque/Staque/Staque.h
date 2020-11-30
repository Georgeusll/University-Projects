#include <iostream>
using namespace std;

#ifndef STAQUE_H
#define STAQUE_H
struct node {
    int information;
    struct node* next;

};


class staque {
private:
    struct node* head;
    int length;
public:
    struct node* newNode(int);
    void insertFront(int);
    void insertLast(int);
    void deleteFront();
    void deleteLast();
    void display();
    staque();
    ~staque();
};

#endif // STAQUE_H

class Staque
{
};
