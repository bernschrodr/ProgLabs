#include "Edit.hpp"

class NumericEdit : public Edit
{ 
private:
    /* data */
public:
    float left,right;

    NumericEdit(/* args */);
    ~NumericEdit();
    
    void SetLimit(const int &left,const int &right);
    void SetLimit(const float &left, const float &right);
    void SetLimit(const int &left, const float &right);
    void SetLimit(const int &right, const float &left);
    float GetLeftBorder();
    float GetRightBorder();
    string GetReaction();
    void SetReaction_round();
    void SetReaction_ignore();
    void SetReaction_error();
    int GetDecimals();
    void SetDecimals(int &decimals);
    string GetString();
    int GetInt();

};