#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main()
{
    char Inp[256] = {0};
    int i = 0,
        dig = 0,
        chr = 0,
        Bchr = 0;
    printf("Enter string\n");
    scanf("%s", &Inp[0]);
    while (Inp[i] != 0)
    {
        if (Inp[i] > 47 && Inp[i] < 58)
            dig++;
        else if (Inp[i] > 64 && Inp[i] < 91)
            Bchr++;
        else if (Inp[i] > 96 && Inp[i] < 123)
            chr++;
        i++;
    }

    printf("%d Digits\n", dig);
    printf("%d Letter\n", chr);
    printf("%d Big Letter", Bchr);
}