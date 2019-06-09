#include <iostream>
#include "Trapeze.hpp"
#include "Line.hpp"

using namespace std;

void centre_of_mass(vector<Trapeze> &trapezes, vector<Line> &lines);
void showAll(vector<Trapeze> &trapezes, vector<Line> &lines);

int main(int argc, char const *argv[])
{
    vector<Trapeze> TrapezeArr;
    vector<Line> LinesArr;
    int input;

    while(true){
    cout << "\nCreate a figure\n"
         << "(1) - Trapeze \n(2) - Line \n(3) - Calculate center of mass \n(4) - Show all figures" << endl;
    cin >> input;
    switch (input)
    {
    case 1:
        TrapezeArr.push_back(*new Trapeze);
        TrapezeArr.back().initFromDialog();
        break;
    
    case 2:
        LinesArr.push_back(*new Line);
        LinesArr.back().initFromDialog();
        break;

    case 3:
        centre_of_mass(TrapezeArr, LinesArr);
        break;

    case 4:
        system("cls");
        showAll(TrapezeArr, LinesArr);
        break;

    default:
        return 1;
    }
    }
    /*
    0 10
    10 10
    -5 0
    15 0
    */
    return 0;
}

void centre_of_mass(vector<Trapeze> &trapezes, vector<Line> &lines)
{
    double summMassMultPositionX = 0;
    double summMassMultPositionY = 0;
    double summMass = 0;
    CVector2D centreMass;

    for (auto tr : trapezes)
    {
        summMass += tr.mass();
        summMassMultPositionX += tr.mass() * tr.position().x;
        summMassMultPositionY += tr.mass() * tr.position().y;
    }

    for (auto ln : lines)
    {
        summMass += ln.mass();
        summMassMultPositionX += ln.mass() * ln.position().x;
        summMassMultPositionY += ln.mass() * ln.position().y;
    }

    centreMass.x = summMassMultPositionX / summMass;
    centreMass.y = summMassMultPositionY / summMass;

    system("cls");
    cout << "\nHere are coordinates Mass Centre of your system\n";

    cout << "x: " << centreMass.x << endl;
    cout << "y:" << centreMass.y << endl;
}


void showAll(vector<Trapeze> &trapezes, vector<Line> &lines) {
    cout<<"Here are your Trapezes\n";
    for (auto tr : trapezes){
        tr.draw();
        cout<<endl;
    }
    cout<<"Here are your Lines\n";
    for (auto ln : lines){
        ln.draw();
        cout<<endl;
    }
}