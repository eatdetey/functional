%Максимум 2-х
max(X,Y,X) :- X > Y, !.
max(_,Y,Y).

%Максимум 3-х
max(X,Y,Z,U) :-
    max(X,Y,M), max(M,Z,U).

%Альтернативно
maxA(X,Y,Z,U) :- X>Y, X>Z, !.
maxA(_,Y,Z,Y) :- Y>Z, !.
maxA(_,_,Z,Z).

%Сумма цифр numSum(+N,?S), вверх
numSumUp(0,0):-!.
numSumUp(N,S):- Num is N mod 10,
    NewN is N div 10, numSum(NewN,NewS), 
    S is NewS+Num.

%Сумма цифр numSum(+N,?S), вниз
numSumDown(X,Answer):-
    numSumDownInner(X,0,Answer).
numSumDownInner(0,Acc,Acc):-!.
numSumDownInner(X,Acc,Answer):-
    X1 is X div 10,
    Acc1 is Acc + (X mod 10),
    numSumDownInner(X1,Acc1,Answer).

%Свой append()
myappend([],Y,Y).
myappend([X|T],Y,[X|T1]):-myappend(T,Y,T1).

%Свой in_list (есть ли в списке)
in_list([],_) :- false.
in_list([X|T],X).
%in_list([X|T],X):-X.
in_list([_|T],X) :- in_list(T,X).