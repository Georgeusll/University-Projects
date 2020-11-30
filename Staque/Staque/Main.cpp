
#include <iostream>
#include "Staque.h"
using namespace std;
int main()
{
    int userChoice, val;
    staque stue;

    for (;;) {
        cout << endl << "\n\t\tMenu:";
        cout << "\n\t\t1.Insertion ";
        cout << "\n\t\t2.Even number deletion";
        cout << "\n\t\t3.Odd number deletion";
        cout << "\n\t\t4.Displaying staque";
        cout << "\n\t\t5.Exit " << endl;
        cout << "\n\t\tEnter your choice : ";
        cin >> userChoice;

        switch (userChoice) {
        case 1:
            cout << "\n\t\tEnter an integer to insert: ";
            cin >> val;
            if (val & 1) {
                stue.insertLast(val);
            }
            else {
                stue.insertFront(val);
            }
            break;

        case 2:
            stue.deleteFront();
            break;

        case 3:
            stue.deleteLast();
            break;

        case 4:
            stue.display();
            break;

        case 5:
            exit(0);

        }

    }

    return 0;

}
