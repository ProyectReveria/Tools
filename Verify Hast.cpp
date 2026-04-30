#include <iostream>
#include <string> 
#include <string_view>

int main(){
    std::string mindA; 
    std::string mindb; 

    std::cout << "inserte el primer Hash code" << std::endl; 
    std::cin >> mindA; 
    std ::cout << "inserte el segundo has code" << std::endl; 
    std::cin >> mindb; 

    std :: cout << (std::string_view(mindA) == std::string_view(mindb) ? "valido" : "invalido") << std::endl; 
    return 0; 
}
