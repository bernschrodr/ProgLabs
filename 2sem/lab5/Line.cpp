    #include "Line.hpp"
    #include <cmath>
    #include <iostream>

    using namespace std;

    Line::Line(){
        this->start = new CVector2D(0,0);
        this->end = new CVector2D(0,0);
    }

    Line::Line(CVector2D &A, CVector2D &B){
        this->start = new CVector2D(start->x,start->y);
        this->end = new CVector2D(start->x,start->y);
    }

    const char* Line::classname(){
        return "Line";
    }

    unsigned int Line::size(){
        return sizeof(Line);
    }

    void Line::initFromDialog(){
        cout << "Enter x and y coords of start" << endl;
        double x,y;
        cin >> x >> y;
        start->x = x;
        start->y = y;

        cout << "Enter x and y coords of start end" << endl;
        cin >> x >> y;
        end->x = x;
        end->y = y;

        cout << "Enter mass of object in kg: " << endl;
        cin >> mas;

    }

    double Line::square(){
        return 0;
    }

    double Line::perimeter(){
        return sqrt(pow(start->x - end->x,2)+ pow(start->x - end->x,2));
    }

    double Line::mass(){
        return mas;
    }

    CVector2D Line::position(){
        return CVector2D(abs(start->x - end->x)/2, abs(start->x - end->x)/2);
    }

    bool Line::operator==(IPhysObject& ob ){
        if(mass() == ob.mass())
            return true;
        else
            return false;
    }

    bool Line::operator<(IPhysObject& ob ){
        if(mass() < ob.mass())
            return true;
        else
            return false;

    }

    void Line::draw(){
        cout << "Mass: " << mass() << endl
        << "Square: " << square() << endl
        << "Perimetr: " << perimeter() << endl
        << "Classname: " << classname() << endl
        << "Size: " << size() << endl
        << "Centre of mass: " << position().x
        << " " << position().y << endl;
    }