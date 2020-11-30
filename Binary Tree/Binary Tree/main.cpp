#include "bst.h"
#include <iostream>
using namespace std;

void menu(BST& t);

int main()
{
    BST t;
    menu(t);
    cout << "exit";
    return 0;
}

void menu(BST& t) {
    int value;
    int r;
    for (;;)
    {
        cout << "\n1. Insert" << endl;
        cout << "2. Remove" << endl;
        cout << "3. Search" << endl;
        cout << "4. Inorder " << endl;
        cout << "5. Preorder" << endl;
        cout << "6. Postorder" << endl;
        cout << "7. Exit" << endl;
        cout << "Enter your value: ";
        cin >> value;
        switch (value)
        {
        case 1:
            cout << "Number to insert: ";
            cin >> r;
            t.insert(r);
            cout << r << " was inserted " << endl;
            break;
        case 2:
            cout << "Number to remove: ";
            cin >> r;
            if (t.remove(r))
                cout << r << " was removed " << endl;
            else
                cout << r << " was not found in the tree" << endl;
            break;
        case 3:
            cout << "Number to search: ";
            cin >> r;
            if (t.search(r))
                cout << r << " was found in the tree" << endl;
            else
                cout << r << " was not found in the tree" << endl;
            break;
        case 4:
            cout << "Inorder traversal is " << endl;
            t.inorder();
            break;
        case 5:
            cout << "Preorder traversal is " << endl;
            t.preorder();
            break;
        case 6:
            cout << "Postorder traversal is " << endl;
            t.postorder();
            break;
        case 7:
            return;
        default:
            cout << "Invalid!" << endl;


        }
    }
}
