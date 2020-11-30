#include <iostream>
#include<random>
#include<time.h>
#include <iomanip>
#include <sstream>
#include <limits>
#include <windows.h>
#include "Platipus.h"
using namespace std;


int ValidMenuChoice(int choice);
double getDouble(double n);


int main()
{
	
	Platipus Leri;          //default constructor
	srand(time(0));
	char name, gender;
	short age;
	float weight;
	cout << "Enter the Platipus name: " << endl;     //asking user for the basic information
	cin >> name;
	while (!isalpha(name)) {
		cout << "Please enter a character" << endl;
		cin >> name;
	}
	cout << "Enter The Platipus gender: " << endl;
	cin >> gender;
	if (gender = 'm')
	{
		
	}
	else if (gender = 'f')
	{
		
	}
	else
	{
		cout << " Wrong input choose between m mand f (Because there are only 2 genders)" << endl;
		cin >> gender;
	}
	cout << "age (in Months)" << endl;
	cin >> age;

	cout << "weight" << endl;
	cin >> weight;
	weight = getDouble(weight);

	Platipus perry(name, gender, weight, age);         //regular constructor
	system("CLS");
	cout << "    creating the platipus" << endl;
	Sleep(2000);
	cout << "    Platipus created" << endl;
	Sleep(2000);
	system("CLS");
	cout << "    check status" << endl;
	Sleep(2000);
	char key;
	cout<<"Press any key to continue..."<< endl;
	cin >> key;
	system("CLS");
			cout << perry << endl;						

			cout << "Press any key to continue..." << endl;
			cin >> key;
			system("CLS");
			cout << "Now we will test the function age_me" << endl;
			int n;

			cout << "How many months you want to pass: " << endl;
			cin >> n;

			perry.age_me(perry, n);
			Sleep(2000);
			cout << "Press any key to continue..." << endl;
			cin >> key;
			system("CLS");
			Sleep(2000);
			cout << "Alright, so far so good, let us feed the platipus shall we?\n" << endl;
			
			cout << "Press any key to continue..." << endl;
			cin >> key;
			perry.eat(perry);
			Sleep(2000);
			cout<<"let us see the changes" << endl;
			cout << perry << endl;
			cout << "Press any key to continue..." << endl;
			cin >> key;
			system("CLS");
			cout << "Ok, let us fight with some other platipuses, bring the opponent " << endl;
			Sleep(2000);
			cout << "Enter the opponents name initial:" << endl;

			cin >> name;

			while (!isalpha(name)) {
				cout << "Please enter a character" << endl;
				cin >> name;
			}
			cout << "Enter The Platipus gender: " << endl;
			cin >> gender;
			if (gender = 'm')
			{

			}
			else if (gender = 'f')
			{

			}
			else
			{
				cout << " Wrong input choose between m mand f (Because there are only 2 genders)" << endl;
				cin >> gender;
			}
			cout << "age (in Months)" << endl;
			cin >> age;

			

			cout << "weight" << endl;
			cin >> weight;
			weight = getDouble(weight);
			Sleep(2000);
			system("CLS");
			cout << "ok" << endl;
			Sleep(1000);
			system("CLS");
			cout << "Let's go..." << endl;
			Sleep(1000);
			system("CLS");
			Platipus jerry(name, gender, weight, age);

			perry.fight(perry, jerry);

			Sleep(1000);
			system("CLS");
			
			cout << " Let us hatch a new platipus" << endl;
			
			
			


			perry.hatch();



			cout << "Check the newborn status" << endl;
			cout << "Press any key to continue..." << endl;
			cin >> key;
			cout << perry << endl;
			cout << "Press any key to continue..." << endl;
			cin >> key;
			
			system("CLS");
			cout << "Well this concludes our Simulation" << endl;
			Sleep(2000);
			system("CLS");
			cout << "It was nice to be working on this simulation" << endl;


	
	return 0;
}


int ValidMenuChoice(int choice)
{
	while (!cin.good() && (choice >= 1 || choice <= 6))
	{
		cout << "Error: Invalid input error\n" << endl;
		cin.clear();
		cin.ignore(123, '\n');

		cout << "Enter The Given operation again( given - same ):  " << endl;
		cin >> std::setw(1) >> choice;
	}
	cin.clear();
	cin.ignore(123, '\n');

	return choice;
}

double getDouble(double n)      //   This is INPUT VALIDATION FUNCTION
{

	while (!cin.good())    // Error check:  if input is invalid it returns false and whileLoop is executed
	{
		cout << "Error: Invalid input error\n" << endl; //Report Problem


		cin.clear();            // Clear stream
		cin.ignore(123, '\n');

		// Get the input again
		cout << "Enter The Given operation again( given - same ): " << endl;
		cin >> std::setw(1) >> n;    //Get only 1 input, no spaces allowed.
	}
	cin.clear();
	cin.ignore(123, '\n');

	return n;
}
