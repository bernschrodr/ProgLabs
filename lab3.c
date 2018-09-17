#include <stdio.h>
//Вариант 15

int main() {
    int hex, oct;
    printf("Введите целое шестнадцетиричное число");
    scanf("%X", &hex);
    printf("dec = %d \n", hex);
    printf("oct = %o \n", hex);
    printf("oct >> 3 = %o \n", hex >> 3);
    printf("oct = %o \n", hex);
    printf("!oct = %o \n", ~hex);
    scanf("%o", &oct);
    printf("hex || oct = %o \n", hex | oct);

    return 0;
}
