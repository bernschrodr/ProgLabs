#include <stdio.h>
#include <math.h>

//Вариант 15

int main(void){
    double z1,z2,b;

    printf("Введите b: \n");
    scanf("%lf", &b);
    z1 = (sqrt(2*b+2*sqrt(b*b-4))) / (sqrt(b*b-4)+b+2);
    z2 = 1 / sqrt(b+2);
    printf("z1 = %lf\n z2 = %lf", z1, z2);
    return 0;

}