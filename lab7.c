#include <stdio.h>
#include <string.h>
#include <stdlib.h>

   enum Genres
    {
        classic,
        pop,
        rock,
        rap,
        new_age,
        electronic
    };

    struct Coordinate
    {
        float x,y;
    };

    struct Triangle
    {
        Coordinate a,b,c;
    };

    float distance(Coordinate a, Coordinate b){
    float dx = a.x - b.x;
    float dy = a.y - b.y;
    return sqrt(dx * dx + dy * dy);
};

    float Perimetr(Triangle){
    float ab = distance(Triangle.a, Triangle.b);
    float bc = distance(Triangle.b, Triangle.c);
    float ca = distance(Triangle.b, Triangle.a);
    return ab + bc + ca;
};

int main(){

    enum Genres Music;
    Music = rock;
    if (Music == rock)
        printf("%d", Music);

        Triangle Tr = {
        {-2, -1},
        {0, 4},
        {4, -2}
    };

    float p = Perimetr(Tr);
    printf("Perimetr: %f \n", p);
    
}