#include <stdio.h>
#include <math.h>
#include "rhomb.h"



int main()
{

struct rhomb Rhomb;

Rhomb.a.x = 2.0;
Rhomb.a.y = 4.0;
Rhomb.b.x = 4.0;
Rhomb.b.y = 8.0;
Rhomb.c.x = 6.0;
Rhomb.c.y = 4.0;
Rhomb.d.x = 4.0;
Rhomb.d.y = 0.0;


init(&Rhomb);

printf("Square: %f \nPerimetr: %f \n", Square(Rhomb), Perimetr(Rhomb));
printf("%f", Rhomb.aLength);

}