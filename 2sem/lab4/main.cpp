#include <iostream>
#include "Edit.hpp"
#include <windows.h>
using namespace std;

int main(int argc, char const *argv[])
{
   Edit *form;
   form = new Edit(0,0,"privet",true);
   form->Input("asd");
   cout << form->text << form->history << endl;

    Sleep(5000);

    return 0;
}
