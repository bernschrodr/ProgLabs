#include <stdio.h>

int main(void)
{
    char symb[2];
    float val;

    printf("Введите символ \n");
    fgets(symb, 2, stdin);
    printf("Введите вещественное число \n");
    scanf("%f", &val);
    printf("Символ - %s \nЧисло - %f \n", symb, val);

return 0;

}