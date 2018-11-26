#ifndef MATH
#define MATH
#include <math.h>
#endif

#ifndef RHOMBSOURCE
#define RHOMBSOURCE
#include "rhomb.c"

#endif

#ifndef RHOMB
#define RHOMB

extern struct coord
{
    double x, y;
};

extern struct rhomb
{
    struct coord a, b, c, d;
    double aLength, bLength, cLength, dLength, acDiag, bdDiag;
};

double Square(struct rhomb rh);
double Perimetr(struct rhomb rh);
int init(struct rhomb *rh);

#endif

