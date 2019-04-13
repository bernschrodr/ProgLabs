#include <iostream>
#include "NumericEdit.hpp"
#include <windows.h>
using namespace std;

int main(int argc, char const *argv[])
{
    //EDIT CLASS WORKING

    Edit *form;
    cout << "Create Edit class object:" << endl
         << "Enter coordinate x and y of left up corner:" << endl;
    string input_1;
    int x, y;
    cin >> x >> y;

    form = new Edit(x, y, true, true);
    Coordinate crd = form->GetCoord();
    cout << "Coordinates: x = " << crd.x << ", y = " << crd.y << endl;

    int count;
    cout << "Enter how many strings you want to add in form:" << endl;
    cin >> count;

    cout << "Enter " << count << " strings in form:" << endl;
    input_1 = "";
    for (int i = 0; i < count; ++i)
    {
        cin >> input_1;
        form->Input(input_1);
    }
    cout << endl;

    cout << "Text in form : " << form->text << endl;

    cout << "History of inputs: " << endl;
    cout << form->history << endl;

    cout << "Enter num for Autofill form from input and history: " << endl;
    cin >> input_1;
    cout << endl;
    form->AutoFill(input_1);
    cout << "Text in form after Autofill :" << endl
         << form->text << endl
         << endl
         << endl;

    //NUMERIC EDIT CLASS WORKING
    cout << "Created NumericEdit class object" << endl;
    NumericEdit *numform = new NumericEdit(0, 0,true,true);

    int left,right;
    cout << "Set left and right border of num: " << endl;
    cin >> left >> right;
    numform->left = left;
    numform->right = right;

    int dec;
    cout << "Set decimals places" << endl;
    cin >> dec;
    numform->SetDecimals(dec);
    cout << "Decimals after set : " << numform->GetDecimals() << endl;

    int reaction;
    cout << "Set reaction for out of range error " << endl
    << "(0) - error message" << endl << "(1) - ignore" << endl << "(2) - round" << endl;
    cin >> reaction;
    switch (reaction)
    {
        case 0:
            numform->SetReaction_error();
            break;

        case 1:
            numform->SetReaction_ignore();
            break;

        case 2:
            numform->SetReaction_round();
            break;
            
        default:
            numform->SetReaction_error();
            break;
    }

    cout << "Enter count of numbers for input in form: " << endl;
    count = 0;
    cin >> count;
    for(int i = 0; i < count; ++i){
        string input;
        cin >> input;
        numform->Input(input);
    }

    cout << "History :\n" << numform->history << endl;
    cout << "String in form " << numform->GetString() << endl;
    cout << "Num in form " << numform->GetFloat() << endl << endl;

    cout << "Enter num for Autofill form from input and history: " << endl;
    string input;
    cin >> input;
    numform->AutoFill(input);
    cout << "History after autofill: " << endl <<numform->history << endl;

    Sleep(150000);

    return 0;
}
