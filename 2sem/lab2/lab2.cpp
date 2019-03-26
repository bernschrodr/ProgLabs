#include <iostream>
#include "procedures2.hpp"
using namespace std;

int main(){
    comp c1(15.156, -2.123), c2(-23124, -20.1);
    comp c3 = c1 * c2;
    cout << c3.z;
    if(c3.zi >= 0)
        cout << "+";
    cout << c3.zi << "i" << endl;

    comp c4 = c1 + c2;
    cout << c4.z;
    if(c4.zi >= 0)
        cout << "+";
    cout << c4.zi << "i" << endl;

    cout << double(c4) << endl;

    queue Queue;
    int temp;
    Queue << 10;
    Queue << 290;
    cout << (Queue >> temp) << endl;


    return 0;

}