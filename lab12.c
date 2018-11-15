#include <stdio.h>
#include <windows.h>
#include <fileapi.h>

int main(int argc, char **argv)
{
    FILE *fout;
    fout = fopen("info.txt", "w");
    int i;

    printf("%d\n", argc);
    for (i = 1; i < argc; i++)
    {
        mkdir(argv[i]);
        fprintf(fout, "%s\n", argv[i]);
    }

LPWIN32_FIND_DATA data;
HANDLE h = FindFirstFile( "*.*", &data );
if( data.dwFileAttributes | FILE_ATTRIBUTE_DIRECTORY )

        return 0;
    }
