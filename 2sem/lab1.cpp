#include <iostream>
#include "procedures1.h"
using namespace std;

int main()
{
    int a, b;
    int *a_pointer = &a;

    cout << "Enter first num:" << endl;
    cin >> a;
    cout << "Enter num for (sum,multiply):" << endl;
    cin >> b;

    sump(a_pointer, b);
    cout << "\nSums: \n"
         << *(a_pointer) << endl;

    suml(a, b);
    cout << *(a_pointer) << endl;

    negp(a_pointer);
    cout << "\nNegative: \n"
         << *(a_pointer) << endl;

    negl(a);
    cout << *(a_pointer) << endl;

    //Matrix
    cout << "\nEnter 9 nums for matrix 3x3:" << endl;
    int **matrix = new int *[3];
    for (int i = 0; i < 3; ++i)
        matrix[i] = new int[3];

    for (int i = 0; i < 3; ++i)
        for (int j = 0; j < 3; ++j)
        {
            int inp;
            cin >> inp;
            matrix[i][j] = inp;
        }

    int matrix2[3][3];
    for (int i = 0; i < 3; ++i)
        for (int j = 0; j < 3; ++j)
        {
            matrix2[i][j] = matrix[i][j];
        }

    cout << "\nMultiplied Matrixes:" << endl;

    multiplyMatrixl(matrix2, b);
    for (int i = 0; i < 3; ++i)
        for (int j = 0; j < 3; ++j)
        {
            if (j == 0)
                cout << "|";
            cout << matrix2[i][j] << " ";
            if (j == 2)
                cout << "|\n";
        }

    cout << endl;

    multiplyMatrixp(matrix, b);
    for (int i = 0; i < 3; ++i)
        for (int j = 0; j < 3; ++j)
        {
            if (j == 0)
                cout << "|";
            cout << matrix[i][j] << " ";
            if (j == 2)
                cout << "|\n";
        }

    //Complex
    cout << "\nEnter 2 complex nums part:" << endl;
    comp complnum;
    comp *compl_pointer = &complnum;
    cin >> complnum.z >> complnum.zi;

    complexl(complnum);
    cout << complnum.z;
    if (complnum.zi > 0)
        cout << "+";
    cout << complnum.zi << "i";

    complexp(compl_pointer);
    cout << endl
         << complnum.z;
    if (complnum.zi > 0)
        cout << "+";
    cout << complnum.zi << "i";

    return 0;
}
