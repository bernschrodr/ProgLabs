#include <stdio.h>
//Вариант 15

int main() {
    int val,res;
    printf("Введите целое число\n");
    scanf("%d", &val);
    for (int i = 4; ((i > 1) && (res != 0)) ; i--){
        printf("%x", val & res);
    }
    printf("Если в следующей строке 0, значит введённое число входит в диапозон\n");
    printf("%d\n", res);


    return 0;
}