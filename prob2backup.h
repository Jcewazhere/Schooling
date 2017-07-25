/*******************************************************
* Student Name: Jamie Edwards
* Student Major: CS
* Course Name: CS215
* Date: 1/26/15
* Name of Program:   QuizProb2
* Source: Quiz problem 2
* Functions:
* --------------------------------------------
* [1]  main()                - No parameters, main driving program.
* [2]  getDistanceTraveled() - gets the user entered time and velocity.
* [3]  again()               - check whether the program should continue.
*
* (initial velocity * time) + (.5 (32 * time ^ 2)
*/

#include <string>
#include <iostream>
#include<cmath>
using namespace std;

double again(double);
double getDistanceTraveled(double);

struct userData
{
	double distanceCalc;
	double timeEntered;
	double InVel;
};

userData entries[50];
int i = 0; 


int main()
{
	
	double distance = 0;	
	int k = 0;

	cout << "This program calculates fall distance given user entered variables: initial velocity and time" << endl;
	again(distance);

	cout << "These are the distances you calculated using this program and your inputs:" << endl;

	while (k < i)
	{
		cout <<"Time: " << entries[k].timeEntered << ".    Initial velocity: " << entries[k].InVel << ".    Distance fallen: " 
			 << entries[k].distanceCalc << "." << endl;
		k++;
	} 

	system("pause");
	return(0);
}

double getDistanceTraveled(double distance)
{
	const int a = 32;
	double time, IVelocity;

	{
		cout << "Please enter the time spent falling:" << endl;
		cin >> time;
		entries[i].timeEntered = time;
		cout << "Please enter the initial velocity." << endl;
		cin >> IVelocity;
		entries[i].InVel = IVelocity;

		distance = (time * IVelocity) + (a * (pow(time, 2)));
        entries[i].distanceCalc = distance;

		return(distance);
	}
}

double again(double distance)
{
	char YesNo = 'Y';

	cout << "Do you wish to run this program? Y/N" << endl;
	cin >> YesNo;

	if (YesNo == 'Y' || YesNo == 'y')
	{
		distance = getDistanceTraveled(distance);
		cout << "The distance fallen was: " << distance << "." << endl;
		i++;
		again(distance);
	}

	return(0);

}

