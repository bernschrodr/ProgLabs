#include "Trapeze.hpp"
#include <cmath>
#include <iostream>

using namespace std;

Trapeze::Trapeze(){
    this->lu_corner = CVector2D(0,0);
    this->ru_corner = CVector2D(0,0);
    this->ld_corner = CVector2D(0,0);
    this->rd_corner = CVector2D(0,0);
}

Trapeze::Trapeze(CVector2D &lu_corner, CVector2D &ru_corner, CVector2D &ld_corner, CVector2D &rd_corner)
{
    this->lu_corner = CVector2D(lu_corner);
    this->ru_corner = CVector2D(ru_corner);
    this->ld_corner = CVector2D(ld_corner);
    this->rd_corner = CVector2D(rd_corner);
    height = abs(ru_corner.y) + abs(rd_corner.y);
    top_line = abs(lu_corner.x) + abs(ru_corner.x);
    bottom_line = abs(ld_corner.x) + abs(rd_corner.x);
    this->mas = square();
};

const char *Trapeze::classname()
{
    return "Trapeze";
}

unsigned int Trapeze::size()
{
    return sizeof(Trapeze);
}

void Trapeze::initFromDialog()
{
    cout << "Enter x and y coords of left up corner" << endl;
    double x, y;
    cin >> x >> y;
    lu_corner.x = x;
    lu_corner.y = y;

    cout << "Enter x and y coords of right up corner" << endl;
    cin >> x >> y;
    ru_corner.x = x;
    ru_corner.y = y;

    cout << "Enter x and y coords of left down corner" << endl;
    cin >> x >> y;
    ld_corner.x = x;
    ld_corner.y = y;

    cout << "Enter x and y coords of start right down corner" << endl;
    cin >> x >> y;
    rd_corner.x = x;
    rd_corner.y = y;

    cout << "Enter mass of object in kg: " << endl;
    cin >> mas;

    height = abs(ru_corner.y) + abs(rd_corner.y);
    top_line = abs(lu_corner.x) + abs(ru_corner.x);
    bottom_line = abs(ld_corner.x) + abs(rd_corner.x);
}

double Trapeze::square()
{
    return (abs(lu_corner.x) + abs(ru_corner.x) + abs(ld_corner.x) + abs(rd_corner.x)) / 2 * lu_corner.y;
}

double Trapeze::perimeter()
{
    return top_line + bottom_line +
           sqrt(pow(abs(lu_corner.x) - abs(ld_corner.x), 2) + pow(height, 2)) +
           sqrt(pow(abs(ru_corner.x) - abs(rd_corner.x), 2) + pow(height, 2));
}

double Trapeze::mass()
{
    return this->mas;
}

CVector2D Trapeze::position()
{
    return CVector2D(top_line != bottom_line ?
    (height / 3) * (2 * max(top_line, bottom_line) + min(top_line, bottom_line)) /
    (top_line + bottom_line)
    : pow(top_line,2), ld_corner.x/2) ;
}

bool Trapeze::operator==(IPhysObject &ob)
{
    if (mas == ob.mass())
        return true;
    else
        return false;
}

bool Trapeze::operator<(IPhysObject &ob)
{
    if (mas < ob.mass())
        return true;
    else
        return false;
}

void Trapeze::draw()
{
    cout << "Mass: " << mass() << endl
         << "Square: " << square() << endl
         << "Height: " << height << endl
         << "Perimetr: " << perimeter() << endl
         << "Classname :" << classname() << endl
         << "Size: " << size() << " bytes" << endl
         << "Centre of mass: " << "x:" << position().x << " y:"
         << position().y << endl;
}