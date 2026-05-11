#include <iostream>

class MyClass{
public:

static void PrintF(std::string text){
std::cout << text;
}
};

int main(){
MyClass::PrintF("Hola mundo");

return 0;
}