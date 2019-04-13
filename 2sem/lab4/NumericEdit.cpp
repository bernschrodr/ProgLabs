#include "NumericEdit.hpp"
#include <iostream>
#include <cstdlib>
#include <cmath>

using namespace std;

const string startvalue = "0.0";

NumericEdit::NumericEdit(const float &x, const float &y) : Edit(x, y, startvalue){};
NumericEdit::NumericEdit(const float &x, const float &y, const bool &save_flag) : Edit(x, y, startvalue, save_flag){};
NumericEdit::NumericEdit(const float &x, const float &y, const bool &save_flag, const bool &autofill_flag) : Edit(x, y, startvalue, save_flag, autofill_flag){};

NumericEdit::NumericEdit(const float &x, const float &y, const string &str) : Edit(x, y, str){};
NumericEdit::NumericEdit(const float &x, const float &y, const string &str, const bool &save_flag) : Edit(x, y, str, save_flag){};
NumericEdit::NumericEdit(const float &x, const float &y, const string &str, const bool &save_flag, const bool &autofill_flag) : Edit(x, y, str, save_flag, autofill_flag){};

NumericEdit::NumericEdit(const NumericEdit &obj)
{
    this->left = obj.left;
    this->right = obj.right;
    this->decimals = obj.decimals;
    this->reaction = obj.reaction;
    this->text = obj.text;
    this->autofill_flag = obj.autofill_flag;
    this->save_flag = obj.save_flag;
    this->coord = obj.coord;
};
NumericEdit::~NumericEdit(){};

void NumericEdit::SetLimit(const float &left, const float &right)
{
    this->left = left;
    this->right = right;
}

float NumericEdit::GetLeftBorder()
{
    return left;
}

float NumericEdit::GetRightBorder()
{
    return right;
}

void NumericEdit::SetReaction_error()
{
    reaction = 0;
}
void NumericEdit::SetReaction_ignore()
{
    reaction = 1;
}

void NumericEdit::SetReaction_round()
{
    reaction = 2;
}

void NumericEdit::GetReaction()
{
    switch (reaction)
    {
    case 0:
        cout << "Reaction: error" << endl;
        break;

    case 1:
        cout << "Reaction: ignore" << endl;
        break;

    case 2:
        cout << "Reaction: round" << endl;
        break;

    default:
        reaction = 0;
        cout << "Reaction: error" << endl;
        break;
    }
}

void NumericEdit::SetDecimals(int &decimals)
{
    this->decimals = decimals;
}

string NumericEdit::GetString()
{
    return text;
}

float NumericEdit::GetFloat()
{
    return stod(text);
}

int NumericEdit::GetDecimals()
{
    return decimals;
}

void NumericEdit::Input(const string &str)
{
    int whole;
    float num, dec;
    float count = 0;
    string out;
    string result;

    try
    {
        num = stod(str);
        dec = modf(num, &count);
        whole = (int)count;
        count = 0;
        if (dec != 0)
        {
            out = to_string(dec);
            if (num > 0)
            for(int i = 2; i < out.length(); ++i){
                if(out[i] != '0')
                    count++;
            }
            else
                for(int i = 3; i < out.length(); ++i){
                if(out[i] != '0')
                    count++;
            }

            if (count > decimals)
                if (num > 0)
                    for (int i = 1; i < decimals + 2; ++i)
                    {
                        result += out[i];
                    }
                else
                {
                    for (int i = 2; i < decimals + 3; ++i)
                    {
                        result += out[i];
                    }
                }
        }

        out = str;

        if (count > decimals || num < left || num > right)
        {
            switch (reaction)
            {
            case 0:
                error();
                return;

            case 2:
                if (num < left)
                    out = to_string(left);
                if (num > right)
                    out = to_string(right);
                if (count > decimals)
                    out = to_string(whole) + result;
                break;

            default:
                return;
            }
        }

        this->text = out;
        if(save_flag)
            this->history += out + "\n";
    }
    catch (invalid_argument e)
    {
        error();
    }
}

void NumericEdit::error()
{
    cout << "wrong number" << endl;
}

void NumericEdit::AutoFill(const string &str){
    if(autofill_flag){
        text = history;
        Input(str);
    }
    else
        cout << "Autofill is off" << endl;
};
