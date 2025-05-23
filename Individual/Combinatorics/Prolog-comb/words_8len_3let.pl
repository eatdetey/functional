alphabet([a, b, c, d, e, f]).

generate_words(FileName) :-
    open(FileName, write, Stream),
    alphabet(Alphabet),
    generate_combinations(3, Alphabet, CombList),
    generate_and_write_words(CombList, Stream),
    close(Stream).

generate_combinations(0, _, [[]]) :- !.
generate_combinations(_, [], []) :- !.
generate_combinations(N, [H|T], Result) :-
    N > 0,
    N1 is N - 1,
    generate_combinations(N1, T, R1),
    add_head(H, R1, R1H),
    generate_combinations(N, T, R2),
    append_custom(R1H, R2, Result).

add_head(_, [], []).
add_head(H, [L|Ls], [[H|L]|Rest]) :-
    add_head(H, Ls, Rest).

append_custom([], L, L).
append_custom([H|T], L, [H|R]) :-
    append_custom(T, L, R).

generate_and_write_words([], _).
generate_and_write_words([Letters|Rest], Stream) :-
    generate_words_with_letters(Letters, Word),
    atomic_list_concat(Word, WordAtom),
    writeln(Stream, WordAtom),
    fail;  % Принудительный backtracking для генерации всех слов
    generate_and_write_words(Rest, Stream).

generate_words_with_letters(Letters, Word) :-
    word_length8(Letters, [], Word),
    count_unique(Word, 3).  % <-- добавляем эту проверку

word_length8(_, Word, Word) :- length_custom(Word, 8), !.
word_length8(Letters, Acc, Word) :-
    member_custom(L, Letters),
    append_custom(Acc, [L], NewAcc),
    word_length8(Letters, NewAcc, Word).

member_custom(X, [X|_]).
member_custom(X, [_|T]) :- member_custom(X, T).

length_custom([], 0).
length_custom([_|T], N) :-
    length_custom(T, N1),
    N is N1 + 1.

unique_count([], []).
unique_count([H|T], [H|Rest]) :-
    not(member_custom(H, T)),
    unique_count(T, Rest).
unique_count([H|T], Rest) :-
    member_custom(H, T),
    unique_count(T, Rest).

count_unique(List, N) :-
    unique_custom(List, Unique),
    length_custom(Unique, N).

unique_custom(List, Unique) :-
    unique_custom(List, [], Unique).

unique_custom([], Acc, Acc).
unique_custom([H|T], Acc, Unique) :-
    member_custom(H, Acc),
    unique_custom(T, Acc, Unique).
unique_custom([H|T], Acc, Unique) :-
    not(member_custom(H, Acc)),
    append_custom(Acc, [H], NewAcc),
    unique_custom(T, NewAcc, Unique).