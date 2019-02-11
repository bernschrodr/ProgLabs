#include <stdio.h>
//Вариант 15

int main() {

    int val,val2;
    printf("Input value\n");
    scanf("%d", &val);
    switch((char)val)
    {
        case -1:
            printf("True\n");
            break;
        case -2:
            printf("True\n");
            break;
        case -3:
            printf("True\n");
            break;
        case -4:
            printf("True\n");
            break;
        default:
			printf("False\n");
            break;
    }

    printf("Input value\n");
    scanf("%d", &val2);
    if(val2 >= 16384)
    {
        val2 = val2 >> 14;
        val2 = val2 & 1;
        printf("%X", val2);
    }
    else
    {
        printf("The number does not have 15 bits");
    }

    return 0;
}
