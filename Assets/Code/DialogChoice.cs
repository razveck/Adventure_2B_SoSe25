using UnityEngine;
using UnityEngine.Events;

//attributes
[System.Serializable] //sagt unity, dass die Klasse gespeichert werden darf (und damit angezeigt)
public class DialogChoice {

	public string name;
	public DialogLine nextLine;
	public UnityEvent onSelected;
}

//vererben/inheritance
class Animal {
	public void Drink() { }
	public void Eat() { }
}

class Dog : Animal {
	public void Bark() { }
}

class Cat : Animal {
	public void Meow() { }
}

class GingerCat : Cat{

}