#include <ostream>
using namespace std;
class Platipus
{
	public:
		//Constructors
		Platipus();
		Platipus(char name, char gender, float weight, short age);
		//functions
		void print(Platipus& p);
		friend ostream& operator<<(ostream& out, Platipus& p);
		void age_me(Platipus platObj, short month);
		void eat(Platipus platObj);  //do we need a & after Platipus?
		void hatch();
		void fight(Platipus p1, Platipus p2);

		int ValidInput(int choice);
	
		//Accessors
		float getWeight();
		short getAge();
		char getName();
		char getGender();
		bool getIsAlive();
		bool getIsMutant();
		//Mutators
		void setWeight(float weight);
		void setAge(short age);
		void setName(char name);
		void setGender(char gender);
		void setIsAlive(bool isAlive);
		void setIsMutant(bool isMutant);
		
	private:
		float weight;
		short age;
		char name;
		char gender;
		bool isAlive;
		bool isMutant;
};

