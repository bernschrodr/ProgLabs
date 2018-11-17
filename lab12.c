#include <stdio.h>
#include <windows.h>
#include <direct.h>

int main(int argc, char **argv)
{
    FILE *fout;
    fout = fopen("info.txt", "w");

    for (int i = 1; i < argc; i++)
    {
        mkdir(argv[i]);
    };

    
    char current_work_dir[FILENAME_MAX];
    _getcwd(current_work_dir, sizeof(current_work_dir));
    strcat(current_work_dir, "\\*");

    WIN32_FIND_DATA FindFileData;
	HANDLE hf;
	hf=FindFirstFile(current_work_dir, &FindFileData);
	if (hf!=INVALID_HANDLE_VALUE)
	{
		do
		{
			if(strchr(FindFileData.cFileName, '.') == NULL)
            fprintf(fout,"%s\n", FindFileData.cFileName);
		}
		while (FindNextFile(hf,&FindFileData)!=0);
		FindClose(hf);
	}

    
    return 0;
}
