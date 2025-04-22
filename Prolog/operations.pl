:- encoding(utf8).

:- set_prolog_flag(encoding, utf8).
:- set_stream(user_output, encoding(utf8)).

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

%Факториал
factorial(N, F) :- factorial(N, 1, F).

factorial(0, Acc, Acc).
factorial(N, Acc, F) :-
    N > 0,
    Acc1 is Acc * N,
    N1 is N - 1,
    factorial(N1, Acc1, F).

%Проверка на свободность от квадратов
free_from_squares(N) :- free_from_squares(N, 2).

free_from_squares(N, D) :-
    D*D > N, !. 
free_from_squares(N, D) :-
    R is N mod (D*D),
    R \= 0,
    D1 is D + 1,
    free_from_squares(N, D1).

%Чтение списка с клавиатуры
read_list(List) :- read_list([], List).

read_list(Acc, List) :-
    read(X),
    ( X = end -> reverse(Acc, List)
    ; read_list([X|Acc], List)
    ).

%Вывод списка
write_list([]).
write_list([H|T]) :-
    write(H), nl,
    write_list(T).

%Предикат sum_list_down(+List,?Summ)
sum_list_down(List, Summ) :- sum_list_down(List, 0, Summ).

sum_list_down([], Acc, Acc).
sum_list_down([H|T], Acc, Summ) :-
    Acc1 is Acc + H,
    sum_list_down(T, Acc1, Summ).

%Удаляет все элементы, сумма цифр которых равна данной
remove_by_digit_sum([], _, []).
remove_by_digit_sum([H|T], TargetSum, Result) :-
    numSumDown(H, Sum),
    ( Sum =:= TargetSum ->
        remove_by_digit_sum(T, TargetSum, Result)
    ; Result = [H|Rest],
      remove_by_digit_sum(T, TargetSum, Rest)
    ).

%Произведение цифр numProd(+N,?S), вниз
numProdDown(X,Answer):-
    numProdDownInner(X,1,Answer).
numProdDownInner(0,Acc,Acc):-!.
numProdDownInner(X,Acc,Answer):-
    X1 is X div 10,
    Acc1 is Acc * (X mod 10),
    numProdDownInner(X1,Acc1,Answer).

%Количество нечетных цифр числа, больших 3
numMoreThenThreeCount(X,Answer):-
    numMoreThenThreeCountInner(X,0,Answer).
numMoreThenThreeCountInner(0,Acc,Acc):-!.
numMoreThenThreeCountInner(X,Acc,Answer):-
    X1 is X div 10,
   (((X mod 10) > 3, (X mod 10) mod 2 =:= 1) ->
        Acc1 is Acc + 1
    ;
        Acc1 = Acc
   ),
    numMoreThenThreeCountInner(X1,Acc1,Answer).

%НОД для двух чисел
gcd(A, 0, A) :- !.
gcd(A, B, GCD) :-
    R is A mod B,
    gcd(B, R, GCD).

%Сдвиг вправо на 2 позиции
shift_right_2(List, Result) :-
    myappend(Mid, [A, B], List),
    myappend([A, B], Mid, Result).

%Сдвиг влево на 1 позицию
shift_left_1([H|T], Result) :- myappend(T, [H], Result).

%Минимум списка
my_min_list([X], X).
my_min_list([H|T], Min) :-
    my_min_list(T, TempMin),
    (H < TempMin -> Min = H ; Min = TempMin).

%Максимум списка
my_max_list([X], X).
my_max_list([H|T], Max) :-
    my_max_list(T, TempMax),
    (H > TempMax -> Max = H ; Max = TempMax).

%Смена минимального и максимального
swap_min_max([], _, _, []).
swap_min_max([H|T], Min, Max, [Max|R]) :-
    H =:= Min, swap_min_max(T, Min, Max, R).
swap_min_max([H|T], Min, Max, [Min|R]) :-
    H =:= Max, swap_min_max(T, Min, Max, R).
swap_min_max([H|T], Min, Max, [H|R]) :-
    H =\= Min, H =\= Max, swap_min_max(T, Min, Max, R).

testTask3 :-
    read_list(List),
    shift_right_2(List,Result1),
    write('Сдвиг вправо на 2:'), nl,
    write_list(Result1),
    shift_left_1(List,Result2),
    write('Сдвиг влево на 1:'), nl,
    write_list(Result2),
    my_min_list(List,Min),
    my_max_list(List,Max),
    swap_min_max(List,Min,Max,Result3),
    write('Смена местами максимального и минимального:'), nl,
    write_list(Result3).