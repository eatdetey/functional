% Чтение всех строк из файла
read_lines(File, Lines) :-
    setup_call_cleanup(
        open(File, read, Stream),
        read_string(Stream, _, Content),
        close(Stream)),
    split_string(Content, "\n", "", Lines).

% Запись списка строк в файл
write_lines(File, Lines) :-
    atomics_to_string(Lines, "\n", Content),
    setup_call_cleanup(
        open(File, write, Stream),
        write(Stream, Content),
        close(Stream)).

% Вывод строки на экран
print_string(String) :-
    write(String), nl.

% Вывод списка строк
print_strings([]).
print_strings([H|T]) :-
    print_string(H),
    print_strings(T).

% Длина наибольшей строки
max_line_length(File, MaxLength) :-
    read_lines(File, Lines),
    maplist(string_length, Lines, Lengths),
    max_list(Lengths, MaxLength).

count_lines_without_spaces(File, Count) :-
    read_lines(File, Lines),
    include(has_no_spaces, Lines, CleanLines),
    length(CleanLines, Count).

has_no_spaces(String) :-
    \+ sub_string(String, _, _, _, " ").

% Строки с количеством букв А выше среднего
lines_with_above_avg_a(File) :-
    read_lines(File, Lines),
    maplist(count_char(a), Lines, Counts),
    sum_list(Counts, Total),
    length(Lines, NumLines),
    Avg is Total / NumLines,
    print_above_avg(Lines, Counts, Avg).

count_char(Char, String, Count) :-
    string_lower(String, Lower),
    count_substring(Lower, Char, Count).

% Преобразование строки в нижний регистр (для регистронезависимого поиска)
string_lower(String, Lower) :-
    string_lower(String, Lower).

count_substring(String, Sub, Count) :-
    atomic_list_concat([Sub], '', SubAtom),
    atomic_list_concat(L, SubAtom, String),
    length(L, Len),
    Count is Len - 1.

%Самое частое слово
most_frequent_word(File, Word) :-
    read_lines(File, Lines),
    lines_to_words(Lines, Words),
    count_words(Words, Counts),
    keysort(Counts, Sorted),
    reverse(Sorted, [_-Word|_]).

lines_to_words(Lines, Words) :-
    maplist(split_string(" "), Lines, WordsLists),
    append(WordsLists, Words).

% Разделение строки по пробелам
split_string(Line, Sep, "", Words) :-
    split_string(Line, Sep, "", Words).

count_words([], []).
count_words([W|Ws], Counts) :-
    count_word(W, Ws, 1, N, Rest),
    count_words(Rest, RestCounts),
    Counts = [N-W|RestCounts].

count_word(W, [], N, N, []).
count_word(W, [W|Ws], Acc, N, Rest) :-
    Acc1 is Acc + 1,
    count_word(W, Ws, Acc1, N, Rest).
count_word(W, [X|Ws], Acc, N, [X|Rest]) :-
    W \= X,
    count_word(W, Ws, Acc, N, Rest).

% Запись строк с уникальными словами в новый файл
write_unique_words_lines(InputFile, OutputFile) :-
    read_lines(InputFile, Lines),
    lines_to_words(Lines, AllWords),
    find_unique_words(AllWords, UniqueWords),
    include(contains_only_unique_words(UniqueWords), Lines, UniqueLines),
    write_lines(OutputFile, UniqueLines).

find_unique_words(Words, Unique) :-
    count_words(Words, Counts),
    include(is_unique, Counts, UniquePairs),
    pairs_values(UniquePairs, Unique).

is_unique(1-_).

contains_only_unique_words(UniqueWords, Line) :-
    split_string(Line, " ", "", Words),
    forall(member(W, Words), member(W, UniqueWords)).
