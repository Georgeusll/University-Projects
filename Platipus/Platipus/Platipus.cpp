#include "Platipus.h"
#include <iostream>
#include <random>
#include <limits>
#include <iomanip>


using namespace std;


// Constructors
Platipus::Platipus()
{
	this->age = 0;
	this->gender = 'g';
	this->isAlive = false;
	this->isMutant = false;
	this->name = name;
	this->weight = 0;
}
Platipus::Platipus(char name, char gender, float weight, short age)
{
	this->name = name;
	this->gender = gender;
	this->weight = weight;
	this->age = age;
	this->isAlive = true;
	this->isMutant = false;
}
//functions
void Platipus::print(Platipus& platObject)
{
	cout << platObject << endl;
}

void Platipus::age_me(Platipus platObj, short month)
{
	short currentAge = platObj.getAge() + month;
	platObj.setAge(currentAge);

	int choice = 0;
	int mutation = rand() % 50;
	
	int deathRate = platObj.getWeight() * 10;
	double dethPercentage = rand() % 100 + 1;

	const double MIN_RAND = 0.1, MAX_RAND = deathRate;
	const double range = MAX_RAND - MIN_RAND;
	double random = range * ((((double)rand()) / (double)RAND_MAX)) + MIN_RAND;

	if (mutation == 1) 
	{
		setIsMutant(true);
		cout << "After " <<  platObj.getAge() << "months your Platipus became mutant" << endl;

		if (random > dethPercentage)    // Check this
		{
			platObj.setIsAlive(false);
			cout << "and died" << platObj.getAge();
		}

		cout << "Would you like to :\n1. Heal the Platipus.\n2. Hach new platipus.\n3. End the simulation. " << endl;
		cin >> choice;
		choice = ValidInput(choice);

		if (choice == 1) 
		{
			platObj.setIsMutant(false);

			cout << "We put the platipus in healing chamber and after some time it was healed of the mutation effect" << endl;
			cout<< "In other words, the platipus is no longer a mutant"<< endl;
		}
		else if (choice == 2)
		{
			platObj.hatch();
		}


		else if (choice == 3) 
		{
			exit(1);
		}
	}
	if (random > dethPercentage)
	{
		platObj.setIsAlive(false);
		cout << "Platipus dies at age " << platObj.getAge()<< endl;
	}
	else {
		cout << "The platipus survives " << endl;
	}
}

void Platipus::eat(Platipus platObj)
{
	if (platObj.getIsAlive()==false)
	{
		cout<< "The dead platipus does not eat" <<endl;
	}
	else {
		const double MIN_RAND = 0.1, MAX_RAND = 1.0;
			const double range = MAX_RAND - MIN_RAND;
			double random = range * ((((double)rand()) / (double)RAND_MAX)) + MIN_RAND;

			platObj.getWeight();
			float gainedMass = (platObj.getWeight() * random / 100);
			platObj.setWeight(platObj.getWeight() + gainedMass);
			cout << "The Platipus gained\n" << random << " pounds" << endl;
	}
}

void Platipus::hatch()
{
	bool Alive = 1;
	bool Mutant = 0;
	short Age = 0;
	char Gender;
	char Name;
	float Weight = (rand() % 10 + 1) / 10;
	int FM = rand() % 2;
	cout << "ENTER THE GENDER" << endl;
	cin >> Gender;
	cout	<< "Name the platipus! (name initial): " << endl;
	cin >> Name;
	weight = Weight;
	gender = Gender;
	age = Age;
	name = Name;
	isAlive = 1;
	isMutant = 0;

}

void Platipus::fight(Platipus p1, Platipus p2)

{
	int fightRation = (p1.getWeight() / p2.getWeight()) * 50;
	int randomNum = rand() % 100;
	if (fightRation > randomNum)
	{
		p2.setIsAlive(false);
		cout << p1.getName() << " Wins" << endl;
	}
	else
	{
		p1.setIsAlive(false);
		cout << p2.getName() << " Wins" << endl;
	}
}

int Platipus::ValidInput(int choice)
{
	while (!cin.good() && (choice >= 1 || choice <= 3))
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

ostream& operator<<(ostream& out, Platipus& platObj)
{
		out << "Platipus parameters" << endl;
		out << "Name: " << platObj.getName() << endl;
		out << "Gender: " << platObj.getGender() << endl;
		out << "Age: " << platObj.getAge() << " Months" << endl;
		out << "Weight: " << platObj.getWeight()<< " pounds" << endl;
		out << "IsAlive: " << platObj.getIsAlive() << endl;
		out << "IsMutant: " << platObj.getIsMutant() << endl;
		return out;
}
//Accessors
float Platipus::getWeight()
{
	return this->weight;
}

short Platipus::getAge()
{
	return this->age;
}

char Platipus::getName()
{
	return this->name;
}

char Platipus::getGender()
{
	return this->gender;
}

bool Platipus::getIsAlive()
{
	return this->isAlive;
}

bool Platipus::getIsMutant()
{
	return this->isMutant;
}

//Mutators

void Platipus::setWeight(float weight)
{
	this->weight = weight;
}

void Platipus::setAge(short age)
{
	this->age = age;
}

void Platipus::setName(char name)
{
	this->name = name;
}

void Platipus::setGender(char gender)
{
	this->gender = gender;
}

void Platipus::setIsAlive(bool isAlive)
{
	this->isAlive = isAlive;
}

void Platipus::setIsMutant(bool isMutant)
{
	this->isMutant = isMutant;
}

