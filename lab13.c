#include<stdio.h>
#include <string.h>

void main(int argc,char argv[])
{
    FILE *fin;
    char FileName[1][256];
    if (strlen(argv[1]) > 0)
    {
    strncpy(FileName, strchr(argv[1], '='), 10);
    printf("%s", FileName);
    fin = fopen(FileName[1], "rwb");
    fclose(fin);
    
    }
}