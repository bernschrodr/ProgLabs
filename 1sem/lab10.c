#include <stdio.h>

int min(int a, int b)
{
    return a < b ? a : b;
}

int max(int a, int b)
{
    return a < b ? b : a;
}

int maxNOD(int a, int b)
{
    int max = 0;
    for (int i = 1; i <= min(a, b); i++)
    {

        if ((a % i == 0) && (b % i == 0) && (i > max))
        {
            max = i;
        }
    }

    return max;
}

int minKR(int a, int b)
{
    if(a == 1 || b == 1)
    return 1;
    
    int minv = 2147483647;

    for (int i = 2; i <= min(a, b); i++)
    {

        if ((a % i == 0) && (b % i == 0) && (i < minv))
        {
            minv = i;
            break;
        }
    }

    return minv;
}

int count = 0;
int DeleteSpaces(char inp[255])
{

    count = 0;
    for (int i = 1; i < strlen(inp); i++)
    {
        if ( ( (inp[i - 1] == ' ' || inp[i - 1] == '"') && inp[i] == ' ')
        || ((inp[i - 1] == '.') && (inp[i] == ' ') && (inp[i + 1] == '\0')) )
        {
            count++;
            for (int j = i; j < strlen(inp); j++)
            {
                inp[j] = inp[j + 1];
            }
        }
    }

    if (count != 0)
        DeleteSpaces(inp);

    return count;
}

int main()
{   
    int a, b;
    char c[255];
    printf("Enter a for NOD:\n");
    scanf("%d", &a);
    printf("Enter b for NOD:\n");
    scanf("%d", &b);

    printf("NOD: %d\n", maxNOD(a, b));
    printf("minKR: %d\n", minKR(a, b));

    printf("Enter string for spaces delete\n");
    scanf(" %[^\t\n]s", &c);
    DeleteSpaces(c);
    printf("%s\n", c);

    return 0;
}