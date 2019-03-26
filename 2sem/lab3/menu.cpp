#include <iostream>
#include "queue.hpp"
#include "complex.hpp"
#include <climits>
#include <unistd.h>

using namespace std;

class Menu
{

  public:

    static void Start()
    {   
        while(true){
        cout << "Сhoose what you want to do:" << endl
             << "(1) - work with Complex " << endl
             << "(2) - work with Queue" << endl
             << "------------------------------" << endl
             << "(9) - Exit" << endl;
        int input = 0;
        cin >> input;
        switch (input)
        {
        case 1:
            ComplexCreate();
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


    static void QueueCreate()
    {   
        while(true){
        int size = 0;
        cout << "Enter Queue size:" << endl;
        cin >> size;
        if (size > 0)
        {
            queue que(size);
            QueueMenu(que);
            break;
        }
        else
        {
            WrongInput();
        }
    }
    }

    static void QueueMenu(queue &que)
    {   
        while(true){
        cout << "Сhoose what you want to do:" << endl
             << "(1) - Push " << endl
             << "(2) - Pop" << endl
             << "(3) - Get First" << endl
             << "(4) - Get Last" << endl
             << "(5) - Get Length" << endl
             << "(6) - Print all Queue" << endl
             << "------------------------------" << endl
             << "(9) - Return" << endl;

            int operations = 0;
            cin >> operations;
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

                case 9:
                    return;

                default:
                WrongInput();
                    break;
            }
        }
    }

    static void Push(queue &que)
    {
        cout << "Enter string for Push: " << endl
             << "(1) - Enter 1 for return";
        string input = "";
        while(input != "1"){
            cin >> input;
            cout << input << endl;
            que.push(input);
        }
        return;
    }

    static void Pop(queue &que){
        cout << "poped: " << endl;
        GetFirst(que);
        que.pop();
    }

    static void GetFirst(queue &que){
        cout << que.getFirst() << endl;
    }

    static void GetLast(queue &que){
        cout << que.getLast() << endl;
    }

    static void GetLength(queue &que){
        cout << que.getLength() << endl;
    }

    static void PrntQueue(queue &que){
        que.prnt();
    }

    // COMPLEX

    static void ComplexStart(){
        comp first = ComplexCreate();
        ComplexMenu(first);
        return;
    }

    static comp ComplexCreate(){
        while(true){
        double z = INT_MIN;
        double zi = INT_MIN;
        cout << "Enter real part: " << endl;
        cin >> z;
        if (z == INT_MIN)
        {
            WrongInput();
            continue;
        }

        cout << "Enter complex part: " << endl;
        cin >> zi;
        if (zi == INT_MIN)
        {
            WrongInput();
            continue;
        }

            comp compNum(z,zi);
            return compNum;
            break;
        
    }
    }

    static void ComplexMenu(comp &complexNum){
        while(true){
        cout << "Сhoose what you want to do:" << endl
             << "(1) - Sum " << endl
             << "(2) - Multiply on num" << endl
             << "(3) - Multiply on complex" << endl
             << "(4) - Get Length" << endl
             << "(5) - Print Complex" << endl
             << "------------------------------" << endl
             << "(9) - Return" << endl;

            int operations = 0;
            cin >> operations;
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

    static void Sum(comp &complexNum){
        comp second = ComplexCreate();
        complexNum.sum(second);
        PrntComplex(complexNum);

    }

    static void MultiplyNum(comp &complexNum){
        
        while(true)
        {   
            int num = 0;
            cout << "Enter num for multiply: " << endl;
            if(num == 0){
                WrongInput();
                continue;
            }

            complexNum.multiply(num);
            complexNum.prnt();
            break;
        }
        

    }

    static void MultiplyComplex(comp &complexNum){
            cout << "Input second complex num for multiply" << endl;
            comp second = ComplexCreate();
            complexNum.prnt();
        
    }

    static void GetLength(comp &complexNum){
        cout << complexNum.abs() << endl;

    }

    static void PrntComplex(comp &complexNum){
        complexNum.prnt();
    }

    static void WrongInput(){
        cout << "Wrong size, try again:" << endl;
    }
};