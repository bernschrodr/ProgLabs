#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main(){
    int n;
    char Inp[3][256],c;
    printf("enter first line for concatination (max 255 chars)\n");
    scanf("%255s", &Inp[0]);
    printf("enter second line for concatination (max 255 chars)\n");
    scanf("%255s", &Inp[1]);
    printf("enter how many characters of the second line to add\n");
    scanf("%d", &n);
    strncat(Inp[0],Inp[1],n);
    printf("result of concatination: %s \n\n",Inp[0]);

    strcpy(Inp[2],Inp[0]);
    printf("result of copy: %s \n\n",Inp[2]);

    printf("enter line for search first entry (max 255 chars)\n");
    scanf("%255s", &Inp[3]);

    printf("enter char for search first entry in string: \n");
    scanf(" %c", &c);
   

    printf("First entry: %d\n", strchr(Inp[3],c));
    printf("Length line1 in line2: %d\n", strspn(Inp[1],Inp[2]));
    printf("Leks line1: %s",strtok(Inp[1]," ,.-_/|"));

}   