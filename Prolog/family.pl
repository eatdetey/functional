man(andrey).
man(ervand).
man(alex).
man(david).
man(saur).
man(kirill).

woman(mary).
woman(helena).
woman(tatyana).
woman(anna).
woman(larila).

married(andrey, mary).
married(ervand, helena).
married(alex, tatyana).

parent(andrey, david).
parent(mary, david).
parent(ervand, anna).
parent(helena, anna).
parent(ervand, larila).
parent(helena, larila).
parent(alex, andrey).
parent(tatyana, andrey).
parent(alex, kirill).
parent(tatyana, kirill).
parent(larila, saur).
parent(kirill, saur).

men :- man(X), write(X), nl, fail.
men.

women :- woman(X), write(X), nl, fail.
women.

children(X) :- parent(X, Y), write(Y), nl, fail.
children(_).

mother(X, Y) :- woman(X), parent(X, Y).

mother(X) :- mother(Y, X), write(Y), nl, fail.
mother(_).

brother(X, Y) :- man(X), parent(Z, X), parent(Z, Y), X \= Y.

brothers(X) :- brother(Y, X), write(Y), nl, fail.
brothers(_).

b_s(X, Y) :- parent(Z, X), parent(Z, Y), X \= Y.

b_s(X) :- b_s(Y, X), write(Y), nl, fail.
b_s(_).
