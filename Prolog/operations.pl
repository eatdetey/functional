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

% Проверка на простоту
prime(2).
prime(N) :- N > 2, N mod 2 =\= 0, not(has_divisor(N,3)).

% Проверка наличия делителя от D до sqrt(N)
has_divisor(N,D) :- D*D =< N, (N mod D =:= 0 ; D2 is D+2, has_divisor(N,D2)).

% Делитель числа
divisor(X,Y) :- Y mod X =:= 0.

% Сумма простых делителей
sum_prime_divisors(N,Sum) :- sum_prime_divisors(N,2,0,Sum).

sum_prime_divisors(N,Cur,Acc,Acc) :- Cur > N, !.
sum_prime_divisors(N,Cur,Acc,Sum) :-
    Cur =< N,
    divisor(Cur,N),
    prime(Cur), !,
    Acc1 is Acc + Cur,
    Cur1 is Cur + 1,
    sum_prime_divisors(N,Cur1,Acc1,Sum).
sum_prime_divisors(N,Cur,Acc,Sum) :-
    Cur1 is Cur + 1,
    sum_prime_divisors(N,Cur1,Acc,Sum).

% Произведение делителей с условием
product_divisors_by_digit_sum(N,Product) :- 
    numSumDown(N,SumN),
    product_divisors_by_digit_sum(N,2,SumN,1,Product).

product_divisors_by_digit_sum(N,Cur,_,Product,Product) :- Cur > N, !.
product_divisors_by_digit_sum(N,Cur,SumN,Acc,Product) :-
    Cur =< N,
    divisor(Cur,N),
    numSumDown(Cur,SumC),
    SumC < SumN, !,
    Acc1 is Acc * Cur,
    Cur1 is Cur + 1,
    product_divisors_by_digit_sum(N,Cur1,SumN,Acc1,Product).
product_divisors_by_digit_sum(N,Cur,SumN,Acc,Product) :-
    Cur1 is Cur + 1,
    product_divisors_by_digit_sum(N,Cur1,SumN,Acc,Product).

% Подсчёт количества вхождений элемента
count_elem(_,[],0).
count_elem(Elem,[Elem|T],Count) :- count_elem(Elem,T,Count1), Count is Count1 + 1.
count_elem(Elem,[_|T],Count) :- count_elem(Elem,T,Count).

% Подсчёт количества минимальных элементов
count_min(List,Count) :- 
    min_list(List,Min),
    count_elem(Min,List,Count).

% Построить список уникальных элементов
unique([],[]).
unique([H|T],R) :- in_list(T,H), !, unique(T,R).
unique([H|T],[H|R]) :- unique(T,R).

% Удаление всех вхождений элемента
remove_all(_,[],[]).
remove_all(E,[E|T],R) :- remove_all(E,T,R).
remove_all(E,[H|T],[H|R]) :- E \= H, remove_all(E,T,R).

% Подсчёт количества вхождений элемента
count_elem(_,[],0).
count_elem(Elem,[Elem|T],Count) :- count_elem(Elem,T,Count1), Count is Count1 + 1.
count_elem(Elem,[_|T],Count) :- count_elem(Elem,T,Count).

% Построить список N одинаковых элементов
make_list(_,0,[]).
make_list(E,N,[E|T]) :- N > 0, N1 is N-1, make_list(E,N1,T).

% Главный предикат
sort_by_count([],[]).
sort_by_count(List,Result) :-
    max_count_elem(List,MaxEl,MaxCount),
    make_list(MaxEl,MaxCount,L1),
    remove_all(MaxEl,List,Rest),
    sort_by_count(Rest,RestResult),
    append(L1,RestResult,Result).

% Найти элемент с максимальным количеством вхождений
max_count_elem(List,MaxEl,MaxCount) :-
    findall(Count-Elem, (in_list(List,Elem), count_elem(Elem,List,Count)), Pairs),
    sort(0,@>=,Pairs,Sorted),  % сортируем по убыванию Count
    Sorted = [MaxCount-MaxEl|_].