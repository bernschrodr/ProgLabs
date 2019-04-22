#include <iostream>
#include "Trapeze.hpp"
#include "Line.hpp"

using namespace std;

int main(int argc, char const *argv[])
{   
    Trapeze *tr = new Trapeze();
    Line *ln = new Line();
    /*
    0 10
    10 10
    -5 0
    15 0
    */
    tr->initFromDialog();
    tr->draw();
    ln->initFromDialog();
    ln->draw();
    
}