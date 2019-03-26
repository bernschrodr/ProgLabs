#include <iostream>
#include "menu.hpp"
#include <cfloat>
#include <string>

using namespace std;

    void Menu::Launch(){
            Start();
    }

    void Menu::Start()
    {   while(true){
        cout << "Сhoose what you want to do:" << endl
             << "(1) - work with Complex " << endl
             << "(2) - work with Queue" << endl
             << "------------------------------" << endl
             << "(9) - Exit" << endl;
        int input = 0;
        
        cin >> input;
        system("cls");
        switch (input)
        {
        case 1:
            ComplexStart();
            break;
        case 2:
            QueueCreate();
            break;
        
        case 9:
            return;

        default:
            WrongInput();
            break;
        }
    }
    }


    void Menu::QueueCreate()
    {   
        
        int size = 0;
        string inp = "";
        cout << "Enter Queue size:" << endl;

        cin >> inp;
        size = stoi(inp);

        while (sscanf(inp.c_str(), "%d", &size) != 1 || size < 2) {
            WrongInput(); // выводим сообщение об ошибке
        getline(cin, inp); // считываем строку повторно
    }
            queue que(size);
            QueueMenu(que);
        
    }

    void Menu::QueueMenu(queue &que)
    {   
        while(true){
            
        cout << "Choose what you want to do:" << endl
             << "(1) - Push " << endl
             << "(2) - Pop (pop all for reset queue)" << endl
             << "(3) - Get First" << endl
             << "(4) - Get Last" << endl
             << "(5) - Get Length" << endl
             << "(6) - Print all Queue" << endl << endl
             << "(9) - Return" << endl
             << "------------------------------" << endl;

            int operations = 0;
            cin >> operations;
            system("cls");
            switch (operations)
            {
                case 1:
                    Push(que);
                    break;
                
                case 2:
                    Pop(que);
                    break;

                case 3:
                    GetFirst(que);
                    break;

                case 4:
                    GetLast(que);
                    break;

                case 5:
                    GetLength(que);
                    break;

                case 6:
                    PrntQueue(que);
                    break;

                case 9:
                    return;

                default:
                WrongInput();
                    break;
            }
        }
    }

    void Menu::Push(queue &que)
    {
        cout << "Enter string for Push: " << endl
             << "(0) - Enter 0 for return" << endl;
        string input = "";
        while(input != "0"){
            if(input != "0"){
                cin >> input;
                que.push(input);
                }

        }
        return;
    }

    void Menu::Pop(queue &que){
        cout << "poped: " << que.getFirst() << endl;
        
        que.pop();
    }

    void Menu::GetFirst(queue &que){
        cout << endl << "Result : " << que.getFirst() << endl << endl;
    }

    void Menu::GetLast(queue &que){
        cout << endl << "Result : " << que.getLast() << endl << endl;
    }

    void Menu::GetLength(queue &que){
        cout << endl << "Result : " << que.getLength() << endl << endl;
    }

    void Menu::PrntQueue(queue &que){
        que.prnt();
    }

    // COMPLEX

    void Menu::ComplexStart(){
        comp first = ComplexCreate();
        ComplexMenu(first);
        return;
    }

    comp Menu::ComplexCreate(){
        while(true){
        double z = DBL_MIN;
        double zi = DBL_MIN;
        string inp = "";
        cout << "Enter real part: " << endl;
    
        cin >> inp;

        z = stod(inp);

        while (sscanf(inp.c_str(), "%d", &z) != 1 || z == DBL_MIN) { 
            WrongInput(); // выводим сообщение об ошибке
        getline(cin, inp); // считываем строку повторно
    }

        cout << "Enter complex part: " << endl;
        inp = "";

        cin >> inp;

        zi = stod(inp);

        while (sscanf(inp.c_str(), "%d", &zi) != 1 || zi == DBL_MIN) {
            WrongInput(); // выводим сообщение об ошибке
        getline(cin, inp); // считываем строку повторно
    }

            comp compNum(z,zi);
            return compNum;
            break;
        
    }
    }

    void Menu::ComplexMenu(comp &complexNum){
        while(true){
        cout << "Choose what you want to do:" << endl
             << "(1) - Sum " << endl
             << "(2) - Multiply on num" << endl
             << "(3) - Multiply on complex" << endl
             << "(4) - Get Length" << endl
             << "(5) - Print Complex" << endl
             << "------------------------------" << endl
             << "(9) - Return" << endl;

            int operations = 0;
            cin >> operations;
            system("cls");
            switch (operations)
            {
                case 1:
                    Sum(complexNum);
                    break;
                
                case 2:
                    MultiplyNum(complexNum);
                    break;

                case 3:
                    MultiplyComplex(complexNum);
                    break;

                case 4:
                    GetLength(complexNum);
                    break;

                case 5:
                    PrntComplex(complexNum);
                    break;

                case 9:
                    return;
                    

                default:
                WrongInput();
                    break;
            }
        }
    }

    void Menu::Sum(comp &complexNum){
        comp second = ComplexCreate();
        complexNum.sum(second);
        PrntComplex(complexNum);

    }

    void Menu::MultiplyNum(comp &complexNum){
        
        while(true)
        {   
            int num = 0;
            cout << "Enter num for multiply: " << endl;
            cin >> num;

            if(num == 0){
                WrongInput();
                continue;
            }

            complexNum.multiply(num);
            complexNum.prnt();
            break;
        }
        

    }

    void Menu::MultiplyComplex(comp &complexNum){
            cout << "Input second complex num for multiply" << endl;
            comp second = ComplexCreate();
            complexNum.multiply(second);
            complexNum.prnt();
        
    }

    void Menu::GetLength(comp &complexNum){
        cout << complexNum.abs() << endl;

    }

    void Menu::PrntComplex(comp &complexNum){
        complexNum.prnt();
    }

    void Menu::WrongInput(){
        cerr << "Wrong size, try again:" << endl;
    
};