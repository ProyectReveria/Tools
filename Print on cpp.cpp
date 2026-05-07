#include <iostream> 
#include <string> 

void print(std::string *text){
    if (text == nullptr){
        std::cout << "Invalid action: std string is have null reference";
         return; 
    }
    std::cout << *text; 
}

void print_Np(std::string Text){
    std::cout << Text; 
}

int main(){ 
    std::string hw = "hello world";
    std::string *Phw = &hw; 
    print(Phw); 
    return 0; 
}


