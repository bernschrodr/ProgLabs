/* 
Variant 15
C -  Меняет значения двух переменных одного типа местами (swap)
F - Массив из N элементов типа T
*/
#include "Array.hpp"

using namespace std;

int main(int argc, char **argv)
{
    //SWAP
        int a, b;
    cout << "Enter 2 numbers for swap " << endl;
    cin >> a >> b;
    swap(a, b);
    cout << "first number: " << a << endl
         << "Second number: " << b << endl;
 
    //CLASS
    cout << "Enter size of array: " << endl;
    int size;
    cin >> size;

    Array<int> arr(size);

    int index;
    int value = -100;

    system("clear");
    while (value != 0)
    {
        cout << "FILL ARRAY" << endl
             << "Enter index and value" << endl
             << "Enter (0) as value if you want to continue" << endl;

        cout << "Index: " << endl;
        cin >> index;
        try
        {
            arr[index] = arr[index];
            cout << "Value: " << endl;
            cin >> value;
            if(value != 0)
                arr[index] = value;
        }
        catch (Ex &e)
        {
            switch (e.dataState)
            {
            case ArrayIndexOutOfBoundsException:
                cerr << "Index out of bounds " << endl;
                break;

            case NegativeArrayIndexException:
                cerr << "Negative index " << endl;

            default:
                break;
            }
        }
    }
    system("clear");
    while (true)
    {
        
        cout << "GET ELEMENTS" << endl
             << "Enter index of element in array: " << endl;
        cin >> index;
        
        try
        {
            cout << arr[index] << endl;
        }
        catch (Ex &e)
        {
            switch (e.dataState)
            {
            case ArrayIndexOutOfBoundsException:
                cerr << "Index out of bounds " << endl;
                break;

            case NegativeArrayIndexException:
                cerr << "Negative index " << endl;

            default:
                break;
            }
        }
    }
    return 0;
}