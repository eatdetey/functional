pr_friends :-
    Friends = [_,_,_],
    in_list(Friends,[_,blond]),
    in_list(Friends,[_,brunet]),
    in_list(Friends,[_,red]),
    in_list(Friends,[belokurov,_]),
    in_list(Friends,[ryzhov,_]),
    in_list(Friends,[chernov,_]),
    not(in_list(Friends,[belokurov,blond])),
    not(in_list(Friends,[ryzhov,red])),
    not(in_list(Friends,[chernov,brunet])),
    in_list(Friends,[Who_said,brunet]),
    Who_said \= belokurov,
    write(Friends), nl.
