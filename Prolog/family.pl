man(andrey).
man(ervand).
man(alex).
man(david).
man(saur).
man(kirill).
man(denis).

woman(mary).
woman(helena).
woman(tatyana).
woman(anna).
woman(larila).

married(andrey, mary).
married(ervand, helena).
married(alex, tatyana).
married(kirill, larila).

parent(andrey, david).
parent(mary, david).
parent(ervand, denis).
parent(helena, denis).
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
mother(X) :- mother(Y, X), write(Y).

brother(X, Y) :- man(X), parent(Z, X), parent(Z, Y), X \= Y.

brothers(X) :- setof(Y, brother(Y, X), L), write_list(L).
brothers(_).

b_s(X, Y) :- parent(Z, X), parent(Z, Y), X \= Y.

b_s(X) :- setof(Y, b_s(Y, X), L), write_list(L).
b_s(_).

father(X,Y) :- man(X), parent(X, Y).
father(X) :- father(Y, X), write(Y).

sister(X, Y) :- parent(Z, X), parent(Z, Y), X \= Y, woman(X).

sisters(X) :- setof(Y, sister(Y, X), L), write_list(L).
sisters(_).

grand_so(X, Y) :- man(X), parent(Y, Z), parent(Z, X).

grand_sons(X) :- setof(Y, grand_so(Y, X), L), write_list(L).
grand_sons(_).

grand_pa_and_son(X, Y) :- grand_so(Y, X) ; grand_so(X, Y).

uncle(X, Y) :- man(X), parent(Z, Y), parent(Z, W), brother(X, W).

nephews(X) :- setof(Y, uncle(X, Y), L), write_list(L).
nephews(_).

write_list([]).
write_list([H|T]) :-
    write(H), nl,
    write_list(T).