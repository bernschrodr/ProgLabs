#include <iostream>
#include <vector>
#include "algh.hpp"
#include "Pointt.hpp"

using namespace std;

int main()
{
    vector<int> v;

    v.push_back(5);
    v.push_back(2);
    v.push_back(10);
    v.push_back(25);

    cout << "Standart:" << endl
         << is_partitioned(v, [](int i) { return i % 5 == 0; }) << endl
         << all_of(v, [](int a) { return a % 5 == 0; }) << endl
         << *find_backward(v, 15) << endl
         << endl;

    vector<Pointt> point;

    point.push_back(Pointt(12.0, 12.0));
    point.push_back(Pointt(12.0, 12.0));
    point.push_back(Pointt(2.0, 0.0));
    point.push_back(Pointt(0.0, 0.0));
    point.push_back(Pointt(0.0, 0.0));
    point.push_back(Pointt(0.0, 0.0));

    cout << "Custom:" << endl
         << is_partitioned(point, [](Pointt vec) { return vec.length() == 0.0; }) << endl
         << all_of(point, [](Pointt vec) { return vec.length() == 0.0; }) << endl
         << find_backward(point, Pointt(12.0, 12.0))->to_str() << endl;

    return 0;
}