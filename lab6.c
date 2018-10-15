#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>

int main() {
	char *Arr;
	Arr = (char*)malloc(5 * sizeof(char));

	Arr[0] = { 'W' };
	Arr[1] = { 'O' };
	Arr[2] = { 'R' };
	Arr[3] = { 'K' };

	for (int i = 0; i < 4; ++i)
		printf("%c ", *(Arr + i));

	free(Arr);
	return 0;

}

