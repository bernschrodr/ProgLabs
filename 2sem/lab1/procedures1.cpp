#include "procedures1.hpp"
void suml(int &a, int b)
{
    a += b;
}

void sump(int *a, int b)
{
    *a += b;
}

void negl(int &a)
{
    a = -a;
}

void negp(int *a)
{
    *a = -(*a);
}

void multiplyMatrixl(int a[3][3], int b)
{
    for (int i = 0; i < 3; ++i)
        for (int j = 0; j < 3; ++j)
            a[i][j] *= b;
}

void multiplyMatrixp(int **a, int b)
{
    for (int i = 0; i < 3; ++i)
        for (int j = 0; j < 3; ++j)
            a[i][j] *= b;
}

void complexl(struct comp &a)
{
    a.zi = -(a.zi);
}

void complexp(struct comp *a)
{
    a->zi = -(a->zi);
};
