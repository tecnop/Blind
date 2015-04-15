#include <iostream>
#include <cstdlib>
#include <string>
#include <stdexcept>
#include <vector>

using namespace std;

template <class T>
class Stack {
	public :
		void push(T const&);
		T pop();
	private :
		vector<T> elems;


};
/*
template <typename T>
void Stack<T>::push(T const& elem){
	cout << "int" << endl;
	elems.push_back(elem);
}
*/


template <class T>
void Stack<T>::push(T const& elem){
	cout << "T" << endl;
	elems.push_back(elem);
}

template <>
void Stack<int>::push(int const& elem){
	cout << "int" << endl;
	elems.push_back(elem);
}

template <>
void Stack<float>::push(float const& elem){
	cout << "float" << endl;
	elems.push_back(elem);
}

template <class T>
T Stack<T>::pop() {
	return elems.size() > 0 ? elems.back() : NULL;
}




int main() {

	Stack<int> s;

	s.push(1);
	
	cout << s.pop() <<  endl;

	return 0;
}
