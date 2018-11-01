#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>

enum Genres
{
    classic,
    pop,
    rock,
    rap,
    new_age,
    electronic
};

typedef struct
{
    float x, y;
} Coordinate;

typedef struct
{
    Coordinate a, b, c;
} Triangle;

float distance(Coordinate a, Coordinate b)
{
    float dx = a.x - b.x;
    float dy = a.y - b.y;
    return sqrt(dx * dx + dy * dy);
}

float Perimeter(Triangle trg)
{
    float ab = distance(trg.a, trg.b);
    float bc = distance(trg.b, trg.c);
    float ca = distance(trg.b, trg.a);
    return ab + bc + ca;
}

struct Card
{
    unsigned State : 1;
    unsigned SD : 1;
    unsigned CompactFlash : 1;
    unsigned MemoryStick : 1;
};

int main()
{
    //Task1
    enum Genres Music;
    Music = rock;
    if (Music == rock)
        printf("Number of genre: %d\n\n", Music);

    //Task2

    Triangle trg = {
        {-7, -4},
        {2, 5},
        {9, -3}};

    float p = Perimeter(trg);
    printf("Perimeter = %f\n\n", p);

    //Task3
    int Hex;
    printf("Enter Hex:\n");
    scanf("%x", &Hex);

    struct Card Inp = {Hex >> 3, (Hex % 8) >> 2, (Hex % 4) >> 1, (Hex % 2)};

    

    Inp.State == 1 ? printf("Card Reader is on (+)\n") : printf("Card Reader is off (-)\n");
    Inp.SD == 1 ? printf("SD Card is active (+)\n") : printf("SD Card isn't active (-)\n");
    Inp.CompactFlash == 1 ? printf("Compact Flash is active (+)\n") : printf("Compact Flash isn't active (-)\n");
    Inp.MemoryStick == 1 ? printf("Memory Stick is active (+)\n") : printf("Memory Stick isn't active (-)\n");

    //printf("State %x %x %x %x\n", Inp.State, Inp.SD, Inp.CompactFlash, Inp.MemoryStick);
}