#include <iostream>
#include "Trapeze.hpp"
#include "Line.hpp"

using namespace std;

int main(int argc, char const *argv[])
{   
    Trapeze *tr = new Trapeze();
    Line *ln = new Line();
    
    tr->initFromDialog();
    tr->draw();
    ln->initFromDialog();
    ln->draw();
    
}