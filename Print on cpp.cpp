#include <iostream> 
#include <string> 
#define Gustom_Simplify_code

#ifdef Gustom_Simplify_code

template<typename t,std::size_t n> 

constexpr std::size_t length(t (&)[n]){
    return n;
}

void print(std::string *text){
    if (text == nullptr){
        std::cout << "Invalid action: std string is have null reference";
         return; 
    }
    std::cout << *text; 
}

#endif 




